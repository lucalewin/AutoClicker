using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lucraft.AutoClicker.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TitleBar : UserControl
    {
        protected const int WM_NCLBUTTONDOWN = 0xA1;
        protected const int HT_CAPTION = 0x2;

#pragma warning disable CA1401 // P/Invokes should not be visible
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
#pragma warning restore CA1401 // P/Invokes should not be visible

        /// <summary>
        /// 
        /// </summary>
        [Description("Title for the Titlebar"), Category("Appearance")]
        public string Title {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; } 
        }

        /// <summary>
        /// 
        /// </summary>
        public TitleBar()
        {
            InitializeComponent();
            //pictureBox1.Size = new Size(Size.Height, Size.Height);
            lblTitle.ForeColor = ForeColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseImg_Click(object sender, EventArgs e) => Parent.Dispose();
    }
}
