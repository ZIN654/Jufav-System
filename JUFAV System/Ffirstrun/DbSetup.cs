using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections;



namespace JUFAV_System
{
    public partial class DBsetup : Form
    {
        public DBsetup()
        {
            InitializeComponent();
            initdbDebug();
        }

        public void initdbDebug()
        {

            //add exceptions for secure confirmations 

            //and then repeat if error perhaps giving the user a directory where the user can specify whic path is the database will be  insatlled
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory(path + "/JUFAVSQLITE");
            //appdata/roaming
            String assign = @path + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";//MYFolder
            


            //sqlite file creation 
           // SQLiteConnection.CreateFile(assign);

            SQLiteConnection pas = new SQLiteConnection(@"Data Source=" + assign);
            SQLiteCommand scm = new SQLiteCommand("SELECT * FROM SAMPLE", pas);
            pas.Open();

           

           // scm.ExecuteNonQuery();

            //pas.Close();
           SQLiteDataReader reader1 = scm.ExecuteReader();
            Hashtable ps1 = new Hashtable();
            while (reader1.Read())
            {
                ps1.Add(reader1["ID"].ToString(),reader1["NAME"].ToString());
                Console.WriteLine("ID :" + reader1.GetValue(0).ToString() + " " + "usernames : " + reader1.GetValue(1).ToString() + "|  Passwprds : " + reader1.GetValue(2).ToString());
            }
            
            /*
            //dataset to load
            SQLiteDataAdapter ps = new SQLiteDataAdapter("SELECT * FROM SAMLPE",pas);
            DataSet ds1 = new DataSet();
            ps.Fill(ds1);
            */
            
         




        }
    }
}
