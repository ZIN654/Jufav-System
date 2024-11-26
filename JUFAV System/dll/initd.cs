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
using System.Net;


namespace JUFAV_System.dll
{
    class initd
       
    {
        //pdf nalng sa inventory
        //access level 


        //  public static CheckBox [] todetermine= {};
        //MAIN PANEL 
        public static Form thisform1;
        //For SQL DATABASE CONNECTIONS
        public String Constring;
        public static int UserID;
        public static int UserIDACtionAudit;
        public static String username;
        public static String UsernameToedit;
        public static Hashtable hs1 = new Hashtable();
        public static SQLiteConnection scon = new SQLiteConnection();
        public static MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection();
       // public static MySql.Data.MySqlClient.MySqlConnection ForClient = new MySql.Data.MySqlClient.MySqlConnection();
        public static String constringfromserver;
        public static String constringtouserefresh;
        public static String IPtouse;//for fresh install
        public static String IPtouse2;//for initialization
        public static bool isadminloggedinClientcheck;
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
        public void CreateDB(){
          //Static IP na Dapat since dun lang tayo coconnect and kung mabago man un set nlng lagi kung mag run ulit ung device
          //
            String TouseIP = "";
            var hostname = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var IP in hostname.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    TouseIP = IP.ToString();
                    break;
                }
            }
            IPtouse = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;";
            con1.ConnectionString = @"server="+TouseIP.Trim()+ ";user=root;password=zxcvbnm12;port=3306;";//fetch this on start of login 
            MySql.Data.MySqlClient.MySqlCommand com1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            String[] query = { "CREATE DATABASE JUFAV2;", "USE JUFAV2;" };
            con1.Open();
            foreach (String i in query)
            {
                com1.CommandText = i.ToString();
                com1.ExecuteNonQuery();
            }
            con1.Close();
            com1 = null;
            GC.Collect();
          
                       
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
            String[] Querys = {"CREATE TABLE USERS(USERID INT NOT NULL PRIMARY KEY);", "CREATE TABLE USER_INFO(USERINFOID INT NOT NULL PRIMARY KEY,USERIDS INT,NAME VARCHAR(50),USERNAME VARCHAR(50),EMAIL VARCHAR(50),PASSWORDS VARCHAR(50),ROLES VARCHAR(5),FOREIGN KEY(USERIDS)REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE MAINMODULES(MODULEID INT NOT NULL PRIMARY KEY,USERID INT,MODULENAME VARCHAR(50), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE SUBMODULES(SUBMODULEID INT NOT NULL PRIMARY KEY,USERID INT,SUBMODULENAME VARCHAR(50),HASACCESS VARCHAR(2), FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);"};
            con1.ConnectionString = IPtouse;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("",con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();
            

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
            String[] Querys = {"CREATE TABLE SUPPLIERS (SUPPLIERID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE);","CREATE TABLE CATEGORY (CATEGORYID INT NOT NULL PRIMARY KEY, USERID INT,CATEGORYDESC VARCHAR(50),FOREIGN KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE SUBCATEGORY (SUBCATEGORYID INT NOT NULL PRIMARY KEY,USERID INT,CATEGORYID INT,SUBCATEGORYDESC VARCHAR(50),MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE,FOREIGN KEY (CATEGORYID) REFERENCES CATEGORY (CATEGORYID) ON DELETE CASCADE);", "CREATE TABLE UNITOFMEASURE (UNITID INT NOT NULL PRIMARY KEY,USERID INT,UNITDESC VARCHAR(50),UNITABBREVIATION VARCHAR(10),FOREIGN KEY (USERID) REFERENCES USERS (USERID) ON DELETE CASCADE);", "CREATE TABLE PRODUCTS(PRODUCTID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,MARKUPVALUE FLOAT,QUANTITY FLOAT,FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE,FOREIGN KEY(CATEGORYID) REFERENCES CATEGORY (CATEGORYID) ON DELETE CASCADE,FOREIGN KEY (SUBCATEGORYID) REFERENCES SUBCATEGORY (SUBCATEGORYID) ON DELETE CASCADE);","CREATE TABLE VAT(VATID INT NOT NULL PRIMARY KEY,VATVALUE INT NOT NULL);","INSERT INTO VAT VALUES(01100001,12)" , "CREATE TABLE SUPPLIERLISTPROD(SUPPLIERLISTID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,PRODUCTID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUM VARCHAR(50),ADDRESS VARCHAR(50));", "CREATE TABLE PRODUCTSUPPLIER(PRODUCTID INT,SUPPLIERID INT,PRIMARY KEY(PRODUCTID,SUPPLIERID),FOREIGN KEY(PRODUCTID) REFERENCES PRODUCTS(PRODUCTID) ON DELETE CASCADE,FOREIGN KEY(SUPPLIERID) REFERENCES SUPPLIERS(SUPPLIERID) ON DELETE CASCADE);", "CREATE TABLE AUDITTRAIL(AUDITID INT NOT NULL PRIMARY KEY,USERID INT,USERNAME VARCHAR(50),LOGGEDINDATE VARCHAR(50),TIMEIN1 VARCHAR(50),TIMEOUT1 VARCHAR(50),TOTALACTIONS VARCHAR(50),FOREIGN KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE AUDITTRAILACTIONSLIST(AUDITACTIONSID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,AUDITID INT,ACTIONS VARCHAR(50),ACTIONTYPE VARCHAR(50),TIMEOFACTION VARCHAR(50),FOREIGN KEY (AUDITID) REFERENCES AUDITTRAIL(AUDITID) ON DELETE CASCADE);" };
         
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();

        }
        public void InitTableInventory()
        {
            
            String[] Querys = { "CREATE TABLE STOCKADJUSTMENTS(STOCKADJUSTMENTID INT NOT  NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,DATEOFADJUSTMENT VARCHAR(50),TIMEOFADJUSTMENT VARCHAR(50),PRODUCTID INT,PRODUCTNAME VARCHAR(50),ADJUSTMENTTYPE VARCHAR(2),PREVIOUSQUANTITY FLOAT,ADJUSTEDQUANTITY FLOAT,REASON VARCHAR(50),OTHERS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES USERS(USERID),FOREIGN KEY (PRODUCTID) REFERENCES PRODUCTS(PRODUCTID))", "CREATE TABLE PURCHASEORDER(POID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,ORDERDATE VARCHAR(50),EXPECTEDORDERDATE VARCHAR(50),SUPPLIERID INT,SUPPLIER VARCHAR(50),TIMES VARCHAR(50),TOTALPRODUCTS VARCHAR(50),TOTALCOST FLOAT,ORDERSTATUS VARCHAR(5),FOREIGN  KEY (USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE POITEMORDERTABLE(ORDERID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID iNT,POID INT,ITEMID INT,QUANTITY INT,PRODUCTNAME VARCHAR(50),ORIGINALPRICE FLOAT,TOTAL FLOAT,FOREIGN KEY (USERID) REFERENCES USERS(USERID)ON DELETE CASCADE,FOREIGN KEY (POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE,FOREIGN KEY (ITEMID) REFERENCES PRODUCTS(PRODUCTID)ON UPDATE CASCADE);", "CREATE TABLE POVENDORINFO(ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),FOREIGN KEY(POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE);", "CREATE TABLE POSHIPTOINFO(ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),REMARKS VARCHAR(100),FOREIGN KEY(POID) REFERENCES PURCHASEORDER(POID) ON DELETE CASCADE);" };

            con1.ConnectionString = IPtouse;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();
            

        }
        public void InitTableSales()
        {
            //clears anytime user cancels it or sales itORDERSTEMPO
            String[] Querys = {"CREATE TABLE ORDERSTEMPO(ORDERID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,ProductID int,ProductDesc VARCHAR(50),USERID INT,QUANTITY VARCHAR(50),PRICE VARCHAR(50),TOTALPRICE VARCHAR(50));", "CREATE TABLE SALES(SALEID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,CUSTOMERNAME VARCHAR(60),CUSTOMERADDRESS VARCHAR(50),DATEOFSALE VARCHAR(20),TOTALITEMS VARCHAR(100),TOTALPRICE VARCHAR(100),PAYMENTVALUE VARCHAR(50),DISCOUNT VARCHAR(50),PAYMENTTYPE VARCHAR(50),CUSTOMERPAYMENT VARCHAR(50),ORDERTYPE VARCHAR(50),GCASHREFERENCE VARCHAR(50),FOREIGN KEY(USERID) REFERENCES USERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ORDERSTABLE(ORDERID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,SALEID INT,ITEMID INT,ITEMNAME VARCHAR(50),ITEMPRICE VARCHAR(50),QUANTITY VARCHAR(100),TOTALPURCHASE VARCHAR(50),FOREIGN KEY (SALEID) REFERENCES SALES(SALEID) ON DELETE CASCADE)","CREATE TABLE BACKUPINFO(BPID INT PRIMARY KEY AUTO_INCREMENT,DATEOFB VARCHAR(50),PATH VARCHAR(200));" };

            con1.ConnectionString = IPtouse;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();


        }
      
