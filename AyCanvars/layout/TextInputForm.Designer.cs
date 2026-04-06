namespace AyCanvars
{
    partial class TextInputForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.preFont = new System.Windows.Forms.Label();
            this.setFont = new System.Windows.Forms.Button();
            this.setColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorPre = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.yes = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.colorPre)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 124);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 260);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "添加文本：";
            // 
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.Color.White;
            this.fontDialog.ShowApply = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "字体：";
            // 
            // preFont
            // 
            this.preFont.AutoSize = true;
            this.preFont.Location = new System.Drawing.Point(150, 57);
            this.preFont.Name = "preFont";
            this.preFont.Size = new System.Drawing.Size(77, 12);
            this.preFont.TabIndex = 3;
            this.preFont.Text = "微软雅黑, 24";
            // 
            // setFont
            // 
            this.setFont.Location = new System.Drawing.Point(152, 92);
            this.setFont.Name = "setFont";
            this.setFont.Size = new System.Drawing.Size(75, 26);
            this.setFont.TabIndex = 4;
            this.setFont.Text = "设置字体";
            this.setFont.UseVisualStyleBackColor = true;
            this.setFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setFont_MouseDown);
            // 
            // setColor
            // 
            this.setColor.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setColor.Location = new System.Drawing.Point(16, 92);
            this.setColor.Name = "setColor";
            this.setColor.Size = new System.Drawing.Size(75, 26);
            this.setColor.TabIndex = 5;
            this.setColor.Text = "设置颜色";
            this.setColor.UseVisualStyleBackColor = true;
            this.setColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setColor_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "颜色：";
            // 
            // colorPre
            // 
            this.colorPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPre.Location = new System.Drawing.Point(51, 36);
            this.colorPre.Name = "colorPre";
            this.colorPre.Size = new System.Drawing.Size(50, 50);
            this.colorPre.TabIndex = 7;
            this.colorPre.TabStop = false;
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.White;
            this.colorDialog.FullOpen = true;
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(281, 390);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(75, 23);
            this.yes.TabIndex = 8;
            this.yes.Text = "确认";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yes_MouseDown);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(371, 390);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.preFont);
            this.panel1.Controls.Add(this.setFont);
            this.panel1.Controls.Add(this.setColor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.colorPre);
            this.panel1.Controls.Add(this.yes);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 425);
            this.panel1.TabIndex = 10;
            // 
            // TextInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 425);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TextInputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInputForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TextInputForm_FormClosed);
            this.Load += new System.EventHandler(this.TextInputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colorPre)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label preFont;
        private System.Windows.Forms.Button setFont;
        private System.Windows.Forms.Button setColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox colorPre;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Panel panel1;
    }
}