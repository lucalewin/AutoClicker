using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lucraft.AutoClicker
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            if (Themes.CurrentTheme().Equals(Theme.Light))
            {
                // Init Light Theme
            }
            else
            {
                // Init Dark Theme
            }
            lblVersion.Text = $"Version {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion?.Split("+")[0]}";
            CenterControlHorizontally(lblTitle);
            CenterControlHorizontally(lblVersion);
            CenterControlHorizontally(linkLabelGithubRepo);
            CenterControlHorizontally(roundedLabelLicense);
        }

        private void CenterControlHorizontally(Control control)
        {
            control.Location = new Point((ClientSize.Width - control.Size.Width) / 2, control.Location.Y);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new(m.LParam.ToInt32());
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
            Hide();
            Owner.Show();
            Dispose();
            Close();
        }

        private void LinkLabelGithubRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelGithubRepo.LinkVisited = true;
            OpenBrowser("http://github.com/lucalewin/AutoClicker");
        }

        private static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
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

        private void RoundedLabelLicense_Click(object sender, EventArgs e)
        {
            //OpenBrowser("http://lucraft.ddns.net/autoclicker/licence");
            OpenBrowser("https://github.com/lucalewin/AutoClicker/blob/develop/LICENSE");
        }
    }
}
