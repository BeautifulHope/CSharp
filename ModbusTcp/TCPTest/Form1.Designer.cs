﻿namespace TCPTest
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
            this.RecvText1 = new System.Windows.Forms.RichTextBox();
            this.RecvText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RecvText1
            // 
            this.RecvText1.Location = new System.Drawing.Point(12, 12);
            this.RecvText1.Name = "RecvText1";
            this.RecvText1.Size = new System.Drawing.Size(384, 449);
            this.RecvText1.TabIndex = 0;
            this.RecvText1.Text = "";
            // 
            // RecvText
            // 
            this.RecvText.Location = new System.Drawing.Point(437, 23);
            this.RecvText.Multiline = true;
            this.RecvText.Name = "RecvText";
            this.RecvText.Size = new System.Drawing.Size(389, 415);
            this.RecvText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 608);
            this.Controls.Add(this.RecvText);
            this.Controls.Add(this.RecvText1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RecvText1;
        private System.Windows.Forms.TextBox RecvText;
    }
}

