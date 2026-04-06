using MyIni;
using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AyCanvars.Form1;

namespace AyCanvars.layout
{
    public partial class setting : Form
    {
        private CancellationTokenSource _animationCts;
        private Boolean isInit = true;
        private IniFile MyIni = new IniFile();
        public setting()
        {

            InitializeComponent();

            RefreshFormIni();
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            TreeNode treeRegularNode = new TreeNode("常规");
            TreeNode treeAboutNode = new TreeNode("关于");
            treeView.Nodes.Add(treeRegularNode);
            treeView.Nodes.Add(treeAboutNode);
     
            // 添加几个文件夹作为子节点
            TreeNode autoSavingNode = new TreeNode("自动存储");
            TreeNode requireAdministratorNode = new TreeNode("启动设置");
            TreeNode UpdateNode = new TreeNode("更新");
            treeRegularNode.Nodes.Add(requireAdministratorNode);
            treeRegularNode.Nodes.Add(autoSavingNode);
            treeRegularNode.Nodes.Add(UpdateNode);
            // 完成节点添加后，恢复控件的绘制
            treeView.EndUpdate();
            treeView.ExpandAll();
            isInit = false;
        }
        /// <summary>
        /// 平滑移动控件从 fromX 到 toX
        /// </summary>
        /// <param name="control">要移动的控件，方法会修改其 Location.X 属性</param>
        /// <param name="fromX">起始 X 坐标</param>
        /// <param name="toX">目标 X 坐标</param>
        /// <param name="step">每次移动的像素步长（正数表示向右移动，负数表示向左移动）。方法内部会根据 fromX 和 toX 的大小关系自动计算方向并调整步长符号，因此传入正步长即可</param>
        /// <param name="delayMs">每次移动之间的延迟时间（毫秒）。值越小动画越流畅，但 CPU 负载越高；通常取 5~15</param>
        /// <param name="token">用于取消动画的令牌。当外部请求取消（如窗体关闭）时，循环会提前退出，避免访问已释放的控件或浪费资源</param>
        /// <returns></returns>
        private async Task AnimateMove(Control control, int fromX, int toX, int step, int delayMs, CancellationToken token)
        {
            int currentX = fromX;
            int direction = Math.Sign(toX - fromX); 
            step = step * direction;           

            while (currentX != toX && !token.IsCancellationRequested)
            {
                int newX = currentX + step;
                if (direction == 1 && newX > toX) newX = toX;
                if (direction == -1 && newX < toX) newX = toX;

                control.Location = new Point(newX, control.Location.Y);
                currentX = newX;

                await Task.Delay(delayMs, token);
            }
        }
        private void RefreshFormIni()
        {
            
            if (MyIni.Read("AutoSaving", "Regular") == "True")
            {
                autoSavingCB.Checked = true;
            } else if (MyIni.Read("AutoSaving", "Regular") != "False")
            {
                MyIni.Write("AutoSaving", "False", "Regular");
            }

            if (MyIni.Read("requireAdministrator", "Program") == "True")
            {
                requireAdministratorCB.Checked = true;
            }
            else if (MyIni.Read("requireAdministrator", "Program") != "False")
            {
                MyIni.Write("requireAdministrator", "False", "Program");
            }

            if (MyIni.Read("channel", "Update") == "Stable")
            {
                radioButton1.Checked = true;
            }
            else if (MyIni.Read("channel", "Update") == "Dev")
            {
                radioButton2.Checked = true;
            }
            else if (MyIni.Read("channel", "Update") == "Custom")
            {
                radioButton3.Checked = true;
                textBox1.Text =  MyIni.Read("custom_url ", "Update");
            }
            else
            {
                MyIni.Write("channel", "Stable", "Update");
                MyIni.Write("custom_url", "https://undz.cn/aycanvars/release/update.ini", "Update");
            }

            if(MyIni.Read("auto_check ", "Update") == "True")
            {
                checkBox1.Checked = true;
            }
            else if (MyIni.Read("auto_check", "Update") != "False")
            {
                MyIni.Write("auto_check", "False", "Update");
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeText = e.Node.Text;
            switch (nodeText)
            {
                case "常规":
                    tabControl.SelectedIndex = 0;
                    break;
                case "自动存储":
                    tabControl.SelectedIndex = 1;
                    break;
                case "关于":
                    aboutAyCanvars aboutAyCanvars = new aboutAyCanvars();
                    aboutAyCanvars.ShowDialog();
                    break;
                case "启动设置":
                    tabControl.SelectedIndex = 2;
                    break;
                case "更新":
                    tabControl.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
            
        }

        private async void autoSavingCB_CheckedChanged(object sender, EventArgs e)
        {
            if (isInit) return;
            _animationCts?.Cancel();
            _animationCts?.Dispose();
            _animationCts = new CancellationTokenSource();
            var token = _animationCts.Token;

            MyIni.Write("AutoSaving", autoSavingCB.Checked.ToString(), "Regular");

            tip.Text = "该操作将重启后生效";
            tip.Visible = true;
            const int step = 10;          // 每次移动像素
            const int delayMs = 5;      // 每步延迟
            int startX = -tip.Width;     // 开始位置
            int endX = 2;               // 最终位置

            tip.Location = new Point(startX, tip.Location.Y);

            try
            {
                tip.Location = new Point(startX, tip.Location.Y);
                await AnimateMove(tip, startX, endX, step, delayMs, token);
                await Task.Delay(1800, token);
                await AnimateMove(tip, endX, startX, step, delayMs, token);
                tip.Visible = false;
            }
            catch (OperationCanceledException)
            {
                tip.Visible = false;  // 动画被取消，直接隐藏
            }
            catch (ObjectDisposedException)
            {
                // 窗体已关闭，无需处理
            }
        }

        private void setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _animationCts?.Cancel();
            _animationCts?.Dispose();
        }

        private void requireAdministratorCB_CheckedChanged(object sender, EventArgs e)
        {
            if (isInit) return;
            MyIni.Write("requireAdministrator", requireAdministratorCB.Checked.ToString(), "Program");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label7.Visible = false;
            textBox1.Enabled = false;
            if (isInit) return;
            MyIni.Write("channel", "Stable", "Update");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label7.Visible = false;
            textBox1.Enabled = false;
            if (isInit) return;
            MyIni.Write("channel", "Dev", "Update");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label7.Visible = true;
            textBox1.Enabled = true;
            if (isInit) return;
            MyIni.Write("channel", "Custom", "Update");
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isInit) return;
            MyIni.Write("auto_check",checkBox1.Checked.ToString(), "Update");
        }

        private async void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isInit) return;
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                try
                {
                    _ = await client.DownloadStringTaskAsync(textBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("自定义更新链接下载地址无效，请重新填写", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MyIni.Write("custom_url", textBox1.Text, "Update");
                MessageBox.Show("保存成功", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (isInit) return;
            string channelStr = MyIni.Read("channel", "Update");
            UpdateChannel channel = ParseChannel(channelStr);
            string customUrl = MyIni.Read("custom_url", "Update");
            Update update = new Update(channel, customUrl);
            update.Show();
            Task<bool> _ = update.CheckHasUpdatesAsync();
        }
    }
}
