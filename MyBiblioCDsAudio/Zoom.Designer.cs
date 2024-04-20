namespace MyBiblioCDsAudio
{
    partial class Zoom
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
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTxtBx = new MyBiblioCDsAudio.TransparentTextBox2();
            this.ImgPicBx = new System.Windows.Forms.PictureBox();
            this.zoomout = new System.Windows.Forms.Button();
            this.zoomin = new System.Windows.Forms.Button();
            this.zoomSlider = new System.Windows.Forms.TrackBar();
            this.OkBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filename";
            // 
            // FileNameTxtBx
            // 
            this.FileNameTxtBx.BackColor = System.Drawing.Color.Transparent;
            this.FileNameTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNameTxtBx.Location = new System.Drawing.Point(60, 3);
            this.FileNameTxtBx.Name = "FileNameTxtBx";
            this.FileNameTxtBx.ReadOnly = true;
            this.FileNameTxtBx.Size = new System.Drawing.Size(476, 20);
            this.FileNameTxtBx.TabIndex = 2;
            this.FileNameTxtBx.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ImgPicBx
            // 
            this.ImgPicBx.BackColor = System.Drawing.Color.Transparent;
            this.ImgPicBx.Location = new System.Drawing.Point(10, 31);
            this.ImgPicBx.Name = "ImgPicBx";
            this.ImgPicBx.Size = new System.Drawing.Size(550, 500);
            this.ImgPicBx.TabIndex = 3;
            this.ImgPicBx.TabStop = false;
            this.ImgPicBx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgPicBx_MouseDown);
            this.ImgPicBx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImgPicBx_MouseMove);
            this.ImgPicBx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgPicBx_MouseUp);
            // 
            // zoomout
            // 
            this.zoomout.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.zoomout.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.zoomout.FlatAppearance.BorderSize = 0;
            this.zoomout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomout.Image = global::MyBiblioCDsAudio.Properties.Resources.zoomout;
            this.zoomout.Location = new System.Drawing.Point(6, 541);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(19, 21);
            this.zoomout.TabIndex = 13;
            this.zoomout.UseVisualStyleBackColor = false;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // zoomin
            // 
            this.zoomin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.zoomin.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.zoomin.FlatAppearance.BorderSize = 0;
            this.zoomin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomin.Image = global::MyBiblioCDsAudio.Properties.Resources.zoomin;
            this.zoomin.Location = new System.Drawing.Point(434, 541);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(19, 21);
            this.zoomin.TabIndex = 14;
            this.zoomin.UseVisualStyleBackColor = false;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // zoomSlider
            // 
            this.zoomSlider.AutoSize = false;
            this.zoomSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.zoomSlider.Location = new System.Drawing.Point(40, 542);
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zoomSlider.Size = new System.Drawing.Size(379, 20);
            this.zoomSlider.TabIndex = 15;
            this.zoomSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zoomSlider.Scroll += new System.EventHandler(this.zoomSlider_Scroll);
            this.zoomSlider.ValueChanged += new System.EventHandler(this.zoomSlider_ValueChanged);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(493, 542);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(60, 24);
            this.OkBtn.TabIndex = 16;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyBiblioCDsAudio.Properties.Resources.CD_4;
            this.ClientSize = new System.Drawing.Size(570, 591);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.zoomSlider);
            this.Controls.Add(this.zoomin);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.ImgPicBx);
            this.Controls.Add(this.FileNameTxtBx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Zoom";
            this.ShowIcon = false;
            this.Text = "Zoom";
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TransparentTextBox2 FileNameTxtBx;
        private System.Windows.Forms.PictureBox ImgPicBx;
        private System.Windows.Forms.Button zoomout;
        private System.Windows.Forms.Button zoomin;
        public System.Windows.Forms.TrackBar zoomSlider;
        private System.Windows.Forms.Button OkBtn;
    }
}