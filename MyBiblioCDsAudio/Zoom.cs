using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBiblioCDsAudio
{
    public partial class Zoom : Form
    {
        Image imgOriginal;
        string FileImg;
        private bool tomove = false;
        private Point startpoint = new Point(0, 0);

        public Zoom(string ImgFile)
        {
            InitializeComponent();
            zoomSlider.Minimum = -64;
            zoomSlider.Maximum = 15;
            zoomSlider.Value = 0;
            zoomSlider.SmallChange = 1;
            zoomSlider.LargeChange = 1;
            zoomSlider.UseWaitCursor = false;
            zoomSlider.ValueChanged += new System.EventHandler(zoomSlider_ValueChanged);
            FileImg = ImgFile;
            ImgPicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            imgOriginal = Image.FromFile(FileImg);
            this.ImgPicBx.Image = imgOriginal;
            ImgPicBx.BackgroundImageLayout = ImageLayout.Stretch;
            FileNameTxtBx.Text = FileImg;
        }

        public void resize(Image imageFile, double scaleFactor)
        {
            var newWidth = (int)(imageFile.Width * scaleFactor);
            var newHeight = (int)(imageFile.Height * scaleFactor);
            using (var newImage = new Bitmap(newWidth, newHeight))
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(imageFile, new Rectangle(0, 0, newWidth, newHeight));
                ImgPicBx.Image = newImage;
                ImgPicBx.Update();
            }
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            if (zoomSlider.Value > zoomSlider.Minimum)
                zoomSlider.Value--;
        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            if (zoomSlider.Value < zoomSlider.Maximum)
                zoomSlider.Value++;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void zoomSlider_ValueChanged(object sender, EventArgs e)
        {
            zoomSlider_Scroll(sender, e);
        }

        private void zoomSlider_Scroll(object sender, EventArgs e)
        {
            if (zoomSlider.Value == 0)
                resize(imgOriginal, 1);
            else if (zoomSlider.Value >= 1)
                resize(imgOriginal, zoomSlider.Value + 0.5);
            else
            {
                resize(imgOriginal, (double)-1 / zoomSlider.Value);
            }
        }

        private void ImgPicBx_MouseDown(object sender, MouseEventArgs e)
        {
            tomove = true;
            startpoint = new Point(e.X, e.Y);
        }

        private void ImgPicBx_MouseUp(object sender, MouseEventArgs e)
        {
            tomove = false;
        }

        private void ImgPicBx_MouseMove(object sender, MouseEventArgs e)
        {
            if (tomove)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }
    }
}
