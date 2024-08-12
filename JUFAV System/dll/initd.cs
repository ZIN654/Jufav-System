using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace JUFAV_System.dll
{
    class initd
       
    {
        private String Constring;
        private SQLiteConnection scon = new SQLiteConnection();
        //only runs once //if the database does not exist reruns again
        //create path 
        //create database 
        //test connection  
        //initialize ang mga tables and data
        //test data CRUD
        //salpak admin and password
        public void CreatePath(){
            //and then repeat if error perhaps giving the user a directory where the user can specify whic path is the database will be  insatlled
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory(path + "/JUFAVSQLITE");
            //appdata/roaming
            String assign = @path + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";//MYFolder
            this.Constring = assign;
        }
        public void checkpath(Label textmessage)
        {
            try
            {

                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/JUFAVSQLITE") == true)
                {
                    textmessage.Text = "PATH SUCCESSFULLY CHECKED!";//path exist
                }
                else
                {
                    textmessage.Text = "PATH SUCCESSFULLY CHECKED!";

                }
            }
            catch (Exception e) {

                MessageBox.Show("","DATABASE WAS NOT CREATED",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            finally
            {


            }
        }
        public void CreateDatabase() {
            //sqlite file creation 
            
            SQLiteConnection.CreateFile(Constring);
        }
        public void TestConnection() { }
        public void InitializeTable() { }
        public void TestCRUD() { }
        public void AdminPass() { }

    }
}
