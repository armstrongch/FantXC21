using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantXC21
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
             * Using git, github:
             * $ cd /c/users/chris/source/repos/fantxc21
             * $ git status
             * $ git add . 
             * $ git commit -m "comment"
             * $ git push origin main
             */
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_game());
        }
    }
}