        //======================================TABLES FOR ARCHIVED FILES=====================================================================
        //rename some tables
        //EACH TIME USER CREATES ACCOUNT IT WILL BE STORED IN BOT MAIN AND ARC TABLES FOR REFERENCES AND OTHER PARTS
        public void InitializeArcTable()
        {
            //try reverse where the users has the foreign
            String[] Querys = { "CREATE TABLE ARCUSERS(USERID INT NOT NULL PRIMARY KEY);", "CREATE TABLE ARCUSER_INFO(USERINFOID INT NOT NULL PRIMARY KEY,USERIDS INT,NAME VARCHAR(50),USERNAME VARCHAR(50),EMAIL VARCHAR(50),PASSWORDS VARCHAR(50),ROLES VARCHAR(2),FOREIGN KEY(USERIDS)REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCMAINMODULES(MODULEID INT NOT NULL PRIMARY KEY,USERID INT,MODULENAME VARCHAR(50), FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCSUBMODULES(SUBMODULEID INT NOT NULL PRIMARY KEY,USERID INT,SUBMODULENAME VARCHAR(50),HASACCESS VARCHAR(2), FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);" };
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();

        }
        public void InitTableArcFilemaintenance()
        {
            //USE MARKUP ID TO IDENTIFY PARA SA PRODUCTS
            //if di nya inispescify ung value ng markup sa text boxthen query nalng ung id ng subcategory
            //chech mo muna if may laman ung supplier ay may laman.

            //product markupvalue float 
            //HEHE ALWAYS REPLACE THE REFERENCES OF FOREIGN KEYS ON DLETE CASCADE
            String[] Querys = { "CREATE TABLE ARCSUPPLIERS (SUPPLIERID INT NOT NULL PRIMARY KEY,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCCATEGORY (CATEGORYID INT NOT NULL PRIMARY KEY, USERID INT,CATEGORYDESC VARCHAR(50),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCSUBCATEGORY (SUBCATEGORYID INT NOT NULL PRIMARY KEY,USERID INT,CATEGORYID INT,SUBCATEGORYDESC VARCHAR(50),MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCUNITOFMEASURE (UNITID INT NOT NULL PRIMARY KEY,USERID INT,UNITDESC VARCHAR(50),UNITABBREVIATION VARCHAR(10),FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCMARKUP (MARKUPID INT NOT NULL PRIMARY KEY,USERID INT,MARKUPVALUE FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS (USERID) ON DELETE CASCADE);", "CREATE TABLE ARCPRODUCTS(PRODUCTID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,MARKUPVALUE FLOAT,QUANTITY FLOAT,SUPPLIERID INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE VARCHAR(50),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCPRODUCTBATCH(BATCHID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,PRODUCTID INT, PRODUCTDESC VARCHAR(50),BATCHNO VARCHAR(50),QUANTITY INT,EXPIRATIONDATE VARCHAR(50),FOREIGN KEY (PRODUCTID) REFERENCES ARCPRODUCTS(PRODUCTID)ON DELETE CASCADE);" };
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();

        }
        public void ArcInitTableInventory()
        {
            //mag kaka gulo dito if madelete ung isang products
            String[] Querys = { "CREATE TABLE ARCSTOCKADJUSTMENTS(STOCKADJUSTMENTID INT NOT  NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,DATEOFADJUSTMENT VARCHAR(12),PRODUCTID INT,PRODUCTNAME VARCHAR(50),ADJUSTMENTTYPE VARCHAR(2),PREVIOUSQUANTITY FLOAT,ADJUSTEDQUANTITY FLOAT,REASON VARCHAR(50),OTHERS VARCHAR(100),FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID))", "CREATE TABLE ARCPURCHASEORDER(POID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID INT,ORDERDATE VARCHAR(50),EXPECTEDORDERDATE VARCHAR(50),SUPPLIERID INT,SUPPLIER VARCHAR(50),TIMES VARCHAR(50),TOTALPRODUCTS VARCHAR(50),TOTALCOST FLOAT,ORDERSTATUS VARCHAR(2),FOREIGN  KEY (USERID) REFERENCES ARCUSERS(USERID) ON DELETE CASCADE);", "CREATE TABLE ARCPOITEMORDERTABLE(ORDERID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,USERID iNT,POID INT,ITEMID INT,QUANTITY INT,PRODUCTNAME VARCHAR(50),ORIGINALPRICE FLOAT,TOTAL FLOAT,FOREIGN KEY (USERID) REFERENCES ARCUSERS(USERID)ON DELETE CASCADE);", "CREATE TABLE ARCPOVENDORINFO(ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),FOREIGN KEY(POID) REFERENCES ARCPURCHASEORDER(POID) ON DELETE CASCADE);", "CREATE TABLE ARCPOSHIPTOINFO(ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,POID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNO VARCHAR(50),COMPANYADDRESS VARCHAR(50),REMARKS VARCHAR(100),FOREIGN KEY(POID) REFERENCES ARCPURCHASEORDER(POID) ON DELETE CASCADE);" };
            con1.ConnectionString = IPtouse;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", con1);
            foreach (String i in Querys)
            {
                scom1.CommandText = i.ToString();
                scom1.ExecuteNonQuery();
                Thread.Sleep(200);//delay
            }
            con1.Close();
        }
        //===========================================================================================================================
        public static String loadpath()
        {
            ///create a functiom for Database path to loadd 
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//" + "JUFAVSQLITE" + "//" + "jufavdb.sqlite";

            return path;
        }
        public static int getID(String username)
        {
            int id = 0;
            //database not open
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT USERIDS FROM USER_INFO WHERE USERNAME ='" + username + "';", con1);
            
           id = Convert.ToInt32(scom1.ExecuteScalar());
          
           
            return id;
        }
        //==============================CRUD OPERATIONS================================
      
        public static void opendatabase()
        {
            try
            {


                con1.Open();
            }
            catch (Exception e)
            {



            }
           
            /*
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SHOW DATABASES LIKE 'JUFAV2%';", con1);
            bool ISexisting = determineval(scom1.ExecuteScalar().ToString());
            if (ISexisting == true)
            {
                con1.ConnectionString = @"server=192.168.1.100; user = root; password = zxcvbnm12; port = 3306;";
                con1.Open();
            }
           */
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


        public static void closedatabase()
        {
            
            con1.Close();
          //  con1.ConnectionString = "";
          
        }
        //insertion/deletion/update/retreival
        
      

    }
}
