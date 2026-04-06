using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyCanvars
{
    public partial class penSetting : Form
    {
        private Point CenPanelLoction;
        private Boolean isCanClose = true;
        private Form1 mainForm;
        public penSetting(Form1 form)
        {
            InitializeComponent();
            mainForm = form;

        }

        public void SetCenPanelLoction(Point CenPanelLoc, int size, Color penColor, Color backColor)
        {
            penSizeSetting.Value = size;
            colorPre.BackColor = penColor;
            backColorPre.BackColor = backColor;
            CenPanelLoction = CenPanelLoc; 
            nowSize.Text = "笔画大小：" + penSizeSetting.Value;
        }

        private void penSetting_Deactivate(object sender, EventArgs e)
        {
            if (isCanClose)
            {
                this.Close();
            }
        }

        private void penSetting_Load(object sender, EventArgs e)
        {
            this.Location = new Point(CenPanelLoction.X, CenPanelLoction.Y - this.Height);
        }

        private void penSizeSetting_Scroll(object sender, EventArgs e)
        {
            nowSize.Text = "笔画大小：" + penSizeSetting.Value;
            mainForm.setPen(Color.White, 0, penSizeSetting.Value);
        }

        private void selColor_Click(object sender, EventArgs e)
        {

            isCanClose = false;
            colorDialog.Color = colorPre.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorPre.BackColor = colorDialog.Color;
                mainForm.setPen(colorDialog.Color, 1);
            }
            isCanClose = true;
        }

        private void setBackColor_Click(object sender, EventArgs e)
        {
            isCanClose = false;
            colorDialog.Color = backColorPre.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show("您确实要继续设置吗？这样将导致页面被清空", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    backColorPre.BackColor = colorDialog.Color;
                    mainForm.setPen(colorDialog.Color, 2);
                }
            }
            isCanClose = true;
        }
    }
}
