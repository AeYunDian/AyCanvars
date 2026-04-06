using Log;
using Microsoft.VisualBasic;
using MyIni;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AyCanvars.Form1;

namespace AyCanvars.layout
{
    public partial class Update : Form
    {
        private UpdateChannel channel;
        IniFile iniFile;
        IniFile config = new IniFile();
        private string updateConfigUrl;
        private string tempDownloadPath = Path.Combine(Path.GetTempPath(), "AyCanvars_Setup.exe");
        private string tempDownloadIniPath = Path.Combine(Path.GetTempPath(), "AyCanvars_Setup.ini");
        public string remoteVersionStr;
        public string buildNumber;
        public string downloadUrl;
        public string releaseDate;
        public string releaseNotes;
        Boolean isCustom = false;
        LogFile log = LogFile.Instance;

        public Update(UpdateChannel channel, string customUrl = null)
        {
            this.channel = channel;
            // 根据渠道决定 updateConfigUrl
            switch (channel)
            {
                case UpdateChannel.Stable:
                    updateConfigUrl = "https://undz.cn/aycanvars/release/update.ini";
                    break;
                case UpdateChannel.Dev:
                    updateConfigUrl = "https://undz.cn/aycanvars/debug/update.ini";
                    break;
                case UpdateChannel.Custom:
                    isCustom = true;
                   updateConfigUrl = customUrl;
                    if (string.IsNullOrEmpty(customUrl))
                    {
                        config.Write("channel", "Stable", "Update");
                        config.Write("custom_url", "https://undz.cn/aycanvars/release/update.ini", "Update");
                        updateConfigUrl = "https://undz.cn/aycanvars/release/update.ini";
                        isCustom = false;
                    }
                    break;
            }
            iniFile = new IniFile(tempDownloadIniPath);
            log.Info($"temp Download Ini Path: {tempDownloadIniPath}");
            InitializeComponent();
        }
        private void CloseWithError(Exception ex, string error)
        {
            log.Error(ex, error);
            MessageBox.Show($"无法下载更新程序：{error}", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 检查更新（异步，不阻塞 UI）
        /// </summary>
        /// <param name="silent">如果为 true，无可用更新时不提示；有更新时仍会询问用户</param>
        /// <returns>是否有更新</returns>
        public async Task<bool> CheckHasUpdatesAsync(bool silent = false)
        {
            try
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                label.Text =  "正在获取更新信息...";
                Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
                if (currentVersion == null) { return false; }
                string iniContent;
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    iniContent = string.Empty;
                    try
                    {
                        iniContent = await client.DownloadStringTaskAsync(updateConfigUrl);
                        
                    }
                    catch (Exception) when (isCustom)
                    {
                        MessageBox.Show($"自定义更新链接下载地址无效，请检查后重试", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (iniContent == null) { return false; }
                }
                using (StreamWriter sw = new StreamWriter(tempDownloadIniPath))
                { sw.Write(iniContent); }
                label.Text = "解析中...";
                remoteVersionStr = iniFile.Read("version", "update_info");
                downloadUrl = iniFile.Read("download_url", "update_info");
                buildNumber = iniFile.Read("build_number", "update_info");
                releaseDate = iniFile.Read("release_date", "update_info");
                string raw = iniFile.Read("zh-CN", "release_notes");
                byte[] bytes = Encoding.Default.GetBytes(raw);
                string correct = Encoding.UTF8.GetString(bytes);
                releaseNotes = correct.Replace("\\n", "\n");

                if (string.IsNullOrEmpty(remoteVersionStr) || string.IsNullOrEmpty(downloadUrl) || string.IsNullOrEmpty(buildNumber) || string.IsNullOrEmpty(releaseDate) || string.IsNullOrEmpty(releaseNotes))
                {
                    label.Text = "当前已是最新版本，无需更新";
                    progressBar.Visible = false;
                    return false;}

                Version remoteVersion = new Version(remoteVersionStr);

                if (remoteVersion <= currentVersion)
                {label.Text = "当前已是最新版本，无需更新";
                    progressBar.Visible = false; 
                    return false; }

                progressBar.Style = ProgressBarStyle.Continuous;
                label.Text = "可更新";
                DialogResult result = MessageBox.Show($"发现新版本 {remoteVersion}（{buildNumber}）（当前版本 {currentVersion}）\n更新发布时间：{releaseDate}\n更新内容：{releaseNotes}\n\n是否立即下载并安装？", "可更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    
                    UpdateProgress(0, "准备下载...");
                    this.Show();
                    if(await DownloadAndInstall(downloadUrl))
                    {
                        Environment.Exit(0);
                    } else if(isCustom)
                    {
                        MessageBox.Show($"自定义更新链接下载地址无效，请检查后重试", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                    
                } else
                {
                    this.Close();
                }
               
                return true;
            }
            catch (Exception ex)
            {
                if (!silent)
                    MessageBox.Show($"检查更新失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task<bool> DownloadAndInstall(string downloadUrl)
        {
            this.ControlBox = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    // 注册下载进度事件
                    client.DownloadProgressChanged += (sender, e) =>
                    {
                        UpdateProgress(e.ProgressPercentage, $"下载中... {e.ProgressPercentage}%");
                    };

                    client.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error != null)
                        {
                            CloseWithError(e.Error, e.Error.Message);
                        }
                    };

                    await client.DownloadFileTaskAsync(new Uri(downloadUrl), tempDownloadPath);
                }
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempDownloadPath,
                    UseShellExecute = true,
                    Arguments = ""
                };
                System.Diagnostics.Process.Start(psi);
                return true;
                
            }
            catch (Exception ex)
            {
                CloseWithError(ex, ex.Message);
                return false;
            }
        }
        public void UpdateProgress(int percent, string status)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => UpdateProgress(percent, status)));
                return;
            }
            progressBar.Value = percent;
            label.Text = status;
        }

 
    }
}
