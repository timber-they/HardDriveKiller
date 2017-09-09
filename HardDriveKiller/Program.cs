using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace HardDriveKiller
{
    internal static class Program
    {
        private const string PROGRAM_PATH = @"External\smartctl.exe";
        private const string ARGUMENTS_SHUTDOWN = @"-s standby,now d:";


        public static void Main (string [] args)
        {
            InitializeHotKey ();
            Console.WriteLine ("Hotkey registered!");

            while (true) {}
        }

        private static void InitializeHotKey ()
        {
            HotKeyManager.RegisterHotKey (Keys.D, KeyModifiers.Alt | KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += HotKeyPressed;
        }

        private static void HotKeyPressed (object sender, HotKeyEventArgs hotKeyEventArgs) => ShutDownDrive (true);

        private static void ShutDownDrive (bool withDialog = false)
        {
            Process process;
            (process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = PROGRAM_PATH,
                    Arguments = ARGUMENTS_SHUTDOWN
                }
            }).Start ();

            process.WaitForExit ();
            process.Close ();

            if (withDialog)
                Console.WriteLine ("Drive shut down!");
        }
    }
}