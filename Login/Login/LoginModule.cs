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



namespace Login
{
    class LoginModule
    {


        #region Imports

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UIntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        #endregion
        

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public LoginModule()
        {

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
            CreateProfile(email, password);
            Process p = Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2") + @"\Gw2.lnk");
            //IntPtr ptrFF = p.MainWindowHandle;
            Thread.Sleep(waitCharacter*1000);
            IntPtr ptrFF = FindWindow(null, "Guild Wars 2");
            SetForegroundWindow(ptrFF);
            //SendKeys.SendWait("{ENTER}");
            SendKeyAsInput(30);

            destination::WindowsInput.InputSimulator.SimulateKeyPress(destination::WindowsInput.VirtualKeyCode.F12);
            Thread.Sleep(waitGame*1000);

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
