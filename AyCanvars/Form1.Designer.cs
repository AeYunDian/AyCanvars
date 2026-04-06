namespace AyCanvars
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CenPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mouse_sel_btn = new System.Windows.Forms.PictureBox();
            this.pen_btn = new System.Windows.Forms.PictureBox();
            this.eraser_btn = new System.Windows.Forms.PictureBox();
            this.more_btn = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.eraser = new System.Windows.Forms.PictureBox();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.AlignLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.CenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouse_sel_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pen_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.more_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.AlignLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            this.SuspendLayout();
            // 
            // CenPanel
            // 
            this.CenPanel.ColumnCount = 4;
            this.CenPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93766F));
            this.CenPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93766F));
            this.CenPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93766F));
            this.CenPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.18703F));
            this.CenPanel.Controls.Add(this.mouse_sel_btn, 0, 0);
            this.CenPanel.Controls.Add(this.pen_btn, 1, 0);
            this.CenPanel.Controls.Add(this.eraser_btn, 2, 0);
            this.CenPanel.Controls.Add(this.more_btn, 3, 0);
            this.CenPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CenPanel.Location = new System.Drawing.Point(0, 0);
            this.CenPanel.Name = "CenPanel";
            this.CenPanel.RowCount = 1;
            this.CenPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.CenPanel.Size = new System.Drawing.Size(249, 57);
            this.CenPanel.TabIndex = 1;
            // 
            // mouse_sel_btn
            // 
            this.mouse_sel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mouse_sel_btn.Image = global::AyCanvars.Properties.Resources.mouse_sel_not_activated;
            this.mouse_sel_btn.Location = new System.Drawing.Point(3, 3);
            this.mouse_sel_btn.Name = "mouse_sel_btn";
            this.mouse_sel_btn.Size = new System.Drawing.Size(56, 51);
            this.mouse_sel_btn.TabIndex = 0;
            this.mouse_sel_btn.TabStop = false;
            this.mouse_sel_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouse_sel_btn_MouseDown);
            // 
            // pen_btn
            // 
            this.pen_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pen_btn.Image = global::AyCanvars.Properties.Resources.pen_not_activated;
            this.pen_btn.Location = new System.Drawing.Point(65, 3);
            this.pen_btn.Name = "pen_btn";
            this.pen_btn.Size = new System.Drawing.Size(56, 51);
            this.pen_btn.TabIndex = 1;
            this.pen_btn.TabStop = false;
            this.pen_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pen_btn_MouseDown);
            // 
            // eraser_btn
            // 
            this.eraser_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eraser_btn.Image = global::AyCanvars.Properties.Resources.eraser_not_activated;
            this.eraser_btn.Location = new System.Drawing.Point(127, 3);
            this.eraser_btn.Name = "eraser_btn";
            this.eraser_btn.Size = new System.Drawing.Size(56, 51);
            this.eraser_btn.TabIndex = 2;
            this.eraser_btn.TabStop = false;
            this.eraser_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.eraser_btn_MouseDown);
            // 
            // more_btn
            // 
            this.more_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.more_btn.Image = global::AyCanvars.Properties.Resources.more_not_activated;
            this.more_btn.Location = new System.Drawing.Point(189, 3);
            this.more_btn.Name = "more_btn";
            this.more_btn.Size = new System.Drawing.Size(57, 51);
            this.more_btn.TabIndex = 3;
            this.more_btn.TabStop = false;
            this.more_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.more_btn_MouseDown);
            // 
            // eraser
            // 
            this.eraser.BackColor = System.Drawing.Color.Transparent;
            this.eraser.Image = global::AyCanvars.Properties.Resources.eraser;
            this.eraser.Location = new System.Drawing.Point(0, 63);
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(64, 64);
            this.eraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eraser.TabIndex = 2;
            this.eraser.TabStop = false;
            // 
            // pbCanvas
            // 
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(800, 450);
            this.pbCanvas.TabIndex = 3;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
            // 
            // AlignLeftPanel
            // 
            this.AlignLeftPanel.ColumnCount = 2;
            this.AlignLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.75125F));
            this.AlignLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.24875F));
            this.AlignLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AlignLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AlignLeftPanel.Controls.Add(this.menu, 0, 0);
            this.AlignLeftPanel.Controls.Add(this.exit, 1, 0);
            this.AlignLeftPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AlignLeftPanel.Location = new System.Drawing.Point(3, 133);
            this.AlignLeftPanel.Name = "AlignLeftPanel";
            this.AlignLeftPanel.RowCount = 1;
            this.AlignLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AlignLeftPanel.Size = new System.Drawing.Size(121, 57);
            this.AlignLeftPanel.TabIndex = 4;
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Image = global::AyCanvars.Properties.Resources.menu;
            this.menu.Location = new System.Drawing.Point(3, 3);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(54, 51);
            this.menu.TabIndex = 0;
            this.menu.TabStop = false;
            this.menu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menu_MouseDown);
            // 
            // exit
            // 
            this.exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exit.Image = global::AyCanvars.Properties.Resources.exit;
            this.exit.Location = new System.Drawing.Point(63, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(55, 51);
            this.exit.TabIndex = 3;
            this.exit.TabStop = false;
            this.exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exit_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eraser);
            this.Controls.Add(this.AlignLeftPanel);
            this.Controls.Add(this.CenPanel);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AyCanvars";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.CenPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mouse_sel_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pen_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.more_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.AlignLeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel CenPanel;
        private System.Windows.Forms.PictureBox mouse_sel_btn;
        private System.Windows.Forms.PictureBox pen_btn;
        private System.Windows.Forms.PictureBox eraser_btn;
        private System.Windows.Forms.PictureBox more_btn;
        private System.Windows.Forms.PictureBox eraser;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.TableLayoutPanel AlignLeftPanel;
        private System.Windows.Forms.PictureBox menu;
        private System.Windows.Forms.PictureBox exit;
    }
}

