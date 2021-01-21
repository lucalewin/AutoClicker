using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            lblVersion.Text = $"Version {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion?.Split("+")[0]}";
            lblCopyright.Text = "© 2021 Luca Lewin. \nAll Rights Reserved";
            lblTitle.Location = new Point((ClientSize.Width - lblTitle.Size.Width) / 2, lblTitle.Location.Y);
            lblVersion.Location = new Point((ClientSize.Width - lblVersion.Size.Width) / 2, lblVersion.Location.Y);
            linkLabel1.Location = new Point((ClientSize.Width - linkLabel1.Size.Width) / 2, linkLabel1.Location.Y);
            lblCopyright.Location = new Point((ClientSize.Width - lblCopyright.Size.Width) / 2, lblCopyright.Location.Y);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.Y < ClientSize.Height)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            OpenBrowser("http://github.com/lucalewin/AutoClicker");
        }

        private static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $" /c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }
    }
}
