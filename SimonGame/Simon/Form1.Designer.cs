namespace Simon2
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
            this.myLED_R = new MyLED.MyLED();
            this.myLED_G = new MyLED.MyLED();
            this.myLED_B = new MyLED.MyLED();
            this.myLED_Y = new MyLED.MyLED();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_ReStar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // myLED_R
            // 
            this.myLED_R.BorderWidth = 5;
            this.myLED_R.CenterColor = System.Drawing.Color.White;
            this.myLED_R.FlashInterval = 500;
            this.myLED_R.GapWidth = 5;
            this.myLED_R.IsBorder = true;
            this.myLED_R.IsFlash = false;
            this.myLED_R.IsHighLight = true;
            this.myLED_R.LampColor = new System.Drawing.Color[0];
            this.myLED_R.LedColor = System.Drawing.Color.Red;
            this.myLED_R.LedFalseColor = System.Drawing.Color.White;
            this.myLED_R.LedStatus = true;
            this.myLED_R.LedTrueColor = System.Drawing.Color.Red;
            this.myLED_R.Location = new System.Drawing.Point(114, 98);
            this.myLED_R.Name = "myLED_R";
            this.myLED_R.Size = new System.Drawing.Size(150, 150);
            this.myLED_R.TabIndex = 0;
            this.myLED_R.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myLED_R_MouseClick);
            // 
            // myLED_G
            // 
            this.myLED_G.BorderWidth = 5;
            this.myLED_G.CenterColor = System.Drawing.Color.White;
            this.myLED_G.FlashInterval = 500;
            this.myLED_G.GapWidth = 5;
            this.myLED_G.IsBorder = true;
            this.myLED_G.IsFlash = false;
            this.myLED_G.IsHighLight = true;
            this.myLED_G.LampColor = new System.Drawing.Color[0];
            this.myLED_G.LedColor = System.Drawing.Color.Green;
            this.myLED_G.LedFalseColor = System.Drawing.Color.White;
            this.myLED_G.LedStatus = true;
            this.myLED_G.LedTrueColor = System.Drawing.Color.Green;
            this.myLED_G.Location = new System.Drawing.Point(325, 98);
            this.myLED_G.Name = "myLED_G";
            this.myLED_G.Size = new System.Drawing.Size(150, 150);
            this.myLED_G.TabIndex = 1;
            this.myLED_G.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myLED_G_MouseClick);
            // 
            // myLED_B
            // 
            this.myLED_B.BorderWidth = 5;
            this.myLED_B.CenterColor = System.Drawing.Color.White;
            this.myLED_B.FlashInterval = 500;
            this.myLED_B.GapWidth = 5;
            this.myLED_B.IsBorder = true;
            this.myLED_B.IsFlash = false;
            this.myLED_B.IsHighLight = true;
            this.myLED_B.LampColor = new System.Drawing.Color[0];
            this.myLED_B.LedColor = System.Drawing.Color.Aqua;
            this.myLED_B.LedFalseColor = System.Drawing.Color.White;
            this.myLED_B.LedStatus = true;
            this.myLED_B.LedTrueColor = System.Drawing.Color.Cyan;
            this.myLED_B.Location = new System.Drawing.Point(114, 254);
            this.myLED_B.Name = "myLED_B";
            this.myLED_B.Size = new System.Drawing.Size(150, 150);
            this.myLED_B.TabIndex = 2;
            this.myLED_B.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myLED_B_MouseClick);
            // 
            // myLED_Y
            // 
            this.myLED_Y.BorderWidth = 5;
            this.myLED_Y.CenterColor = System.Drawing.Color.White;
            this.myLED_Y.FlashInterval = 500;
            this.myLED_Y.GapWidth = 5;
            this.myLED_Y.IsBorder = true;
            this.myLED_Y.IsFlash = false;
            this.myLED_Y.IsHighLight = true;
            this.myLED_Y.LampColor = new System.Drawing.Color[0];
            this.myLED_Y.LedColor = System.Drawing.Color.Yellow;
            this.myLED_Y.LedFalseColor = System.Drawing.Color.White;
            this.myLED_Y.LedStatus = true;
            this.myLED_Y.LedTrueColor = System.Drawing.Color.Yellow;
            this.myLED_Y.Location = new System.Drawing.Point(325, 254);
            this.myLED_Y.Name = "myLED_Y";
            this.myLED_Y.Size = new System.Drawing.Size(150, 150);
            this.myLED_Y.TabIndex = 3;
            this.myLED_Y.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myLED_Y_MouseClick);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(136, 431);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(116, 39);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_ReStar
            // 
            this.button_ReStar.Location = new System.Drawing.Point(325, 431);
            this.button_ReStar.Name = "button_ReStar";
            this.button_ReStar.Size = new System.Drawing.Size(116, 39);
            this.button_ReStar.TabIndex = 5;
            this.button_ReStar.Text = "ReStar";
            this.button_ReStar.UseVisualStyleBackColor = true;
            this.button_ReStar.Click += new System.EventHandler(this.button_ReStar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(247, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 528);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_ReStar);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.myLED_Y);
            this.Controls.Add(this.myLED_B);
            this.Controls.Add(this.myLED_G);
            this.Controls.Add(this.myLED_R);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLED.MyLED myLED_R;
        private MyLED.MyLED myLED_G;
        private MyLED.MyLED myLED_B;
        private MyLED.MyLED myLED_Y;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_ReStar;
        private System.Windows.Forms.TextBox textBox1;
    }
}

