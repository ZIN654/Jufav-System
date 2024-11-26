using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data;
using System.Net;
using JUFAV_System.dll;


namespace JUFAV_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// 
       
         

/// 
/// 
/// 
///in order to preveent yung mag revise kami ng gahol in 2 weeks revise the Wireframe.
[STAThread]
        static void Main()
        {
            bool isexist;
            String TouseIP = "";
            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection();
            var hostname = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var IP in hostname.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    TouseIP = IP.ToString();
                    break;
                }
            }
            
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

              

                try
                {
                 //error hjere  
                    con1.ConnectionString = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;";
                    con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand com1 = new MySql.Data.MySqlClient.MySqlCommand("SHOW DATABASES LIKE 'JUFAV2%';", con1);
                    isexist = determineval(com1.ExecuteScalar().ToString());
                    if (isexist == true)
                    {
                        con1.Close();
                        initd.IPtouse2 = TouseIP;//change password kapag publishing kaparehas nung asa mariadb

                        initd.con1.ConnectionString = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;database=jufav2;";//
                        initd.constringtouserefresh = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;database=jufav2;";
                        Application.Run(new ModulesMain.LOGIN.JUFAV_LOGIN());
                    }
                }
                catch (Exception e)
                {
                con1.Close();
                /*
                System.Diagnostics.ProcessStartInfo prst = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C C:/Users/asus/Desktop/login.bat",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized,
                    CreateNoWindow = false
                };
                var pr1 = System.Diagnostics.Process.Start(prst);
                pr1.WaitForExit();
                pr1.Dispose();
            
    */
               
                Application.Run(new DBsetup());
               

                }
            



            //String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/JUFAVSQLITE";
        }
        static bool determineval(String result)
        {
            bool test = true;
            if (result == "JUFAV2" || result == "JUFAV2".ToLower())
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }
    
         
        
    }
}
