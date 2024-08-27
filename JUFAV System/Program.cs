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
            //use INDEX syntax for retreival much efficient
            //DEBUG MODE ==============================
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModulesMain.LOGIN.Log_in());
            */

            //===========================================================
                                  //STANDARD TO USE
          
        
            //
            //store each number convert to hexadecimal type value for string connection to text 
            //database creation and initialization
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/JUFAVSQLITE";
          
            if (Directory.Exists(path) == true) {//if database||folderpath||file is not  existing

                Console.WriteLine("path existing");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new SANDBOX());
                Application.Run(new ModulesMain.LOGIN.JUFAV_LOGIN());
               // Application.Run(new Ffirstrun.FirstRun());
                // Application.EnableVisualStyles();
                // Application.SetCompatibleTextRenderingDefault(false);
                // Application.Run(new DBsetup());//database setup  and user account setup 


            }
            else
            {
                //if database is not exsting proceed to db setupo

                Console.WriteLine("path not existing");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DBsetup());

            }
            //===========================================================
           
        }
    }
}
