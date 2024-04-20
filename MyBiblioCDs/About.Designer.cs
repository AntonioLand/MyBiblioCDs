namespace MyBiblioCDs
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.ButtonAbout = new System.Windows.Forms.Button();
            this.RTFTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ButtonAbout
            // 
            this.ButtonAbout.Location = new System.Drawing.Point(261, 310);
            this.ButtonAbout.Name = "ButtonAbout";
            this.ButtonAbout.Size = new System.Drawing.Size(75, 23);
            this.ButtonAbout.TabIndex = 0;
            this.ButtonAbout.Text = "OK";
            this.ButtonAbout.UseVisualStyleBackColor = true;
            this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // RTFTxt
            // 
            this.RTFTxt.Location = new System.Drawing.Point(12, 23);
            this.RTFTxt.Name = "RTFTxt";
            this.RTFTxt.Size = new System.Drawing.Size(595, 271);
            this.RTFTxt.TabIndex = 1;
            this.RTFTxt.Text = "";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 335);
            this.Controls.Add(this.RTFTxt);
            this.Controls.Add(this.ButtonAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About MyBiblioCDs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonAbout;
        private System.Windows.Forms.RichTextBox RTFTxt;
    }
}