using AutoClicker.Hooks;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        private readonly MouseHook mouseHook = new();
        private readonly KeyboardHook keyHook = new();

        #region SimulateClick
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming Styles
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1401 // P/Invokes should not be visible
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public static void PerformLeftClick(int xpos, int ypos)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            //mouseLeftCount++;
        }
        public static void PerformRightClick(int xpos, int ypos)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, xpos, ypos, 0, 0);
            //mouseRightCount++;
        }
        #endregion

        private new void MouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            mouseX = mouseStruct.pt.x;
            mouseY = mouseStruct.pt.y;
        }
        int mouseX;
        int mouseY;

        bool leftDown = false;
        bool rightDown = false;

        private int delayBetweenClicks = 100;

        public Form1()
        {
            InitializeComponent();
            titleBar1.Title = $"Lucraft.AutoClicker v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion?.Split("+")[0]}"; ;

            UpdateCPS();

            backgroundWorker1.RunWorkerAsync();

            mouseHook.MouseMove += new MouseHook.MouseHookCallback(MouseMove);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(LeftMouseDown);
            mouseHook.LeftButtonUp += new MouseHook.MouseHookCallback(LeftMouseUp);
            mouseHook.RightButtonDown += new MouseHook.MouseHookCallback(RightMouseDown);
            mouseHook.RightButtonUp += new MouseHook.MouseHookCallback(RightMouseUp);
            keyHook.KeyUp += new KeyboardHook.KeyboardHookCallback(KeyUp);
            mouseHook.Install();
            keyHook.Install();
        }

        private new void KeyUp(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.OEM_102)
                checkBoxEnable.Checked = !checkBoxEnable.Checked;
        }

        private void RightMouseDown(MouseHook.MSLLHOOKSTRUCT mouseStruct) => rightDown = true;

        private void RightMouseUp(MouseHook.MSLLHOOKSTRUCT mouseStruct) => rightDown = false;

        private void LeftMouseUp(MouseHook.MSLLHOOKSTRUCT mouseStruct) => leftDown = false;

        private void LeftMouseDown(MouseHook.MSLLHOOKSTRUCT mouseStruct) => leftDown = true;
        
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                lock (this)
                {
                    if (checkBoxEnable.Checked)
                    {
                        if (leftDown)
                            PerformLeftClick(mouseX, mouseY);
                        else if (rightDown)
                            PerformRightClick(mouseX, mouseY);
                        Thread.Sleep(delayBetweenClicks);
                    }
                }
            }
        }

        private void CheckBoxAlwaysFocused_CheckedChanged(object sender, EventArgs e) => TopMost = !TopMost;

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            About about = new();
            about.Show(this);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e) => UpdateCPS();

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e) => UpdateCPS();

        private void UpdateCPS()
        {
            //Todo
            delayBetweenClicks = radioButton2.Checked ? (int)numericUpDown1.Value : (int)(numericUpDown1.Value * 1000);
            string cps = radioButton2.Checked ? (1000 / numericUpDown1.Value).ToString() : (1 / numericUpDown1.Value).ToString();
            lblCPS.Text = cps.Substring(0, !cps.Contains(@".", StringComparison.CurrentCulture) ? cps.Length - 1 : cps.IndexOf(@".") + 2) + " CPS";
        }
    }
}
