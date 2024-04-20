using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBiblioCDsAudio
{

    /// <summary>
    /// To color the user control
    /// </summary>
    public class CdPanelGradient : Panel
    {
        public Color TopColor { get; set; }
        public Color BottomColor { get; set; }
        public float Angle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.ForeColor, this.BackColor, 90);
            Graphics gr = e.Graphics;
            gr.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
