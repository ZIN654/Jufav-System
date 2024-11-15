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
using System.Collections;


namespace JUFAV_System.dll
{
    class initd
       
    {
        //pdf nalng sa inventory
        //access level 


      //  public static CheckBox [] todetermine= {};
        //For SQL DATABASE CONNECTIONS
        public String Constring;
        public static int UserID;
        public static String username;
        public static String UsernameToedit;
        public static Hashtable hs1 = new Hashtable();
        public static SQLiteConnection scon = new SQLiteConnection();

        //FOR DATA HANDLING
        public static int Subtotalid = 1;
        public static String titleofprint;
        //PO
        public static Panel itemsboxselectedPO;
        public static Panel BoxtoCheckDuplicate;
        public static List<double> number = new List<double>();
        public static ModulesSecond.Inventory.AddPurchaseOrder toexe;
        public static Dictionary<int, String> QueryID = new Dictionary<int,String>();
        public static int POID;
        //products
        public static Dictionary<int, String> QueryIDsProd = new Dictionary<int, String>();
        //Sales
        public static Panel itemsboxselected ;
        public static Dictionary<int, String> QueryIDsSALES = new Dictionary<int, String>();
        public static List<double> salestotal = new List<double>();
        public static ModulesMain.SALES.SALES salestoexe;
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
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/JUFAVREPORTS");
            Directory.CreateDirectory(path + "/JUFAVSQLITE/REPORTSTemp");
            //appdata/roaming
            String assign = @path + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";//MYFolder
            this.Constring =  assign;
            Console.WriteLine(this.Constring);
        }
        public void checkpath()
        {
            try
            {

                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//JUFAVSQLITE") == true)
                {
                    //textmessage.Text = "PATH SUCCESSFULLY CHECKED!";//path exist
                    Console.WriteLine("PATH EXIST");
                }
                else
                {
                    // textmessage.Text = "PATH SUCCESSFULLY CHECKED!";
                    Console.WriteLine("PATH NOT EXIST");

                }




            } catch (Exception e) {

                Console.WriteLine(e);



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

        //CHANGE APPROACH USE AUTO INCREAMENT TO REDUCE CODE WRITING  "PRIORITY"
        //get count then ADD?
        //OR FETCH THE ID FIRST THEN QUERRY IF ITHAS THE SAME VALUE THEN INSERT IF WALA ELSE REGENERATE
     
        public void InitializeTable() {
            //try reverse where the users has the foreign
            String[] Querys = {"DROP TABLE SAMPLE;","CREATE TABLE USERS(USERID INT NOT NULL PRIMARY KEY);", "CREATE TABLE USER_INFO(USERINFOID INT NOT NULL PRIMARY KEY,USERIDS INT,NAME VARCHAR(50),USERNAME VARCHAR(50),EMAIL VARCHAR(50),PASSWORDS VARCHAR(50),ROLES VARCHAR(5),FOREIGN KEY(USERIDS)REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE MAINMODULES(MODULEID INT NOT NULL PRIMARY KEY,USERID INT,MODULENAME VARCHAR(50), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE SUBMODULES(SUBMODULEID INT NOT NULL PRIMARY KEY,USERID INT,SUBMODULENAME VARCHAR(50),HASACCESS VARCHAR(2), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);"};
            scon.ConnectionString = @"Data Source=" +Constring ;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();
            

        }
        public void InitTableFilemaintenance()
        {
            //USE MARKUP ID TO IDENTIFY PARA SA PRODUCTS
            //if di nya inispescify ung value ng markup sa text boxthen query nalng ung id ng subcategory
            //chech mo muna if may laman ung supplier ay may laman.
            //junction table SELECT p.PRODUCTS FROM PRODUCTS P JOIN PRODUCTSUPPLIER SP ON P.PRODUCTID = SP.PRODUCTID WHERE SP.SUPPLIERIDI =1; 
            //CREATE TABLE PRODUCTSUPPLIER(PRODUCTID INT,SUPPLIERID INT,FOREIGN KEY(PRODUCTID) REFERENCES PRODUCTS(PRODUCTID),FOREIGN KEY(SUPPLIERID) REFERENCES SUPPLIERS(SUPPLIERS));
            //
            //product markupvalue float
            String[] Querys = {"CREATE TABLE SUPPLIERS (SUPPLIERID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE);","CREATE TABLE CATEGORY (CATEGORYID INT NOT NULL PRIMARY KEY, USERID INT,CATEGORYDESC VARCHAR(50),FOREIGN KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE SUBCATEGORY (SUBCATEGORYID INT NOT NULL PRIMARY KEY,USERID INT,CATEGORYID INT,SUBCATEGORYDESC VARCHAR(50),MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE,FOREIGN KEY (CATEGORYID) REFERENCES CATEGORY (CATEGORYID) ON DELETE CASCADE);", "CREATE TABLE UNITOFMEASURE (UNITID INT NOT NULL PRIMARY KEY,USERID INT,UNITDESC VARCHAR(50),UNITABBREVIATION VARCHAR(10),FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE PRODUCTS(PRODUCTID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,MARKUPVALUE FLOAT,QUANTITY FLOAT,FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE,FOREIGN KEY(CATEGORYID) REFERENCES CATEGORY (CATEGORYID) ON DELETE CASCADE,FOREIGN KEY (SUBCATEGORYID) REFERENCES SUBCATEGORY (SUBCATEGORYID) ON DELETE CASCADE,FOREIGN KEY(UOMID) REFERENCES UNITOFMEASURE(UNITID));","CREATE TABLE VAT(VATID INT NOT NULL PRIMARY KEY,VATVALUE NOT NULL);","INSERT INTO VAT VALUES(01100001,0.12)" , "CREATE TABLE SUPPLIERLISTPROD(SUPPLIERLISTID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,PRODUCTID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUM VARCHAR(50),ADDRESS VARCHAR(50));", "CREATE TABLE PRODUCTSUPPLIER(PRODUCTID INT,SUPPLIERID INT,PRIMARY KEY(PRODUCTID,SUPPLIERID),FOREIGN KEY(PRODUCTID) REFERENCES PRODUCTS(PRODUCTID),FOREIGN KEY(SUPPLIERID) REFERENCES SUPPLIERS(SUPPLIERS));" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();

        }
        public void InitTableInventory()
        {
            
            String[] Querys = { "CREATE TABLE STOCKADJUSTMENTS(STOCKADJUSTMENTID INTEGER NOT  NULL PRIMARY KEY AUTOINCREMENT,USERID INT,DATEOFADJUSTMENT VARCHAR(12),PRODUCTID INT,PRODUCTNAME VARCHAR(50),ADJUSTMENTTYPE VARCHAR(2),PREVIOUSQUANTITY FLOAT,ADJUSTEDQUANTITY FLOAT,REASON VARCHAR(50),OTHERS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES USERS(USERID),FOREIGN KEY (PRODUCTID) REFERENCES PRODUCTS(PRODUCTID))", "CREATE TABLE PURCHASEORDER(POID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT,ORDERDATE VARCHAR(50),EXPECTEDORDERDATE VARCHAR(50),SUPPLIERID INT,SUPPLIER VARCHAR(50),TIMES VARCHAR(50),TOTALPRODUCTS VARCHAR(50),TOTALCOST FLOAT,ORDERSTATUS VARCHAR(2),FOREIGN  KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE POITEMORDERTABLE(ORDERID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID iNT,POID INT,ITEMID INT,QUANTITY INT,PRODUCTNAME VARCHAR(50),ORIGINALPRICE FLOAT,TOTAL FLOAT,FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE,FOREIGN KEY (POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE,FOREIGN KEY (ITEMID) REFERENCES PRODUCTS(PRODUCTID)ON UPDATE CASCADE);", "CREATE TABLE POVENDORINFO(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),FOREIGN KEY(POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE);", "CREATE TABLE POSHIPTOINFO(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),REMARKS VARCHAR(100),FOREIGN KEY(POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE);" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();

        }

        public void InitTableSales()
        {
            //clears anytime user cancels it or sales itORDERSTEMPO
            String[] Querys = {"CREATE TABLE ORDERSTEMPO(ORDERID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,ProductID int,ProductDesc VARCHAR(50),USERID INT,QUANTITY VARCHAR(50),PRICE VARCHAR(50),TOTALPRICE VARCHAR(50));", "CREATE TABLE SALES(SALEID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT,CUSTOMERNAME VARCHAR(60),CUSTOMERADDRESS VARCHAR(50),DATEOFSALE VARCHAR(20),TOTALITEMS VARCHAR(100),TOTALPRICE VARCHAR(100) ,FOREIGN KEY(USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ORDERSTABLE(ORDERID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,SALEID INT,ITEMID INT,ITEMNAME VARCHAR(50),ITEMPRICE VARCHAR(50),QUANTITY VARCHAR(100),TOTALPURCHASE VARCHAR(50),FOREIGN KEY (SALEID) REFERENCES SALES(SALEID) ON DELETE CASCADE)" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();

        }

        //======================================TABLES FOR ARCHIVED FILES=====================================================================
        //rename some tables
        //EACH TIME USER CREATES ACCOUNT IT WILL BE STORED IN BOT MAIN AND ARC TABLES FOR REFERENCES AND OTHER PARTS
        public void InitializeArcTable()
        {
            //try reverse where the users has the foreign
            String[] Querys = { "CREATE TABLE ARCUSERS(USERID INT NOT NULL PRIMARY KEY);", "CREATE TABLE ARCUSER_INFO(USERINFOID INT NOT NULL PRIMARY KEY,USERIDS INT,NAME VARCHAR(50),USERNAME VARCHAR(50),EMAIL VARCHAR(50),PASSWORDS VARCHAR(50),ROLES VARCHAR(2),FOREIGN KEY(USERIDS)REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCMAINMODULES(MODULEID INT NOT NULL PRIMARY KEY,USERID INT,MODULENAME VARCHAR(50), FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCSUBMODULES(SUBMODULEID INT NOT NULL PRIMARY KEY,USERID INT,SUBMODULENAME VARCHAR(50),HASACCESS VARCHAR(2), FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();


        }
        public void InitTableArcFilemaintenance()
        {
            //USE MARKUP ID TO IDENTIFY PARA SA PRODUCTS
            //if di nya inispescify ung value ng markup sa text boxthen query nalng ung id ng subcategory
            //chech mo muna if may laman ung supplier ay may laman.

            //product markupvalue float 
            //HEHE ALWAYS REPLACE THE REFERENCES OF FOREIGN KEYS ON DLETE CASCADE
            String[] Querys = { "CREATE TABLE ARCSUPPLIERS (SUPPLIERID INT NOT NULL PRIMARY KEY,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCCATEGORY (CATEGORYID INT NOT NULL PRIMARY KEY, USERID INT,CATEGORYDESC VARCHAR(50),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCSUBCATEGORY (SUBCATEGORYID INT NOT NULL PRIMARY KEY,USERID INT,CATEGORYID INT,SUBCATEGORYDESC VARCHAR(50),MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCUNITOFMEASURE (UNITID INT NOT NULL PRIMARY KEY,USERID INT,UNITDESC VARCHAR(50),UNITABBREVIATION VARCHAR(10),FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCMARKUP (MARKUPID INT NOT NULL PRIMARY KEY,USERID INT,MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCPRODUCTS(PRODUCTID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,MARKUPVALUE FLOAT,QUANTITY FLOAT,SUPPLIERID INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE VARCHAR(50),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCPRODUCTBATCH(BATCHID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,PRODUCTID INT, PRODUCTDESC VARCHAR(50),BATCHNO VARCHAR(50),QUANTITY INT,EXPIRATIONDATE VARCHAR(50),FOREIGN KEY (PRODUCTID) REFERENCES ARCPRODUCTS(PRODUCTID)ON DELETE CASCADE);" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();

        }
        public void ArcInitTableInventory()
        {
            //mag kaka gulo dito if madelete ung isang products
            String[] Querys = { "CREATE TABLE ARCSTOCKADJUSTMENTS(STOCKADJUSTMENTID INTEGER NOT  NULL PRIMARY KEY AUTOINCREMENT,USERID INT,DATEOFADJUSTMENT VARCHAR(12),PRODUCTID INT,PRODUCTNAME VARCHAR(50),ADJUSTMENTTYPE VARCHAR(2),PREVIOUSQUANTITY FLOAT,ADJUSTEDQUANTITY FLOAT,REASON VARCHAR(50),OTHERS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID))", "CREATE TABLE ARCPURCHASEORDER(POID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID INT,ORDERDATE VARCHAR(50),EXPECTEDORDERDATE VARCHAR(50),SUPPLIER VARCHAR(50),TIMES VARCHAR(50),TOTALPRODUCTS VARCHAR(50),TOTALCOST FLOAT,ORDERSTATUS VARCHAR(2),FOREIGN  KEY (USERID) REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCPOITEMORDERTABLE(ORDERID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,USERID iNT,POID INT,ITEMID INT,QUANTITY INT,PRODUCTNAME VARCHAR(50),ORIGINALPRICE FLOAT,TOTAL FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCPOVENDORINFO(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),FOREIGN KEY(POID) REFERENCES ARCPURCHASEORDER(POID) ON DELETE CASCADE);", "CREATE TABLE ARCPOSHIPTOINFO(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),REMARKS VARCHAR(100),FOREIGN KEY(POID) REFERENCES ARCPURCHASEORDER(POID) ON DELETE CASCADE);" };
            scon.ConnectionString = @"Data Source=" + Constring;
            scon.Open();
            foreach (String i in Querys)
            {
                SQLiteCommand sqcom = new SQLiteCommand(i, scon);
                sqcom.ExecuteNonQuery();
                Thread.Sleep(200);//delay

            }
            scon.Close();
        }
        //===========================================================================================================================
        public static String loadpath()
        {
            ///create a functiom for Database path to loadd 
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";

            return path;
        }
        public static int getID(String username,SQLiteConnection scon)
        {
            int id = 0;
            //database not open
            
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
            
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//JUFAVSQLITE";
            //FIX THIS 
            if (Directory.Exists(path) == true)
            {
                //current errors ====================
                //invalid due to the state of the object being created
                scon = new SQLiteConnection();
                scon.ConnectionString = @"Data Source=" + loadpath();
                scon.Open();
                SQLiteCommand scom = new SQLiteCommand("PRAGMA foreign_keys = ON;", scon);      
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
