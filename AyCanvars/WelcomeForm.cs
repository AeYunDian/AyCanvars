using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyCanvars
{
    public partial class WelcomeForm : Form
    {
        public  WelcomeForm()
        {
            InitializeComponent();

            
        }
        private static void RestartWithNoWelcome()
        {
            string currentExe = Application.ExecutablePath;
            string arguments = string.Join(" ", Environment.GetCommandLineArgs().Skip(1)) + " -NoWelcome";
            Process.Start(currentExe, arguments);
            Environment.Exit(0);
        }
        private async void WelcomeForm_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;
                if (today.Month == 4 && today.Day == 1 || today.Year < 2026) {
                    throw new Exception("0x00000031 PHASE0_INITIALIZATION_FAILED");
                }
                await Task.Delay(1700);
                Form1 form1 = new Form1();
                form1.FormClosed += (s, args) => this.Close(); // 当 Form1 关闭时，关闭欢迎窗体
                form1.Show();
                this.Hide(); // 隐藏欢迎窗体，而不是关闭
            }
            catch (Exception ex) { 
                DialogResult res = MessageBox.Show($"启动失败，继续将以安全模式重启\n\n错误信息：\n{ex.Message}\n{ex.Source}{ex.StackTrace}", "启动失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.OK)
                {
                    RestartWithNoWelcome();
                }
                Application.Exit();
            }

        }


    }
}
