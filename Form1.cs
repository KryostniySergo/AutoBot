using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static string Igor = "Minecraft 1.12.2";
        public static string Me = "RLCraft";

        public Form1()
        {
            InitializeComponent();
        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private void button1_Click(object sender, EventArgs e)
        {
            InputLanguage myDefaultLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            InputLanguage.CurrentInputLanguage = myDefaultLanguage;
            Thread.Sleep(100);
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr Minecraft = FindWindow(null, Igor);

            // Verify that Calculator is a running process.
            if (Minecraft == IntPtr.Zero)
            {
                MessageBox.Show("Minecraft is not running.");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.
            SetForegroundWindow(Minecraft);
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(300);
            SendKeys.SendWait("t");
            Thread.Sleep(100);
            SendKeys.SendWait("/gamemode 1");
            Thread.Sleep(100);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(200);
            SendKeys.SendWait("t");
            Thread.Sleep(100);
            SendKeys.SendWait("/gamemode 0");
            Thread.Sleep(100);
            SendKeys.SendWait("{ENTER}");
            this.Close();
        }
    }
}
