namespace MyBiblioCDsAudio
{
    partial class editCover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editCover));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.nameTxtBx = new System.Windows.Forms.TextBox();
            this.sizeXtxtBx = new System.Windows.Forms.TextBox();
            this.sizeYtxtBx = new System.Windows.Forms.TextBox();
            this.filetxtBx = new System.Windows.Forms.TextBox();
            this.OKbtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(210, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Size Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Size X:";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Location = new System.Drawing.Point(12, 32);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(35, 13);
            this.lb1.TabIndex = 4;
            this.lb1.Text = "Name";
            // 
            // nameTxtBx
            // 
            this.nameTxtBx.Location = new System.Drawing.Point(60, 28);
            this.nameTxtBx.Name = "nameTxtBx";
            this.nameTxtBx.Size = new System.Drawing.Size(275, 20);
            this.nameTxtBx.TabIndex = 8;
            // 
            // sizeXtxtBx
            // 
            this.sizeXtxtBx.Location = new System.Drawing.Point(70, 82);
            this.sizeXtxtBx.Name = "sizeXtxtBx";
            this.sizeXtxtBx.Size = new System.Drawing.Size(50, 20);
            this.sizeXtxtBx.TabIndex = 9;
            // 
            // sizeYtxtBx
            // 
            this.sizeYtxtBx.Location = new System.Drawing.Point(265, 82);
            this.sizeYtxtBx.Name = "sizeYtxtBx";
            this.sizeYtxtBx.Size = new System.Drawing.Size(50, 20);
            this.sizeYtxtBx.TabIndex = 10;
            // 
            // filetxtBx
            // 
            this.filetxtBx.Location = new System.Drawing.Point(60, 135);
            this.filetxtBx.Name = "filetxtBx";
            this.filetxtBx.Size = new System.Drawing.Size(275, 20);
            this.filetxtBx.TabIndex = 11;
            // 
            // OKbtn
            // 
            this.OKbtn.Location = new System.Drawing.Point(60, 210);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(50, 22);
            this.OKbtn.TabIndex = 12;
            this.OKbtn.Text = "&OK";
            this.OKbtn.UseVisualStyleBackColor = true;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(275, 213);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(50, 22);
            this.CancelBtn.TabIndex = 13;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // editCover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::MyBiblioCDsAudio.Properties.Resources.CD_4;
            this.ClientSize = new System.Drawing.Size(370, 253);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKbtn);
            this.Controls.Add(this.filetxtBx);
            this.Controls.Add(this.sizeYtxtBx);
            this.Controls.Add(this.sizeXtxtBx);
            this.Controls.Add(this.nameTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "editCover";
            this.Text = "Edit Info Cover";
            this.Load += new System.EventHandler(this.editCover_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox nameTxtBx;
        private System.Windows.Forms.TextBox sizeXtxtBx;
        private System.Windows.Forms.TextBox sizeYtxtBx;
        private System.Windows.Forms.TextBox filetxtBx;
        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}