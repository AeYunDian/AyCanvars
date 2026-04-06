namespace AyCanvars
{
    partial class penSetting
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
            this.penSizeSetting = new System.Windows.Forms.TrackBar();
            this.penSizeSetting_label = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.selColor = new System.Windows.Forms.Button();
            this.nowSize = new System.Windows.Forms.Label();
            this.setBackColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.backColorPre = new System.Windows.Forms.PictureBox();
            this.colorPre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPre)).BeginInit();
            this.SuspendLayout();
            // 
            // penSizeSetting
            // 
            this.penSizeSetting.Location = new System.Drawing.Point(83, 12);
            this.penSizeSetting.Maximum = 100;
            this.penSizeSetting.Minimum = 1;
            this.penSizeSetting.Name = "penSizeSetting";
            this.penSizeSetting.Size = new System.Drawing.Size(285, 45);
            this.penSizeSetting.TabIndex = 0;
            this.penSizeSetting.Value = 1;
            this.penSizeSetting.Scroll += new System.EventHandler(this.penSizeSetting_Scroll);
            // 
            // penSizeSetting_label
            // 
            this.penSizeSetting_label.AutoSize = true;
            this.penSizeSetting_label.Font = new System.Drawing.Font("宋体", 10F);
            this.penSizeSetting_label.Location = new System.Drawing.Point(3, 21);
            this.penSizeSetting_label.Name = "penSizeSetting_label";
            this.penSizeSetting_label.Size = new System.Drawing.Size(392, 14);
            this.penSizeSetting_label.TabIndex = 1;
            this.penSizeSetting_label.Text = "笔画大小：1                                         100";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前笔画颜色：";
            // 
            // selColor
            // 
            this.selColor.Location = new System.Drawing.Point(83, 80);
            this.selColor.Name = "selColor";
            this.selColor.Size = new System.Drawing.Size(64, 49);
            this.selColor.TabIndex = 4;
            this.selColor.Text = "选择颜色";
            this.selColor.UseVisualStyleBackColor = true;
            this.selColor.Click += new System.EventHandler(this.selColor_Click);
            // 
            // nowSize
            // 
            this.nowSize.AutoSize = true;
            this.nowSize.Font = new System.Drawing.Font("宋体", 10F);
            this.nowSize.Location = new System.Drawing.Point(283, 178);
            this.nowSize.Name = "nowSize";
            this.nowSize.Size = new System.Drawing.Size(77, 14);
            this.nowSize.TabIndex = 5;
            this.nowSize.Text = "笔画大小：";
            // 
            // setBackColor
            // 
            this.setBackColor.Location = new System.Drawing.Point(240, 80);
            this.setBackColor.Name = "setBackColor";
            this.setBackColor.Size = new System.Drawing.Size(64, 49);
            this.setBackColor.TabIndex = 8;
            this.setBackColor.Text = "选择颜色";
            this.setBackColor.UseVisualStyleBackColor = true;
            this.setBackColor.Click += new System.EventHandler(this.setBackColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(160, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "当前背景颜色：";
            // 
            // backColorPre
            // 
            this.backColorPre.BackColor = System.Drawing.Color.Transparent;
            this.backColorPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backColorPre.Location = new System.Drawing.Point(163, 80);
            this.backColorPre.Name = "backColorPre";
            this.backColorPre.Size = new System.Drawing.Size(64, 64);
            this.backColorPre.TabIndex = 6;
            this.backColorPre.TabStop = false;
            // 
            // colorPre
            // 
            this.colorPre.BackColor = System.Drawing.Color.Transparent;
            this.colorPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPre.Location = new System.Drawing.Point(6, 80);
            this.colorPre.Name = "colorPre";
            this.colorPre.Size = new System.Drawing.Size(64, 64);
            this.colorPre.TabIndex = 2;
            this.colorPre.TabStop = false;
            // 
            // penSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 201);
            this.Controls.Add(this.setBackColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backColorPre);
            this.Controls.Add(this.nowSize);
            this.Controls.Add(this.selColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorPre);
            this.Controls.Add(this.penSizeSetting);
            this.Controls.Add(this.penSizeSetting_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "penSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Deactivate += new System.EventHandler(this.penSetting_Deactivate);
            this.Load += new System.EventHandler(this.penSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.penSizeSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backColorPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar penSizeSetting;
        private System.Windows.Forms.Label penSizeSetting_label;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox colorPre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selColor;
        private System.Windows.Forms.Label nowSize;
        private System.Windows.Forms.Button setBackColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox backColorPre;
    }
}