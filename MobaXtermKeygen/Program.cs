using System;
using System.Windows.Forms;

namespace MobaXtermKeygen
{

    /// <summary>
    /// 应用程序的主入口点
    /// </summary>
    public static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

    }
}
