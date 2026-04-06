using System;
using System.Reflection;
using System.Windows.Forms;

namespace AyCanvars.layout
{
    public partial class aboutAyCanvars : Form
    {
        public aboutAyCanvars()
        {
            InitializeComponent();
            yes.DialogResult = DialogResult.OK;
        }

        private void aboutAyCanvars_Load(object sender, EventArgs e)
        {
            body.Text = "AeYunDian AyCanvars" + "\n" +
                "版本： " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n" +
                "© 2025-2026 韵典 (AeYunDian) 又名 undz, Yund, YunDian。 保留所有权利。" + "\n\n" +
                "AyCanvars 软件受中国的软件著作权和其他待颁布或已颁布的知识产权保护法保护。"+ "\n\n\n\n"+
                "根据 AyCanvars开源条款 ， 许可如下用户使用本产品：\n\n" + Environment.UserName;
        }
    }

 
 }
