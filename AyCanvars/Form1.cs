using AyCanvars.layout;
using Log;
using MyIni;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace AyCanvars
{
    public partial class Form1 : Form
    {
        public enum UpdateChannel
        {
            Stable,     // 正式版
            Dev,        // 开发版
            Custom      // 自定义版（用户指定 URL）
        }
        public static UpdateChannel ParseChannel(string channelStr)
        {
            if (string.IsNullOrEmpty(channelStr))
                return UpdateChannel.Stable; // 默认正式版

            switch (channelStr.ToLower())
            {
                case "stable": return UpdateChannel.Stable;
                case "dev": return UpdateChannel.Dev;
                case "custom": return UpdateChannel.Custom;
                default: return UpdateChannel.Stable;
            }
        }
        LogFile log = LogFile.Instance;
        private bool isWaitingForTextInput = false;
        private TouchablePictureBox touchablePbCanvas;
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();  // 撤销栈
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();  // 重做栈
        private Bitmap canvasBitmap;   // 绘图表面
        private Graphics canvasGraphics;
        public bool isText;
        private bool isPen;
        private Color penColor = Color.White;
        private int penSize = 3;
        private int eraserSize = 64;
        private bool isEraser = false;
        private Color backColor = Color.FromArgb(0xFF, 0x0F, 0x26, 0x1E);
        private IniFile MyIni = new IniFile();
        [DllImport("user32.dll")]
        private static extern bool GetTouchInputInfo(IntPtr hTouchInput, int cInputs, [Out] TOUCHINPUT[] pInputs, int cbSize);
        [DllImport("user32.dll")]
        private static extern bool UnregisterTouchWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern void CloseTouchInputHandle(IntPtr hTouchInput);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool RegisterTouchWindow(IntPtr hWnd, uint ulFlags);
        private const int WM_TOUCH = 0x0240;
        private const uint TOUCHEVENTF_MOVE = 0x0001;
        private const uint TOUCHEVENTF_DOWN = 0x0002;
        private const uint TOUCHEVENTF_UP = 0x0004;
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        [StructLayout(LayoutKind.Sequential)]
        public struct TOUCHINPUT
        {
            public int x;         // 屏幕坐标，是 1/100 毫米单位，需用 GetPhysicalCursorPos 转换
            public int y;
            public IntPtr hSource;
            public int dwID;
            public int dwFlags;
            public int dwMask;
            public int dwTime;
            public IntPtr dwExtraInfo;
            public int cxContact;
            public int cyContact;
        }


        public Form1()
        {
            log.Info("Form1: Start initialization");
            InitializeComponent();
            log.Info("Form1: Component creation completed");
            touchablePbCanvas = new TouchablePictureBox(this);
            touchablePbCanvas.Dock = DockStyle.Fill;
            //为鼠标做兼容
            touchablePbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            touchablePbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            touchablePbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
            this.Controls.Remove(pbCanvas);
            this.Controls.Add(touchablePbCanvas);
            pbCanvas = touchablePbCanvas;
            log.Info("Touch-specific image frame created");
            log.Info("Set window style");
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            log.Info("Set up the dock bar");
            cleanAllSelect();
            isPen = true;
            this.pen_btn.Image = global::AyCanvars.Properties.Resources.pen_activated;
            eraser.BackColor = Color.Transparent;
            CenPanel.BackColor = Color.Transparent;
            AlignLeftPanel.BackColor = Color.Transparent;
            pbCanvas.Controls.Add(eraser);
            pbCanvas.Controls.Add(CenPanel);
            pbCanvas.Controls.Add(AlignLeftPanel);
            eraser.BringToFront();
            CenPanel.BringToFront();
            AlignLeftPanel.BringToFront();
            eraser.Visible = false;
            CenPanel.Location = new Point((this.ClientSize.Width - CenPanel.Width) / 2,this.ClientSize.Height - CenPanel.Height);
            AlignLeftPanel.Location = new Point(0, this.ClientSize.Height - AlignLeftPanel.Height);

            this.TransparencyKey = Color.LimeGreen;
            int maxTouchPoints = GetSystemMetrics(0x0095); // SM_MAXIMUMTOUCHES
            log.Info($"系统支持的最大触摸点数: {maxTouchPoints}");
            //IniFile 
            log.Info("Basic initialization is complete! Display the window");
            this.WindowState = FormWindowState.Maximized;
        }
        private Dictionary<int, TouchState> touchStates = new Dictionary<int, TouchState>();
        
        public void SetTouchEnabled(bool enabled)
        {
            if (touchablePbCanvas != null && !touchablePbCanvas.IsDisposed)
            {
                if (enabled)
                {
                    RegisterTouchWindow(touchablePbCanvas.Handle, 0);
                }
                else
                {
                    UnregisterTouchWindow(touchablePbCanvas.Handle);
                }
            }
        }
        private class TouchState
        {
            public bool IsDrawing { get; set; }
            public Point LastPoint { get; set; }
        }
        public void clearMemory()
        {

            foreach (var bmp in undoStack) bmp.Dispose();
            undoStack.Clear();
            foreach (var bmp in redoStack) bmp.Dispose();
            redoStack.Clear();
            SaveStateForUndo();
        }
        public void HandleTouchMessage(ref Message m)
        {
            if (m.Msg == WM_TOUCH)
            {

                Debug.WriteLine("WM_TOUCH received");
                int inputCount = m.WParam.ToInt32();
                Debug.WriteLine($"WM_TOUCH: {inputCount} points");
                var touchInputs = new TOUCHINPUT[inputCount];
                if (GetTouchInputInfo(m.LParam, inputCount, touchInputs, Marshal.SizeOf(typeof(TOUCHINPUT))))
                {
                    foreach (var touch in touchInputs)
                    {
                        Point screenPoint = new Point(touch.x / 100, touch.y / 100);
                        Point canvasPoint = pbCanvas.PointToClient(screenPoint);

                        int id = touch.dwID;
                        bool isDown = (touch.dwFlags & TOUCHEVENTF_DOWN) != 0;
                        bool isMove = (touch.dwFlags & TOUCHEVENTF_MOVE) != 0;
                        bool isUp = (touch.dwFlags & TOUCHEVENTF_UP) != 0;

                        if (isDown)
                        {
                            OnTouchDown(id, canvasPoint);
                        }
                        else if (isMove)
                        {
                            OnTouchMove(id, canvasPoint);
                        }
                        else if (isUp)
                        {
                            OnTouchUp(id, canvasPoint);
                        }
                    }
                    CloseTouchInputHandle(m.LParam);
                    m.Result = (IntPtr)1;
                    return;
                }
            }
        }
        private void OnTouchDown(int id, Point point)
        {
            eraserSize = (int)(penSize * 10);
            if (isText && !isWaitingForTextInput)
            {
                SetTouchEnabled(false);
                isWaitingForTextInput = true;

                TextInputForm inputForm = new TextInputForm();
                
                    if (inputForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(inputForm.InputText))
                    {
                        using (Font font = inputForm.font)
                        using (Brush brush = new SolidBrush(inputForm.color))
                        {
                            canvasGraphics.DrawString(inputForm.InputText, font, brush, point);
                        }
                        pbCanvas.Invalidate();
                        SaveStateForUndo();
                    }
                
                SetTouchEnabled(true);
                isText = false;
                isWaitingForTextInput = false;
                cleanAllSelect();
                isPen = true;
                pen_btn.Image = Properties.Resources.pen_activated;
                return;
            }
            if (isPen || isEraser)
            {
                if (!touchStates.ContainsKey(id))
                    touchStates[id] = new TouchState();

                var state = touchStates[id];
                state.IsDrawing = true;
                state.LastPoint = point;
                if (isEraser)
                {
                    eraser.Visible = true;
                    eraser.Location = new Point(point.X - eraser.Width / 2, point.Y - eraser.Height / 2);
                    eraser.Size = new Size(eraserSize, eraserSize);
                    eraser.Refresh();
                }
                Color drawColor = isEraser ? backColor : penColor;
                int drawSize = isEraser ? eraserSize : penSize;
                using (Pen pen = new Pen(drawColor, drawSize))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    canvasGraphics.DrawLine(pen, point, new Point(point.X + 1, point.Y - 1)); // 画一个微小的点
                }
                pbCanvas.Invalidate();
            }
        }

        private void OnTouchMove(int id, Point point)
        {
            if (touchStates.TryGetValue(id, out var state) && state.IsDrawing && (isPen || isEraser))
            {
                if (isEraser)
                {
                    eraser.Visible = true;
                    eraser.Location = new Point(point.X - eraser.Width / 2, point.Y - eraser.Height / 2);
                    eraser.Refresh();
                }

                Color drawColor = isEraser ? backColor : penColor;
                int drawSize = isEraser ? eraserSize : penSize;
                using (Pen pen = new Pen(drawColor, drawSize))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    canvasGraphics.DrawLine(pen, state.LastPoint, point);
                }
                state.LastPoint = point;
                pbCanvas.Invalidate();
            }
        }

        private void OnTouchUp(int id, Point point)
        {
            if (touchStates.TryGetValue(id, out var state))
            {
                state.IsDrawing = false;
                touchStates.Remove(id);
                if (isEraser)
                {
                    eraser.Visible = false;
                }
                // 记录一次历史（与鼠标抬起逻辑一致）
                if (isPen || isEraser )
                {
                    SaveStateForUndo();
                }
            }
        }
        public void exportCurrentPage()
        {
            saveFileDialog.Reset();
            saveFileDialog.Filter = "位图|*.bmp|PNG|*.png|JPEG (*.jpg,*.jpeg)|*.jpg|GIF|*.gif|所有文件 (*.*)|*.*";
            saveFileDialog.Title = "保存当前页面图片";
            saveFileDialog.FileName = "page.bmp";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                try {
                    Bitmap copy;
                    lock (canvasBitmap)
                    {
                        copy = new Bitmap(canvasBitmap);
                    }
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                System.Drawing.Imaging.ImageFormat format;
                switch (extension)
                {
                    case ".png":
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".jpg":
                    case ".jpeg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    default:
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }

                        copy.Save(saveFileDialog.FileName, format);
                        copy.Dispose();
                    
                MessageBox.Show($"保存成功，文件位于：{saveFileDialog.FileName}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }
        private void SaveStateForUndo()
        {
            Bitmap snapshot = new Bitmap(canvasBitmap);
            undoStack.Push(snapshot);
            redoStack.Clear();
            if (undoStack.Count > 64)
            {
                // 移除最早的历史
                var oldest = undoStack.ToList()[0];
                undoStack = new Stack<Bitmap>(undoStack.Skip(1));
                oldest.Dispose();
            }
        }
        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OnTouchDown(-1, e.Location);
            }
            
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            OnTouchMove(-1, e.Location);
        }
        public void Undo()
        {
            if (undoStack.Count > 1)  // 至少有一张历史图和当前图
            {
                // 先把当前画板保存到重做栈
                redoStack.Push(new Bitmap(canvasBitmap));

                // 弹出上一张历史图像，替换当前画板
                Bitmap previous = undoStack.Pop();
                canvasBitmap = previous;
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                pbCanvas.Image = canvasBitmap;
            }
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                // 把当前画板保存到撤销栈
                undoStack.Push(new Bitmap(canvasBitmap));

                // 弹出重做图像
                Bitmap next = redoStack.Pop();
                canvasBitmap = next;
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                pbCanvas.Image = canvasBitmap;
            }
        }
        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            OnTouchUp(-1, e.Location);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            CenPanel.Location = new Point((this.ClientSize.Width - CenPanel.Width) / 2,this.ClientSize.Height - CenPanel.Height);
            AlignLeftPanel.Location  = new Point(0, this.ClientSize.Height - AlignLeftPanel.Height);
            if (pbCanvas.Width <= 0 || pbCanvas.Height <= 0) return;
            if (canvasBitmap == null) return;

            if (pbCanvas.Width == canvasBitmap.Width && pbCanvas.Height == canvasBitmap.Height)
                return;
            Bitmap newBitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(backColor);

                if (canvasBitmap != null)
                {
                    if (1 == 1 || pbCanvas.Width >= canvasBitmap.Width && pbCanvas.Height >= canvasBitmap.Height)
                    {
                        g.DrawImage(canvasBitmap, 0, 0, canvasBitmap.Width, canvasBitmap.Height);
                    }
                    else //暂时先不用，等未来对于缩放有更好的算法再改
                    {
                        g.DrawImage(canvasBitmap, 0, 0, newBitmap.Width, newBitmap.Height);
                    }
                }
            }
            canvasGraphics?.Dispose();
            canvasBitmap?.Dispose();
            canvasBitmap = newBitmap;
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            pbCanvas.Image = canvasBitmap;
        }
        public void cleanAllSelect()
        {
            isPen = false;
            isText = false;
            isEraser = false;
            this.mouse_sel_btn.Image = global::AyCanvars.Properties.Resources.mouse_sel_not_activated;
            this.pen_btn.Image = global::AyCanvars.Properties.Resources.pen_not_activated;
            this.eraser_btn.Image = global::AyCanvars.Properties.Resources.eraser_not_activated;
            this.more_btn.Image = global::AyCanvars.Properties.Resources.more_not_activated;
        }
        private void pen_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {return;}

            if (isPen)
            {
                Point screenPos = pbCanvas.PointToScreen(CenPanel.Location);
                penSetting penSetting = new penSetting(this);
                penSetting.SetCenPanelLoction(screenPos, penSize, penColor, backColor);
                penSetting.Show();
            } else if (!isPen)
            {
                cleanAllSelect();
                isPen = true;
                this.pen_btn.Image = global::AyCanvars.Properties.Resources.pen_activated;
            }
        }
        public  void setPen(Color color, int dz, int Size = 0)
        {
            switch (dz)
            {
                case 0:
                    penSize = Size;
                    break;
                case 1: 
                    penColor = color; 
                    break;
                case 2:
                    backColor = color;
                    canvasGraphics.Clear(backColor);
                    pbCanvas.Image = canvasBitmap;
                    break;
                default :
                    throw new Exception("设置画板属性时出现错误");
            }

        }
        private void eraser_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }

            if (isEraser)
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("继续将清除全部", "清除全部？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    canvasGraphics.Clear(backColor);
                    pbCanvas.Image = canvasBitmap;
                    SaveStateForUndo();
                    cleanAllSelect();
                    isPen = true;
                    this.pen_btn.Image = global::AyCanvars.Properties.Resources.pen_activated;
                }
            }
            else if (!isEraser)
            {
                cleanAllSelect();
                isEraser = true;
                this.eraser_btn.Image = global::AyCanvars.Properties.Resources.eraser_activated;
            }
        }

        private void more_btn_MouseDown(object sender, MouseEventArgs e)
        {
            Point screenPos = pbCanvas.PointToScreen(CenPanel.Location);
            more more = new more(this);
            more.SetCenPanelLoction(screenPos);
            more.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            canvasGraphics?.Dispose();
            canvasBitmap?.Dispose();
            foreach (var bmp in undoStack) bmp.Dispose();
            foreach (var bmp in redoStack) bmp.Dispose();
            base.OnFormClosing(e);
        }
        private void mouse_sel_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            cleanAllSelect();
            this.mouse_sel_btn.Image = global::AyCanvars.Properties.Resources.mouse_sel_activated;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetTouchEnabled(true);
            // 确保画板尺寸有效
            if (pbCanvas.Width <= 0 || pbCanvas.Height <= 0)
                return;

            canvasBitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(backColor);
            canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            pbCanvas.Image = canvasBitmap;
            SaveStateForUndo();
            pbCanvas.Invalidate();


            string channelStr = MyIni.Read("channel", "Update");
            bool autoCheck = MyIni.Read("auto_check", "Update") == "True";
            if (!autoCheck) return;
            UpdateChannel channel = ParseChannel(channelStr);
            string customUrl = MyIni.Read("custom_url", "Update");

            Update update = new Update(channel, customUrl);
            Task<bool> _ = update.CheckHasUpdatesAsync();
        }

        private void exit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            DialogResult result = MessageBox.Show("您确实要退出？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes) { 
                Application.Exit();
            }
        }

        private void menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            Point screenPos = pbCanvas.PointToScreen(AlignLeftPanel.Location);
            menu menu = new menu(this);
            menu.SetAlignLeftPanelLoction(screenPos);
            menu.Show();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            
        }
    }
    public class TouchablePictureBox : PictureBox
    {
        private Form1 parentForm;

        public TouchablePictureBox(Form1 form)
        {
            parentForm = form;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_TOUCH = 0x0240;
            if (m.Msg == WM_TOUCH)
            {
                // 调用父窗体的触摸处理
                parentForm.HandleTouchMessage(ref m);
                return;
            }
            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterTouchWindow(IntPtr hWnd, uint ulFlags);
    }
}
