
namespace MyBiblioCDs
{
    partial class VLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLC));
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.trVolume = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bFulscreen = new System.Windows.Forms.Button();
            this.bForw = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoView
            // 
            this.videoView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoView.BackColor = System.Drawing.Color.Black;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(706, 338);
            this.videoView.TabIndex = 0;
            this.videoView.Text = "videoView";
            this.videoView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.videoView_KeyDown);
            // 
            // trVolume
            // 
            this.trVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trVolume.AutoSize = false;
            this.trVolume.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trVolume.LargeChange = 1;
            this.trVolume.Location = new System.Drawing.Point(320, 380);
            this.trVolume.Maximum = 100;
            this.trVolume.Name = "trVolume";
            this.trVolume.Size = new System.Drawing.Size(100, 28);
            this.trVolume.TabIndex = 5;
            this.trVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trVolume.Value = 50;
            this.trVolume.Scroll += new System.EventHandler(this.trVolume_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.videoView);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 338);
            this.panel1.TabIndex = 1;
            // 
            // bFulscreen
            // 
            this.bFulscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bFulscreen.BackColor = System.Drawing.SystemColors.Control;
            this.bFulscreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bFulscreen.BackgroundImage")));
            this.bFulscreen.Location = new System.Drawing.Point(245, 375);
            this.bFulscreen.Name = "bFulscreen";
            this.bFulscreen.Size = new System.Drawing.Size(35, 30);
            this.bFulscreen.TabIndex = 4;
            this.bFulscreen.UseVisualStyleBackColor = false;
            this.bFulscreen.Click += new System.EventHandler(this.bFulscreen_Click);
            // 
            // bForw
            // 
            this.bForw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bForw.Image = global::MyBiblioCDs.Properties.Resources.Forw;
            this.bForw.Location = new System.Drawing.Point(165, 375);
            this.bForw.Name = "bForw";
            this.bForw.Size = new System.Drawing.Size(35, 30);
            this.bForw.TabIndex = 3;
            this.bForw.UseVisualStyleBackColor = true;
            this.bForw.Click += new System.EventHandler(this.bForward_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bStop.Image = global::MyBiblioCDs.Properties.Resources.Stop;
            this.bStop.Location = new System.Drawing.Point(125, 375);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(35, 30);
            this.bStop.TabIndex = 2;
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bBack
            // 
            this.bBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bBack.Image = global::MyBiblioCDs.Properties.Resources.Back;
            this.bBack.Location = new System.Drawing.Point(85, 375);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(35, 30);
            this.bBack.TabIndex = 1;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bStart.Image = global::MyBiblioCDs.Properties.Resources.Pause;
            this.bStart.Location = new System.Drawing.Point(15, 375);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(35, 30);
            this.bStart.TabIndex = 0;
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click_1);
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(624, 375);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 30);
            this.bExit.TabIndex = 6;
            this.bExit.Text = "E&xit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // VLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(733, 416);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trVolume);
            this.Controls.Add(this.bFulscreen);
            this.Controls.Add(this.bForw);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bStart);
            this.Name = "VLC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VLC_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LibVLCSharp.WinForms.VideoView videoView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bForw;
        private System.Windows.Forms.Button bFulscreen;
        private System.Windows.Forms.TrackBar trVolume;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bExit;
    }
}