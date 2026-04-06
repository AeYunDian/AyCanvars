namespace AyCanvars.layout
{
    partial class setting
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("常规");
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.welcomePage = new System.Windows.Forms.TabPage();
            this.AppIcon = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.autoSavingCB = new System.Windows.Forms.CheckBox();
            this.startSetting = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.requireAdministratorCB = new System.Windows.Forms.CheckBox();
            this.update = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tip = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.welcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.startSetting.SuspendLayout();
            this.update.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            treeNode1.Name = "regular";
            treeNode1.Text = "常规";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.Size = new System.Drawing.Size(140, 441);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.welcomePage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.startSetting);
            this.tabControl.Controls.Add(this.update);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(140, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(664, 441);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            this.tabControl.TabStop = false;
            // 
            // welcomePage
            // 
            this.welcomePage.Controls.Add(this.AppIcon);
            this.welcomePage.Controls.Add(this.name);
            this.welcomePage.Controls.Add(this.label1);
            this.welcomePage.Location = new System.Drawing.Point(4, 4);
            this.welcomePage.Margin = new System.Windows.Forms.Padding(4);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Padding = new System.Windows.Forms.Padding(4);
            this.welcomePage.Size = new System.Drawing.Size(656, 432);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.UseVisualStyleBackColor = true;
            // 
            // AppIcon
            // 
            this.AppIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AppIcon.Image = global::AyCanvars.Properties.Resources.app;
            this.AppIcon.Location = new System.Drawing.Point(624, 400);
            this.AppIcon.Margin = new System.Windows.Forms.Padding(4);
            this.AppIcon.Name = "AppIcon";
            this.AppIcon.Size = new System.Drawing.Size(32, 32);
            this.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AppIcon.TabIndex = 2;
            this.AppIcon.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.name.Location = new System.Drawing.Point(541, 408);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(84, 20);
            this.name.TabIndex = 3;
            this.name.Text = "AyCanvars";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "请在左侧选择一个项查看";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.autoSavingCB);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(656, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "automaticSaving";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "此选项将使你在更改了笔、画板的属性后，自动存储属性到本地，下次启动时自动使用";
            // 
            // autoSavingCB
            // 
            this.autoSavingCB.AutoSize = true;
            this.autoSavingCB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoSavingCB.Location = new System.Drawing.Point(10, 10);
            this.autoSavingCB.Margin = new System.Windows.Forms.Padding(4);
            this.autoSavingCB.Name = "autoSavingCB";
            this.autoSavingCB.Size = new System.Drawing.Size(99, 21);
            this.autoSavingCB.TabIndex = 0;
            this.autoSavingCB.Text = "启用自动存储";
            this.autoSavingCB.UseVisualStyleBackColor = true;
            this.autoSavingCB.CheckedChanged += new System.EventHandler(this.autoSavingCB_CheckedChanged);
            // 
            // startSetting
            // 
            this.startSetting.Controls.Add(this.label2);
            this.startSetting.Controls.Add(this.requireAdministratorCB);
            this.startSetting.Location = new System.Drawing.Point(4, 4);
            this.startSetting.Name = "startSetting";
            this.startSetting.Padding = new System.Windows.Forms.Padding(3);
            this.startSetting.Size = new System.Drawing.Size(656, 432);
            this.startSetting.TabIndex = 2;
            this.startSetting.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "此选项允许你以管理员身份运行此程序，同时保护你的计算机免受非授权的活动影响\r\n（注意！：取消勾选将导致程序的部分功能无法使用）";
            // 
            // requireAdministratorCB
            // 
            this.requireAdministratorCB.AutoSize = true;
            this.requireAdministratorCB.Location = new System.Drawing.Point(10, 10);
            this.requireAdministratorCB.Name = "requireAdministratorCB";
            this.requireAdministratorCB.Size = new System.Drawing.Size(123, 21);
            this.requireAdministratorCB.TabIndex = 0;
            this.requireAdministratorCB.Text = "用管理员身份运行";
            this.requireAdministratorCB.UseVisualStyleBackColor = true;
            this.requireAdministratorCB.CheckedChanged += new System.EventHandler(this.requireAdministratorCB_CheckedChanged);
            // 
            // update
            // 
            this.update.Controls.Add(this.button2);
            this.update.Controls.Add(this.label7);
            this.update.Controls.Add(this.checkBox1);
            this.update.Controls.Add(this.groupBox1);
            this.update.Location = new System.Drawing.Point(4, 4);
            this.update.Name = "update";
            this.update.Padding = new System.Windows.Forms.Padding(3);
            this.update.Size = new System.Drawing.Size(656, 432);
            this.update.TabIndex = 3;
            this.update.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "立即检查更新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(301, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "*如果自定义链接无效，将会自动回退至正式版链接重试";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 192);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "在启动时检查更新";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新渠道";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Location = new System.Drawing.Point(95, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "https://undz.cn/aycanvars/release/update.ini";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "更新链接：";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(11, 110);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 21);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "自定义";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "包含许多新特性，但稳定性通常没用正式版高";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 21);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "测试版";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "较稳定与可靠，建议选择";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "正式版";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tip.ForeColor = System.Drawing.Color.White;
            this.tip.Location = new System.Drawing.Point(0, 417);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(2, 19);
            this.tip.TabIndex = 1;
            this.tip.Visible = false;
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.treeView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.setting_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.welcomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.startSetting.ResumeLayout(false);
            this.startSetting.PerformLayout();
            this.update.ResumeLayout(false);
            this.update.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage welcomePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox AppIcon;
        private System.Windows.Forms.CheckBox autoSavingCB;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.TabPage startSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox requireAdministratorCB;
        private System.Windows.Forms.TabPage update;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}