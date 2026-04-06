namespace AyCanvars
{
    partial class more
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
            this.undo = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.textTool = new System.Windows.Forms.Button();
            this.exportCurrentPage = new System.Windows.Forms.Button();
            this.clearMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // undo
            // 
            this.undo.Location = new System.Drawing.Point(12, 12);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(64, 32);
            this.undo.TabIndex = 0;
            this.undo.TabStop = false;
            this.undo.Text = "撤销";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.undo_MouseDown);
            // 
            // redo
            // 
            this.redo.Location = new System.Drawing.Point(82, 12);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(64, 32);
            this.redo.TabIndex = 1;
            this.redo.TabStop = false;
            this.redo.Text = "恢复";
            this.redo.UseVisualStyleBackColor = true;
            this.redo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.redo_MouseDown);
            // 
            // textTool
            // 
            this.textTool.Location = new System.Drawing.Point(152, 12);
            this.textTool.Name = "textTool";
            this.textTool.Size = new System.Drawing.Size(64, 32);
            this.textTool.TabIndex = 2;
            this.textTool.TabStop = false;
            this.textTool.Text = "文本工具";
            this.textTool.UseVisualStyleBackColor = true;
            this.textTool.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textTool_MouseDown);
            // 
            // exportCurrentPage
            // 
            this.exportCurrentPage.Location = new System.Drawing.Point(222, 12);
            this.exportCurrentPage.Name = "exportCurrentPage";
            this.exportCurrentPage.Size = new System.Drawing.Size(96, 32);
            this.exportCurrentPage.TabIndex = 3;
            this.exportCurrentPage.TabStop = false;
            this.exportCurrentPage.Text = "导出当前页面";
            this.exportCurrentPage.UseVisualStyleBackColor = true;
            this.exportCurrentPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exportCurrentPage_MouseDown);
            // 
            // clearMemory
            // 
            this.clearMemory.Location = new System.Drawing.Point(324, 12);
            this.clearMemory.Name = "clearMemory";
            this.clearMemory.Size = new System.Drawing.Size(64, 32);
            this.clearMemory.TabIndex = 4;
            this.clearMemory.TabStop = false;
            this.clearMemory.Text = "清理内存";
            this.clearMemory.UseVisualStyleBackColor = true;
            this.clearMemory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearMemory_MouseDown);
            // 
            // more
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 283);
            this.Controls.Add(this.clearMemory);
            this.Controls.Add(this.exportCurrentPage);
            this.Controls.Add(this.textTool);
            this.Controls.Add(this.redo);
            this.Controls.Add(this.undo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "more";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "more";
            this.Deactivate += new System.EventHandler(this.More_Deactivate);
            this.Load += new System.EventHandler(this.more_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Button textTool;
        private System.Windows.Forms.Button exportCurrentPage;
        private System.Windows.Forms.Button clearMemory;
    }
}