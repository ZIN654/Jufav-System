using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModulesMain.LOGIN.Log_in());


            //===========================================================
            /*                      STANDARD TO USE
           temporary//
           int ps1 = 1; check database if existing or not
            //
            //store each number convert to hexadecimal type value for string connection to text 
            //database creation and initialization

            if (ps1 == 1) {//if database||folderpath||file is not  existing
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());//database setup  and user account setup 

                user databasesetup() and first time account craetion
            }
            else
            {
            //if database is exsting proceed to login 

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ModulesMain.LOGIN.Log_in());

            }
            //===========================================================
           **/
        }
    }
}
