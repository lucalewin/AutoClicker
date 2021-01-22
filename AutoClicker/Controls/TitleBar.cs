using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    public partial class TitleBar : UserControl
    {
        protected const int WM_NCLBUTTONDOWN = 0xA1;
        protected const int HT_CAPTION = 0x2;

#pragma warning disable CA1401 // P/Invokes should not be visible
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
#pragma warning restore CA1401 // P/Invokes should not be visible

        [Description("Title for the Titlebar"), Category("Appearance")]
        public string Title {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; } 
        }

        public TitleBar()
        {
            InitializeComponent();
            pictureBox1.Size = new Size(Size.Height, Size.Height);
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
            Dispose();
        }
    }
}
