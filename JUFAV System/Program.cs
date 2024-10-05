using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace JUFAV_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        ///in order to preveent yung mag revise kami ng gahol in 2 weeks revise the Wireframe.
        [STAThread]
        static void Main()
        {
           //larg spike of CPU usage here
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/JUFAVSQLITE";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Directory.Exists(path) == true) {//if database||folderpath||file is not  existing  
               Application.Run(new ModulesMain.LOGIN.JUFAV_LOGIN());
            }
            else
            {     
                Application.Run(new DBsetup());
            }
         
        }
    }
}
