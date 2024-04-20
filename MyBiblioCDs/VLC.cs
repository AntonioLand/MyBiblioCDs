using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace MyBiblioCDs
{
    /// <summary>
    /// manages VLC form
    /// </summary>
    public partial class VLC : Form
    {
        /// <summary>
        /// ClosedEventHandler
        /// </summary>
        public delegate void ClosedEventHandler();
        /// <summary>
        /// SHAKESPEARE'SCHES DILEMMA
        /// </summary>
        public event ClosedEventHandler IsClosedOrNotClosed;
        /// <summary>
        /// Declare libVLC
        /// </summary>
        public LibVLC libVLC;
        /// <summary>
        /// Declare MediaPlayer
        /// </summary>
        public MediaPlayer mediapl;
        /// <summary>
        /// action on media
        /// </summary>
        public Media opmedia;
        bool fulscr;
        string toplay;
        bool statuOnOff = false;
        Size video;
        Point locationVideo;
        Size wndform;
        /// <summary>
        /// Initialize the form containing VLC
        /// </summary>
        /// <param name="filetoplay">Files to load and Play</param>
        public VLC(string filetoplay)
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();
            libVLC = new LibVLC();
            mediapl = new MediaPlayer(libVLC);
            videoView.MediaPlayer = mediapl;
            fulscr = false;
            toplay = filetoplay;
            video = videoView.Size;
            locationVideo = videoView.Location;
            wndform = this.Size;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(KeyboardEvent);
            this.MouseDoubleClick += new MouseEventHandler(videoView_DoubleClick);

        }

        private void bStart_Click(object sender, EventArgs e)
        {
            
            mediapl.Volume = 90;
            mediapl.Play(new Media(libVLC, toplay));
            statuOnOff = true;
        }
        /// <summary>
        /// Opens the vlc window
        /// </summary>
        /// <param name="filetoplay">File to Plaz</param>
        public void playnow(string filetoplay)
        {
            mediapl.Play(new Media(libVLC, filetoplay));
            statuOnOff = true;
        }
        private void bPause_Click(object sender, EventArgs e)
        {
            if (mediapl.State == VLCState.Playing)
            {
                mediapl.Pause();
            }
            else
            {
                mediapl.Play();
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            bStart.Image.Dispose();
            bStart.Image = Image.FromFile(@".\Resources\Start.png");
            mediapl.Stop();
        }

        private void trVolume_Scroll(object sender, EventArgs e)
        {
             videoView.MediaPlayer.Volume = trVolume.Value;
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            mediapl.Position -= 0.01f;
        }

        private void bForward_Click(object sender, EventArgs e)
        {
            mediapl.Position += 0.01f;
        }

        private void videoView_DoubleClick(object sender, EventArgs e)
        {
            if (!fulscr)
            {
                videoView.Size = this.Size;
                locationVideo = panel1.Location;
                videoView.Location = new Point(0, 0);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fulscr = true;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Size = wndform;
                videoView.Size = video;
                videoView.Location = locationVideo;
                fulscr = false;
            }
        }

        /// <summary>
        /// handles keyboard events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyboardEvent(object sender, KeyEventArgs e)
         {
            if (e.KeyCode == Keys.Escape && fulscr)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Size = wndform;
                videoView.Size = video;
                videoView.Location = locationVideo;
                fulscr = false;
            }
         }
        private void bStart_Click_1(object sender, EventArgs e)
        {
            if (statuOnOff)
            {
                if (mediapl.State == VLCState.Playing)
                {
                    mediapl.Pause();
                    bStart.Image.Dispose();
                    bStart.Image = Image.FromFile(@".\Resources\Start.png");
                }
                else
                {
                    bStart.Image.Dispose();
                    bStart.Image = Image.FromFile(@".\Resources\Pause.png");
                    mediapl.Play();
                }
            }
        }
        private void videoView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && fulscr)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Size = wndform;
                videoView.Size = video;
                videoView.Location = locationVideo;
                fulscr = false;
            }
        }

        private void bFulscreen_Click(object sender, EventArgs e)
        {
            videoView_DoubleClick(sender, e);
        }

        private void VLC_FormClosed(object sender, FormClosedEventArgs e)
        {
            _closeVLC();
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            _closeVLC();
        }
        /// <summary>
        /// Closes the vlc window
        /// </summary>
        public void _closeVLC()
        {
            IsClosedOrNotClosed();
            mediapl.Dispose();
            mediapl = null;
            libVLC.Dispose();
            libVLC = null;
            this.Dispose();

        }
    }
}
