extern alias destination;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Xml;
using IWshRuntimeLibrary;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace Login
{
    class LoginModule
    {


        #region Imports
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UIntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        #endregion

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        #region RECT
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        #endregion
        public LoginModule()
        {

        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private bool PollPixel(Point location, Color color)
        {
            while (true)
            {
                var c = GetColorAt(location);

                if (c.R >= color.R && c.R <= color.R + 10 && c.G >= color.G && c.G <= color.G + 10 && c.B >= color.B && c.B <= color.B + 10)
                {
                    //DoAction();
                    return true;
                }
                return false;
                // By calling Thread.Sleep() without a parameter, we are signaling to the
                // operating system that we only want to sleep long enough for other
                // applications.  As soon as the other apps yield their CPU time, we will
                // regain control.
                //Thread.Sleep();
            }
        }

        private string getInstallPath()
        {
            FileInfo gw2config = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2", "GFXSettings.Gw2-64.exe.xml"));
            XmlTextReader reader = new XmlTextReader(gw2config.FullName);
            string installPath = "";
            while (reader.Read())
            {
                if(reader.Name == "INSTALLPATH")
                {
                    reader.MoveToNextAttribute();
                    installPath = reader.Value;
                }
            }
            return installPath;
        }

        public void LaunchGW2(string email, string password, int waitCharacter, int waitGame)
        {
            var x = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            
            RECT rct;

            //MessageBox.Show(rct.ToString());

            //myRect.X = rct.Left;
            //myRect.Y = rct.Top;
            //myRect.Width = rct.Right - rct.Left + 1;
            //myRect.Height = rct.Bottom - rct.Top + 1;
            
            CreateProfile(email, password);
            Process p = Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2") + @"\Gw2.lnk");
            
            Thread.Sleep(2000);
            
            
            
            

            //IntPtr ptrFF = p.MainWindowHandle;
            //Thread.Sleep(waitCharacter*1000);
            //SendKeys.SendWait("{ENTER}");

            //wait for window to open
            while (!GetWindowRect(new HandleRef(p, p.MainWindowHandle), out rct))
            {
                Thread.Sleep(1000);
                
            }
            //MessageBox.Show("Window Frame Rect set.");
            //at this point we know the size of gw2 (in my case 1280 by 720 but that doesnt matter)
            //
            IntPtr ptrFF = FindWindow(null, "Guild Wars 2");
            SetForegroundWindow(ptrFF);


            Point bottom = new Point((rct.Right - rct.Left) / 2, rct.Bottom-3);

            Color black = Color.FromArgb(255, 0, 0, 0);

            //wait for character screen to display before sending Enter input
            while (!PollPixel(bottom, black))
            {
                Thread.Sleep(1000);    
            }

            SendKeyAsInput(30);
            //MessageBox.Show("Key input sent");

            //destination::WindowsInput.InputSimulator.SimulateKeyPress(destination::WindowsInput.VirtualKeyCode.F12);
            //Thread.Sleep(waitGame*1000);

            Color red = Color.FromArgb(255, 151, 12, 5);

            //wait for load into game and check for red health bar.
            while (!PollPixel(new Point((rct.Left - rct.Right) / 2, rct.Bottom - 30), red))
            {
                Thread.Sleep(1000);
            }
            //if (PollPixel(new Point((rct.Left-rct.Right)/2,rct.Bottom-30), black))
            p.CloseMainWindow();
        }


        public static void SendKeyAsInput(int HoldTime)
        {
            INPUT INPUT1 = new INPUT();
            INPUT1.type = InputType.KEYBOARD;
            INPUT1.U.ki.wScan = ScanCodeShort.RETURN;
            INPUT1.U.ki.wVk = VirtualKeyShort.RETURN;
            INPUT1.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            INPUT1.U.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT1 }, Marshal.SizeOf(INPUT1));

            WaitForSingleObject((IntPtr)0xACEFDB, (uint)HoldTime);

            INPUT INPUT2 = new INPUT();
            INPUT2.type = InputType.KEYBOARD;
            INPUT1.U.ki.wScan = ScanCodeShort.RETURN;
            INPUT2.U.ki.wVk = VirtualKeyShort.RETURN;
            INPUT2.U.ki.dwFlags = KEYEVENTF.KEYUP;
            INPUT2.U.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT2 }, Marshal.SizeOf(INPUT2));

        }


        private void CreateProfile(string email, string password)
        {
            WshShell shell = new WshShell();
            string shortcutAddress = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2") + @"\Gw2.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "New shortcut for a Notepad";
            string install = getInstallPath();
            shortcut.TargetPath = install + "Gw2-64.exe";
            shortcut.Arguments = "-autologin -nopatchui -email " + email + " -password " + password;
            shortcut.Save();
        }
    }
}
