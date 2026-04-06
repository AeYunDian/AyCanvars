using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace AyCanvars
{
    public partial class TextInputForm : Form
    {

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll")]
        private static extern bool RegisterTouchWindow(IntPtr hWnd, uint ulFlags);
        public string InputText { get; private set; }
        private Process oskProcess = null;
        public Font font { get; private set; }
        public Color color  { get; private set; }  = Color.White;
        public TextInputForm()
        {
            InitializeComponent();
            yes.DialogResult = DialogResult.OK;
            cancel.DialogResult = DialogResult.Cancel;
            
        }
    
        private static void MoveOskWindow(Process oskProcess, Point location)
        {
            if (oskProcess == null || oskProcess.HasExited) { 
            return; }
            IntPtr hWnd = oskProcess.MainWindowHandle;  // 直接使用进程主窗口句柄，避免 FindWindow
            if (hWnd != IntPtr.Zero && GetWindowRect(hWnd, out RECT rect))
            {
                int width = rect.Right - rect.Left;
                int height = rect.Bottom - rect.Top;
                SetWindowPos(hWnd, IntPtr.Zero, location.X, location.Y, width, height,
                             SWP_NOZORDER | SWP_NOACTIVATE);
            }
        }
        private void TextInputForm_Load(object sender, EventArgs e)
        {
            font = new Font("微软雅黑", 24f, FontStyle.Regular);
            color = Color.White;
            RefreshPre();
            //var handle = this.Handle; // 强制创建句柄
          //  RegisterTouchWindow(panel1.Handle, 0);
        }

        
        private Process OpenTouchKeyboard()
        {
            string oskPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), "system32", "osk.exe");
            try
            {
                return Process.Start(oskPath);
            }
            catch { return null; }
        }
        public static bool IsTouchScreen()
        {
            const int SM_DIGITIZER = 94;
            const int NID_INTEGRATED_TOUCH = 0x00000001;
            const int NID_EXTERNAL_TOUCH = 0x00000002;
            int digitizerStatus = GetSystemMetrics(SM_DIGITIZER);
            return (digitizerStatus & NID_INTEGRATED_TOUCH) != 0 ||
                   (digitizerStatus & NID_EXTERNAL_TOUCH) != 0;
        }
        private void setFont_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            fontDialog.Reset();
            fontDialog.ShowColor = false;
            fontDialog.Font = font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK) {
                
                font = fontDialog.Font;
                RefreshPre();
            }

        }

        private void RefreshPre()
        {
            if (font == null) { return; }
            if (color == Color.Empty) { return; }
            string Underline = font.Underline ? "下划线" : "";
            string BoldFont = font.Bold ? " 粗体" : "";
            string Italic = font.Italic ? " 斜体" : "";
            string Strikeout = font.Strikeout ? " 删除线" : "";
            preFont.Text = font.Name + " 大小：" + font.Size.ToString("#0") +  " " + Underline + BoldFont + Italic + Strikeout;
            colorPre.BackColor = color;
        }

        private void setColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            colorDialog.Color = colorPre.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                RefreshPre();
            }
        }

        private void yes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            InputText = textBox1.Text;
        }
        private void OskProcess_Exited(object sender, EventArgs e)
        {
            // 确保在 UI 线程上操作控件
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ResetPositionToCenter));
            }
            else
            {
                ResetPositionToCenter();
            }
        }
        private void ResetPositionToCenter()
        {
            // 如果表单已经关闭，则不需要处理
            if (this.IsDisposed) return;

            // 重置到屏幕中央
            Screen currentScreen = Screen.FromControl(this);
            this.Location = new Point(
                (currentScreen.Bounds.Width - this.Width) / 2,
                (currentScreen.Bounds.Height - this.Height) / 2
            );
        }
        private void TextInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (IsTouchScreen() && oskProcess != null && !oskProcess.HasExited)
            {
                try
                {
                    oskProcess.Exited -= OskProcess_Exited;
                    oskProcess.Kill();
                    oskProcess.WaitForExit(1000);
                    oskProcess.Dispose();
                    oskProcess.Close();
                }
                catch { }
            }
        }

        private async void textBox1_Click(object sender, EventArgs e)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (IsTouchScreen() && principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                if (oskProcess != null && !oskProcess.HasExited)
                { return; }
                oskProcess = OpenTouchKeyboard();
                oskProcess.EnableRaisingEvents = true;
                oskProcess.Exited += OskProcess_Exited;
                await Task.Delay(400);
                if (oskProcess == null || oskProcess.HasExited && oskProcess != null) return;
                if (!GetWindowRect(oskProcess.MainWindowHandle, out RECT keyboardRect))
                    return;
                int keyboardHeight = keyboardRect.Bottom - keyboardRect.Top;
                int keyboardWidth = keyboardRect.Right - keyboardRect.Left;
                Screen currentScreen = Screen.FromControl(this);
                this.Location = new Point((currentScreen.Bounds.Width - this.Width) / 2, currentScreen.Bounds.Height * (3 / 4));

                int oskX = (currentScreen.Bounds.Width - keyboardWidth) / 2;
                Point screenPos = this.Location;
                //int oskX = (int)((currentScreen.Bounds.Width - keyboardHeight) / 2);
                int oskY = this.Location.Y + this.Height + 32;
                if (oskY + keyboardHeight > currentScreen.Bounds.Bottom)
                    oskY = currentScreen.Bounds.Bottom - keyboardHeight;
                //int oskY = screenPos.Y + this.Height + 32;

                MoveOskWindow(oskProcess, new Point(oskX, oskY));
            }

            //this.StartPosition = FormStartPosition.Manual;
            //Point formPos = new Point(e.X + 20, e.Y + 20);
            //this.Location = formPos;

        }
    }
}
