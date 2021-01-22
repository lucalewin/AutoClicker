using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    public class RoundedLabel : Label
    {
        [Browsable(true)]
        [Description("Test text displayed in the textbox"), Category("Appearance")]
        public Color BackgroundColor { get; set; }

        private int cornerRadius;

        [Description("Test text displayed in the textbox"), Category("Data")]
        public int CornerRadius {
            get { return cornerRadius; }
            set {
                if (value > Height)
                    cornerRadius = Height;
                else
                    cornerRadius = value;
            } 
        }

        public RoundedLabel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var graphicsPath = GetRoundRectangle(this.ClientRectangle);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(BackgroundColor))
                e.Graphics.FillPath(brush, graphicsPath);
            using (var pen = new Pen(BackgroundColor, 1.0f))
                e.Graphics.DrawPath(pen, graphicsPath);
            TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
        }

        private GraphicsPath GetRoundRectangle(Rectangle rectangle)
        {
            //int CornerRadius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new();
            path.AddArc(rectangle.X, rectangle.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
