using AutoClicker.Hooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private readonly MouseHook mouseHook = new();
        private readonly KeyboardHook keyHook = new();
        #region SimulateLeftClick
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public static void PerformLeftClick(int xpos, int ypos)
        {
            //SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            //mouseLeftCount++;
            //mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
        public static void PerformRightClick(int xpos, int ypos)
        {
            //SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, xpos, ypos, 0, 0);
            //mouseRightCount++;
            //mouse_event(MOUSEEVENTF_RIGHTUP, xpos, ypos, 0, 0);
        }
        #endregion
        private void mouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            mouseX = mouseStruct.pt.x;
            mouseY = mouseStruct.pt.y;
        }
        int mouseX;
        int mouseY;
        //static int mouseLeftCount = 0;
        //static int mouseRightCount = 0;
        bool leftDown = false;
        bool rightDown = false;
        DateTime timeLeftClicked = DateTime.Now;
        DateTime timeRightClicked = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
            string title =
                $"Lucraft.AutoClicker v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion?.Split("+")[0]}";
            Name = title;
            Text = title;

            backgroundWorker1.RunWorkerAsync();


            mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseMove);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(leftMouseDown);
            mouseHook.LeftButtonUp += new MouseHook.MouseHookCallback(leftMouseUp);
            mouseHook.RightButtonDown += new MouseHook.MouseHookCallback(rightMouseDown);
            mouseHook.RightButtonUp += new MouseHook.MouseHookCallback(rightMouseUp);
            keyHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyUp);
            mouseHook.Install();
            keyHook.Install();
        }

        private void keyUp(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.OEM_102)
            {
                checkBoxEnable.Checked = !checkBoxEnable.Checked;
            }
        }

        private void rightMouseDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (rightDown == false)
            {
                timeRightClicked = DateTime.Now;
            }
            rightDown = true;
        }

        private void rightMouseUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            rightDown = false;
        }

        private void leftMouseUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            leftDown = false;
        }
        private void leftMouseDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (leftDown == false)
            {
                timeLeftClicked = DateTime.Now;
            }
            leftDown = true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                lock (this)
                {
                    if (checkBoxEnable.Checked)
                    {
                        if (leftDown && (int)DateTime.Now.Subtract(timeLeftClicked).TotalMilliseconds > 20)
                        {
                            PerformLeftClick(mouseX, mouseY);
                            Thread.Sleep((int)10);
                        }
                        else if (rightDown && (int)DateTime.Now.Subtract(timeRightClicked).TotalMilliseconds > 20)
                        {
                            PerformRightClick(mouseX, mouseY);
                            Thread.Sleep((int)10);
                        }
                        //lblLeftClicks.Text = mouseLeftCount.ToString();
                        //lblRightClicks.Text = mouseRightCount.ToString();
                    }

                }

            } while (true);
        }

        private void CheckBoxAlwaysFocused_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
    }
}
