namespace MyLED
{
    partial class Form1
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
            this.myLED1 = new MyLED();
            this.SuspendLayout();
            // 
            // myLED1
            // 
            this.myLED1.BorderWidth = 5;
            this.myLED1.CenterColor = System.Drawing.Color.White;
            this.myLED1.FlashInterval = 500;
            this.myLED1.GapWidth = 5;
            this.myLED1.IsBorder = true;
            this.myLED1.IsFlash = false;
            this.myLED1.IsHighLight = true;
            this.myLED1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.Green,
        System.Drawing.Color.Yellow};
            this.myLED1.LedColor = System.Drawing.Color.Green;
            this.myLED1.LedFalseColor = System.Drawing.Color.Red;
            this.myLED1.LedStatus = true;
            this.myLED1.LedTrueColor = System.Drawing.Color.Green;
            this.myLED1.Location = new System.Drawing.Point(39, 30);
            this.myLED1.Name = "myLED1";
            this.myLED1.Size = new System.Drawing.Size(188, 178);
            this.myLED1.TabIndex = 0;
            this.myLED1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myLED1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.myLED1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyLED myLED1;
    }
}