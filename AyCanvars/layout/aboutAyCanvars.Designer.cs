namespace AyCanvars.layout
{
    partial class aboutAyCanvars
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
            this.AppIcon = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.Label();
            this.yes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AppIcon
            // 
            this.AppIcon.Image = global::AyCanvars.Properties.Resources.app;
            this.AppIcon.Location = new System.Drawing.Point(165, 9);
            this.AppIcon.Name = "AppIcon";
            this.AppIcon.Size = new System.Drawing.Size(36, 36);
            this.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AppIcon.TabIndex = 0;
            this.AppIcon.TabStop = false;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.name.Location = new System.Drawing.Point(207, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(150, 35);
            this.name.TabIndex = 1;
            this.name.Text = "AyCanvars";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(485, 2);
            this.label2.TabIndex = 2;
            // 
            // body
            // 
            this.body.AutoSize = true;
            this.body.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.body.Location = new System.Drawing.Point(41, 82);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(134, 17);
            this.body.TabIndex = 3;
            this.body.Text = "AeYunDian AyCanvars";
            // 
            // yes
            // 
            this.yes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yes.Location = new System.Drawing.Point(422, 384);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(75, 28);
            this.yes.TabIndex = 4;
            this.yes.Text = "确定";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // aboutAyCanvars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 424);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.body);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.AppIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aboutAyCanvars";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于 “AyCanvars”";
            this.Load += new System.EventHandler(this.aboutAyCanvars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AppIcon;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label body;
        private System.Windows.Forms.Button yes;
    }
}