using System;
using System.Windows.Forms;

namespace LXVidAuto
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // Make sure to use the correct form name
        }
    }
}
