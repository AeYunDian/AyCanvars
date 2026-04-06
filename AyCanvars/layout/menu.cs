using AyCanvars.layout;
using MyIni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AyCanvars.Form1;

namespace AyCanvars
{
    public partial class menu : Form
    {
        private Point AlignLeftPanelLoction;
        private Form1 mainForm;
        private Boolean isCanClose = true;
        private IniFile MyIni = new IniFile();
        public menu(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }
        public void SetAlignLeftPanelLoction(Point AlignLeftPanelLoc)
        {
            AlignLeftPanelLoction = AlignLeftPanelLoc;
        }
        private void menu_Load(object sender, EventArgs e)
        {
            this.Location = new Point(AlignLeftPanelLoction.X, AlignLeftPanelLoction.Y - this.Height);
        }
        private void menu_Deactivate(object sender, EventArgs e)
        {
            closeThis();
        }

        private void aboutLbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            aboutAyCanvars aboutAyCanvars = new aboutAyCanvars();
            isCanClose = false;
            this.Hide();
            aboutAyCanvars.ShowDialog();
            isCanClose = true;
            closeThis();
        }

        private void closeThis()
        {
            if (isCanClose)
            {
                this.Close();
            }
        }

        private void setting_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            setting setting = new setting();
            isCanClose = false;
            this.Hide();
            setting.ShowDialog();
            isCanClose = true;
            closeThis();
        }

        private void update_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            string channelStr = MyIni.Read("channel", "Update");
            UpdateChannel channel = ParseChannel(channelStr);
            string customUrl = MyIni.Read("custom_url", "Update");

            Update update = new Update(channel, customUrl);
            isCanClose = false;
            this.Hide();
            update.Show();
            Task<bool> _ = update.CheckHasUpdatesAsync();
 
            isCanClose = true;
            closeThis();



            



        }
    }
}
