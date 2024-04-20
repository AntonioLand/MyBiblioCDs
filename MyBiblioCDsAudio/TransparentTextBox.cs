using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyBiblioCDsAudio
{
    public class TransparentTextBox2 : TextBox
    {
        StringFormat format = null;
        ContentAlignment alignment = ContentAlignment.TopLeft;
        public TransparentTextBox2()
        {
            format = new StringFormat();
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }

        new public ContentAlignment TextAlign
        {
            get { return alignment; }
            set
            {
                alignment = value;
                switch (alignment)
                {
                    case ContentAlignment.TopCenter:
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopLeft:
                        format.Alignment = StringAlignment.Near;
                        format.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopRight:
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Far;
                        break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(ForeColor))
            {
                e.Graphics.DrawString(Text, Font, brush, new Rectangle(0, 0, Width, Height), format);
            }
        }
    }
}
