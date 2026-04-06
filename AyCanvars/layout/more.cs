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
    public partial class more : Form
    {
        private Point CenPanelLoction;
        private Form1 mainForm;
        private Boolean isCanClose = true;
        public more(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }
        private void More_Deactivate(object sender, EventArgs e)
        {
            if (isCanClose)
            {
                this.Close();
            }
        }
        public void SetCenPanelLoction(Point CenPanelLoc)
        {
            CenPanelLoction = CenPanelLoc;
        }
        private void more_Load(object sender, EventArgs e)
        {
            this.Location = new Point(CenPanelLoction.X, CenPanelLoction.Y - this.Height);
        }

        private void redo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            mainForm.Redo();
        }

        private void undo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            mainForm.Undo(); 
        }

        private void textTool_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            mainForm.cleanAllSelect();
            mainForm.isText = true;
            if (isCanClose)
            {
                this.Close();
            }
        }

        private void exportCurrentPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            mainForm.exportCurrentPage();
            if (isCanClose)
            {
                this.Close();
            }
        }

        private void clearMemory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { return; }
            mainForm.clearMemory();
            if (isCanClose)
            {
                this.Close();
            }
        }
    }
}
