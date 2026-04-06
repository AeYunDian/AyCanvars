using AyCanvars.layout;
using Log;
using MyIni;
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
namespace AyCanvars
{
    internal static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            LogFile.Initialize(name: "AyCanvars", logPath: "Log.log");
            var log = LogFile.Instance;
            Application.ApplicationExit += (sender, e) => log.Dispose();
            IniFile MyIni = new IniFile();
            log.Info("Init Myint class");
            if (MyIni.Read("requireAdministrator", "Program") == "True")
            {
                if (args.Length > 0)
                {
                    if (args[0].ToLower() == "-norequireadministrator")
                    {
                        goto defStart;
                    }
                } //如果暂时禁用，就不重启
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas" // 请求管理员权限
                    };
                    try
                    {
                        Process.Start(startInfo);
                    }
                    catch (System.ComponentModel.Win32Exception ex) when (ex.NativeErrorCode == 1223)
                    {
                        log.Info("User canceled UAC elevation. Exiting.");
                        Environment.Exit(0);
                        return;
                    }
                    catch (Exception ex)
                    {
                        
                        log.Fatal(ex, "无法以管理员权限启动程序");
                        DialogResult result = MessageBox.Show("无法以管理员权限启动程序，是否暂时禁用管理员权限模式重启？\n（可在 设置-常规-启动 中永久设置）", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.Yes) {
                            ProcessStartInfo restartInfo = new ProcessStartInfo
                            {
                                UseShellExecute = true,
                                WorkingDirectory = Environment.CurrentDirectory,
                                FileName = Application.ExecutablePath,
                                Arguments = "-noRequireAdministrator"

                            };
                            try
                            {
                                Process.Start(restartInfo);
                                
                            } catch (Exception exce)
                            {
                                log.Fatal(exce, "无法以普通模式重启");
                                MessageBox.Show("无法以普通模式重启，请重试或重新安装本软件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    Environment.Exit(0);
                    return;
                }
            }
            else if (MyIni.Read("requireAdministrator", "Program") != "False")
            {
                MyIni.Write("requireAdministrator", "False", "Program");
            }
        defStart:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log.Info("Program: Basic style settings applied");
            log.Info("Program: Start judging the startup parameters");
            
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "-nowelcome":
                            log.Info("Program: Start with no splash");
                            Application.Run(new Form1());
                            return;
                        case "-about":
                        case "-ver":
                            log.Info("Program: Just show about page");
                            aboutAyCanvars aboutAyCanvars = new aboutAyCanvars();
                            aboutAyCanvars.ShowDialog(); //这是一个Dialog窗体，使用DialogRes返回，如果以普通模式启动会导致点击确定没反应
                            return;
                    }
                }
                log.Info("Program: Normal startup form");
                Application.Run(new WelcomeForm());
            }
            else
            {
                log.Info("Program: Normal startup form");
                Application.Run(new WelcomeForm());
            }
        }
    }
}
