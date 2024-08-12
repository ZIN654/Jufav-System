using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Collections;

namespace JUFAV_System.dll
{
    class CommunicateDB
    {
        //when database creation this must be setted
       private static String connectionString;
        private static Hashtable passuser;
        private static SQLiteConnection scon = new SQLiteConnection();
        private static void OpenCon()
        {
            scon.ConnectionString = connectionString;
            scon.Open();
        }
        private static void CloseCon() {
            scon.Close();
        }
        private static void LoginCheck(String username,String Password,int isadmin)
        {
            
            //validate if usernameTXTbx had item entity in keys of hashtabel

        }

    }
}
