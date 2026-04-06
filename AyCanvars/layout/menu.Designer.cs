namespace AyCanvars
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.aboutLbl = new System.Windows.Forms.Label();
            this.setting = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.aboutLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.setting, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.update, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(223, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // aboutLbl
            // 
            this.aboutLbl.AutoSize = true;
            this.aboutLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutLbl.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aboutLbl.Location = new System.Drawing.Point(4, 99);
            this.aboutLbl.Name = "aboutLbl";
            this.aboutLbl.Size = new System.Drawing.Size(215, 50);
            this.aboutLbl.TabIndex = 0;
            this.aboutLbl.Text = "关于 AyCanvars";
            this.aboutLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aboutLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.aboutLbl_MouseDown);
            // 
            // setting
            // 
            this.setting.AutoSize = true;
            this.setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setting.Location = new System.Drawing.Point(4, 50);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(215, 48);
            this.setting.TabIndex = 1;
            this.setting.Text = "设置";
            this.setting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setting_MouseDown);
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.update.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.update.Location = new System.Drawing.Point(4, 1);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(215, 48);
            this.update.TabIndex = 2;
            this.update.Text = "检测更新";
            this.update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update.MouseDown += new System.Windows.Forms.MouseEventHandler(this.update_MouseDown);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "menu";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Deactivate += new System.EventHandler(this.menu_Deactivate);
            this.Load += new System.EventHandler(this.menu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label aboutLbl;
        private System.Windows.Forms.Label setting;
        private System.Windows.Forms.Label update;
    }
}