using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;


namespace JUFAV_System.dll
{
    class initd
       
    {
        public String Constring;
        public static int UserID;
        public static String username;
        public static SQLiteConnection scon = new SQLiteConnection();
       
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
            this.Constring =  assign;
            Console.WriteLine(this.Constring);
        }
        public void checkpath()
        {
            try
            {

                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/JUFAVSQLITE") == true)
                {
                    //textmessage.Text = "PATH SUCCESSFULLY CHECKED!";//path exist
                    Console.WriteLine("PATH EXIST");
                }
                else
                {
                    // textmessage.Text = "PATH SUCCESSFULLY CHECKED!";
                    Console.WriteLine("PATH NOT EXIST");

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
        public void TestConnection(String connection) {

            SQLiteConnection scon1 = new SQLiteConnection(@"Data Source=" + connection);
          
            SQLiteCommand scom1 = new SQLiteCommand("CREATE TABLE SAMPLE(ID INT PRIMARY KEY);",scon1);
            scon1.Open();
            scom1.ExecuteNonQuery();
            scom1.CommandText = "INSERT INTO SAMPLE VALUES(123123);";
            scom1.ExecuteNonQuery();
            scom1.CommandText = "SELECT * FROM SAMPLE";
            SQLiteDataReader sql = scom1.ExecuteReader();
            while (sql.Read())
            {
                if (sql[0].ToString() == "123123")
                {
                    Console.WriteLine("CONNECTION SUCCES" + sql[0].ToString());

                }
            }
      
            scon1.Close();
            

        }


        public void InitializeTable() {
            //try reverse where the users has the foreign
            String[] Querys = {"DROP TABLE SAMPLE;","CREATE TABLE USERS(USERID INT NOT NULL PRIMARY KEY);", "CREATE TABLE USER_INFO(USERINFOID INT NOT NULL PRIMARY KEY,USERIDS INT,NAME VARCHAR(50),USERNAME VARCHAR(50),EMAIL VARCHAR(50),PASSWORDS VARCHAR(50),ROLES VARCHAR(2),FOREIGN KEY(USERIDS)REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE MAINMODULES(MODULEID INT NOT NULL PRIMARY KEY,USERID INT,MODULENAME VARCHAR(50), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE SUBMODULES(SUBMODULEID INT NOT NULL PRIMARY KEY,USERID INT,SUBMODULENAME VARCHAR(50),HASACCESS VARCHAR(2), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);"};
            scon.ConnectionString = @"Data Source=" +Constring ;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(3000);//delay

            }
            scon.Close();
            

        }
        public void InitTableFilemaintenance()
        {
            //hangang markup for now 
            String[] Querys = {"CREATE TABLE SUPPLIERS (SUPPLIERID INT NOT NULL PRIMARY KEY,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE);","CREATE TABLE CATEGORY (CATEGORYID INT NOT NULL PRIMARY KEY, USERID INT,CATEGORYDESC VARCHAR(50),FOREIGN KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE SUBCATEGORY (SUBCATEGORYID INT NOT NULL PRIMARY KEY,USERID INT,CATEGORYID INT,SUBCATEGORYDESC VARCHAR(50),MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE,FOREIGN KEY (CATEGORYID) REFERENCES CATEGORY (CATEGORYID) ON DELETE CASCADE);", "CREATE TABLE UNITOFMEASURE (UNITID INT NOT NULL PRIMARY KEY,USERID INT,UNITDESC VARCHAR(50),UNITABBREVIATION VARCHAR(10),FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE MARKUP (MARKUPID INT NOT NULL PRIMARY KEY,USERID INT,MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(3000);//delay

            }
            scon.Close();

        }
        public static String loadpath()
        {
            ///create a functiom for Database path to loadd 
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";

            return path;
        }
        public static int getID(String username,SQLiteConnection scon)
        {
            int id = 0;
            SQLiteCommand sq1 = new SQLiteCommand("SELECT USERIDS FROM USER_INFO WHERE USERNAME ='" + username + "';",scon);
            SQLiteDataReader s1 = sq1.ExecuteReader();
            while (s1.Read())
            {
                id = Convert.ToInt32(s1["USERIDS"]);
            }
            return id;
        }
   //==============================CRUD OPERATIONS================================
        public static void opendatabase()
        {
            initd sp = new initd();
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//JUFAVSQLITE";
            //FIX THIS 
            if (Directory.Exists(path) == true)
            {
                //current errors ====================
                //invalid due to the state of the object
                SQLiteCommand scom = new SQLiteCommand("PRAGMA foreign_keys = ON;",scon);
                scon.ConnectionString = @"Data Source=" + loadpath();
                scon.Open();
                scom.ExecuteNonQuery();
                //on delete cascade

            }



        }
           
       
        
        public static void closedatabase()
        {
            
            scon.Close();
            scon.ConnectionString = "";
        }
        //insertion/deletion/update/retreival
        
      

    }
}
