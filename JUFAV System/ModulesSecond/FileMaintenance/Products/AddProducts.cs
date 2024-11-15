using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;


namespace JUFAV_System.ModulesSecond.FileMaintenance.Products
{
    public partial class AddProducts : UserControl
    {
        Dictionary<string,int> category;
        Dictionary<string,int> Subcategory;
        Dictionary<string,int> UoM;
        Dictionary<string, int> Supplier;
        Dictionary<string, double> SubcategoryMarkup;

        Hashtable categoryinfo;
        int summonmode;
        int idtoedit1;
        int quantity = 0;
        int batchcount = 0;
        int idbatch = 0;
        double markuptuse;
       bool isverfied1 = true;
       bool isverfied2 = true;
        bool isverfied4;
        bool isverfied5 = true;
        bool isverfied6 = true;
        public AddProducts(int summontype, int idtoedit)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            summonmode = summontype;
            category = new Dictionary<string , int>();
            Subcategory = new Dictionary<string, int>();
            UoM = new Dictionary<string, int>();
            categoryinfo = new Hashtable();
            Supplier = new Dictionary<string, int>();
            SubcategoryMarkup = new Dictionary<string, double>();
            initd.QueryIDsProd.Clear();
           // Supplier.Add("Unknown",00000);
            //splcmbox.Items.Add("Unknown");
            //note na dapatat mag iinsert sya ng name ng product

            if (summontype == 0)
            {
                LoadAsUpdate();
                idtoedit1 = idtoedit;
                Suplir.Visible = true;
                splcmbox.Visible = true;
                label9.Enabled = false;
                InitialStcktxtbox.Enabled = false;
                addMainBTN.Text = "UPDATE PRODUCT";

            }
            else
            {
              
              
                onload();
                OnloadIDBatch();

            }
           

        }
        private void onload()
        {
            category.Clear();
            Subcategory.Clear();
            UoM.Clear();
         
            Supplier.Clear();
            SubcategoryMarkup.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                CategoryCOmbo.Items.Add(sq1["CATEGORYDESC"]);
                category.Add(sq1["CATEGORYDESC"].ToString(),Convert.ToInt32(sq1["CATEGORYID"]));
               


            }
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                SubCatCombo.Items.Add(sq1["SUBCATEGORYDESC"]);
                Subcategory.Add(sq1["SUBCATEGORYDESC"].ToString(),Convert.ToInt32(sq1["SUBCATEGORYID"]));
                SubcategoryMarkup.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToDouble(sq1["MARKUPVALUE"]));
               
            }
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Unittypecombobox.Items.Add(sq1["UNITDESC"]);
                UoM.Add(sq1["UNITDESC"].ToString(),Convert.ToInt32(sq1["UNITID"]));
               
            }
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM SUPPLIERS";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                splcmbox.Items.Add(sq1["SUPPLIERNAME"].ToString());
                Supplier.Add(sq1["SUPPLIERNAME"].ToString(), Convert.ToInt32(sq1["SUPPLIERID"]));

            }
            sq1 = null;
            scom1 = null;

        }
        private void OnloadIDBatch()
        {
            SQLiteCommand sq1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread1;
            sq1.CommandText = "SELECT COUNT(*) AS TOTAL FROM PRODUCTS;";
            sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                idbatch = Convert.ToInt32(sread1["TOTAL"]) + 1;
            }
            sread1.Close();
            sread1 = null;
            sq1 = null;
        }
        private void insert()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand sq1 = new SQLiteCommand("", initd.scon);
            //auto increment or manual generation ID?id say auto increment sinceproducts are too many
            //"
           
                // Convert.ToInt32(Supplier[splcmbox.Text]) supplier 
                sq1.CommandText = "INSERT INTO PRODUCTS (USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY)VALUES(" + initd.UserID + "," + Convert.ToInt32(category[CategoryCOmbo.Text]) + "," + Convert.ToInt32(Subcategory[SubCatCombo.Text]) + "," + Convert.ToInt32(UoM[Unittypecombobox.Text]) + ",'" + Prodnametxtbox.Text.ToLower() + "'," + Convert.ToInt32(OriginalPricetxtbox.Text) + "," + markuptuse + "," + Convert.ToDouble(InitialStcktxtbox.Text) + ");";
                sq1.ExecuteNonQuery();




            //USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT NOT NULL,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,QUANTITY INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE DATE
            INSERTTODBSUPPLIERLIST(sq1);
            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD PRODUCT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();

        }
        private void update()
        {
            int IDtoEDIT = 0;




        }
        private void LoadAsUpdate()
        {



        }
        private void onload2Filter(String texttofilter)
        {
            categoryinfo.Clear();
            SubCatCombo.Items.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM CATEGORY WHERE CATEGORYDESC = '" + texttofilter + "';", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                categoryinfo.Add(sq1["CATEGORYDESC"], sq1["CATEGORYID"]);

            }
            sq1.Close();
            scom1.CommandText = "SELECT * FROM SUBCATEGORY WHERE CATEGORYID = " + Convert.ToInt32(categoryinfo[texttofilter]) + ";";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                SubCatCombo.Items.Add(sq1["SUBCATEGORYDESC"]);


            }



        }
        public void verify(int summonmode)
        {
            isverfied1 = true;
            isverfied2 = true;
            isverfied4 = true;
            //define
             //mag kasama ung text number field and integer
            Control[] textboxes = { CategoryCOmbo,SubCatCombo,Prodnametxtbox,OriginalPricetxtbox,Unittypecombobox,InitialStcktxtbox};
            PictureBox[] notificationimage = {CatSubIm, CatSubIm, ProdnameImg, OrigPUnitImg, OrigPUnitImg, InitStckImg };
            Label[] textnoti = { Catnot, Catnot, ProdnameNot, OrigPriceUnittypenot, OrigPriceUnittypenot, initnot};
            //check pass and conf is =
            if (CategoryCOmbo.Text == "" || SubCatCombo.Text == "" || Prodnametxtbox.Text == "" || OriginalPricetxtbox.Text == "" || Unittypecombobox.Text == "" || InitialStcktxtbox.Text == "")
            {
                for (int i = 0; i != 6; i++)
                {
                    if (textboxes[i].Text == "")
                    {
                        // MessageBox.Show("error please Enter input from textbox text : " + textboxes[i].Name);
                        notificationimage[i].Visible = true;
                        textnoti[i].Visible = true;
                        isverfied1 = false;
                        break;
                    }
                }


            }
            else
            {
                for (int i = 0; i != 6; i++)
                {
                    // \\W\\S
                    if (Regex.IsMatch(textboxes[i].Text, @"[^a-zA-Z0-9\s]"))
                    {
                        Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                        ms.Show();
                        isverfied2 = false;
                        break;
                    }
                }
            }      
            //detect dupplication
            if (summonmode != 0) { 
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { Prodnametxtbox.Text.ToLower() }, 5) == false)
                {
                    isverfied4 = false;
                }
            }
            else
            {

                isverfied4 = true;

            }
            //determine markup if has noncharacter or whitespace
            if (summonmode != 0)
            {
                if (isverfied2 == true && isverfied1 == true && DetermineMarkup() == false)
                {
                    isverfied5 = false;
                }
                else
                {
                    isverfied5 = true;
                }
            }
            if (summonmode != 0)
            {
                if (isverfied2 == true && isverfied1 == true && isverfied5 == true && determineifhassupplier() == false)
                {
                    isverfied6 = false;
                }
                else
                {
                    isverfied6 = true;
                }
            }
            //insertion
                if (isverfied2 == true && isverfied1 == true && isverfied4 == true && isverfied5 == true && verify2() == true && isverfied6 == true)
            {
                if (summonmode == 1)
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(insert, 0, "ADD NEW PRODUCT", "ARE YOU SURE YOU WANT TO ADD THIS NEW PRODUCT?", "ADD", 2);
                    msg1.Show();
                }
                else
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(update, 0, "UPDATE PRODUCT", "ARE YOU SURE YOU WANT TO UPDATE THIS PRODUCT?", "UPDATE", 2);
                    msg1.Show();
                }
            }
        }
        private bool determineifhassupplier()
        {
            bool test1 = true;
            if (ITEMSBOXSPLR.Controls.Count == 0)
            {
                splrnot.Visible = true;
                splrlabel.Visible = true;
                test1 = false;
            }
            return test1;
        }
        public void hide()
        {

            PictureBox[] notificationimage = { CatSubIm, CatSubIm,splrnot, ProdnameImg, MarkUp, OrigPUnitImg, OrigPUnitImg, InitStckImg };
            Label[] textnoti = { Catnot, Catnot, ProdnameNot,splrlabel, MKupnot, OrigPriceUnittypenot, OrigPriceUnittypenot, initnot };
            for (int i = 0; i != 6; i++)
            {


                notificationimage[i].Visible = false;
                textnoti[i].Visible = false;



            }

        }
        public bool verify2()
        {
            bool isverified3 = true;
            Control[] textboxes = { OriginalPricetxtbox, InitialStcktxtbox };
            for (int i = 0;i<= 1;i++)
            {
                if (Regex.IsMatch(textboxes[i].Text,@"[^0-9]"))
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON NUMBER INPUT", "Please Remove a non - Number character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                    ms.Show();
                    isverified3 = false;
                    break;
                } 

            }
            return isverified3;

        }       
        private int determinevalue2(bool text)
        {
            int ret = 0;
            if (text == true)
            {
                ret = 1;


            }
            else
            {
                ret = 0;


            }

            return ret;
        }
        private bool DetermineMarkup()
        {
            bool verify = true;
            if (mkuptxtbox1.Text == "leave blank if not use")
            {
                markuptuse = Convert.ToDouble(SubcategoryMarkup[SubCatCombo.Text.ToString()]);//key was not found
                mkuptxtbox1.Text = markuptuse.ToString();
                label6.Text = "CURRENT MARK-UP : " + SubcategoryMarkup[SubCatCombo.Text.ToString()].ToString();

            }

            else if (Regex.IsMatch(mkuptxtbox1.Text, @"[^0-9]"))
            {
                verify = false;
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON NUMBER INPUT", "Please Remove a non number character in custom Markup field.", "RETRY", 1);
                ms.Show();
            }
            if (verify == true)
            {
                markuptuse = Convert.ToDouble(mkuptxtbox1.Text);
            }
            return verify;
        }    
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Products unit1 = new ModulesMain.FILEMAINTENANCE.Products();
            ResponsiveUI1.title = "Products";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }  
        private int GenerateIDBatch()
        {
           
           //for id ng query use auto increment sa BatchID
            String ID = "";
            Random ra1 = new Random();
            for (int i= 0;i!= 8;i++)
            {
                ID = ID + ra1.Next(0,9).ToString();
            }
            ra1 = null;
            GC.Collect();
            return Convert.ToInt32(ID);
        }
        private void adddQuery()
        {
            if (batchcount >= 19)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "BATCH CREATION", "BATCH LIMIT REACHED UNABLE TO ADD MORE BATCH.", "RETRY", 2);
                ms.Show();
            }
            else
            {
                //error ehrer
                // int id1 = GenerateIDBatch();
                //  initd.QueryIDsProd.Add(id1, "INSERT INTO PRODUCTBATCH(PRODUCTID,PRODUCTDESC,BATCHNO,QUANTITY,EXPIRATIONDATE) VALUES ("+idbatch+",'"+ Prodnametxtbox.Text + "','" + Batchno1.Text + "',"+ Convert.ToInt32(StockQuantitytxtbox.Text) + ",'" + DateTime.Parse(dateexpiration.Text).ToShortDateString() + "');");//how to get product ID
                // Components.BatchDataBox pas1 = new Components.BatchDataBox(Prodnametxtbox.Text, Batchno1.Text, dateexpiration.Text, Convert.ToInt32(StockQuantitytxtbox.Text), id1);

                //  batchcount++;CURRENT MARK-UP : 
            }
        }       
        private void AddBatchBTn_Click(object sender, EventArgs e)
        {
            //dito mangagaling QUERY ID autoincrement ang batchproduct
            adddQuery();
        }
        private void CANCELBTN_Click(object sender, EventArgs e)
        {
            goback();
        }     
        private void CategoryCOmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            onload2Filter(CategoryCOmbo.Text);
            SubCatCombo.ResetText();
        }
        private void addMainBTN_Click(object sender, EventArgs e)
        {
           
           hide();
           verify(summonmode);//insertion na to 
            /*
            if (isverfied4 == false)
            {
                verify2();
                DetermineMarkup();
                
            }
           */
    
        }
        private void AddProducts_Leave(object sender, EventArgs e)
        {
            category = null;
            Subcategory = null;
            UoM = null;
            categoryinfo = null;
          
            GC.Collect();
        }
        private void SubCatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = SubcategoryMarkup[SubCatCombo.Text.ToString()].ToString();
            mkuptxtbox1.Text = SubcategoryMarkup[SubCatCombo.Text.ToString()].ToString();
            if (OriginalPricetxtbox.Text == "")
            {
                OriginalPricetxtbox.Text = 0.ToString();
            }
            if (Regex.IsMatch(OriginalPricetxtbox.Text, @"[^0-9]") == false)
            {
                totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();
            }
           
        }
        private void mkuptxtbox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = mkuptxtbox1.Text;
        }     
        private void itemsBox_ControlRemoved(object sender, ControlEventArgs e)
        {
           // batchcount--;
            //Batchno1.SelectedIndex--;
            
        }
        private void mkuptxtbox1_Click(object sender, EventArgs e)
        {
            if (mkuptxtbox1.Text == "leave blank if not use")
            {
                mkuptxtbox1.Text = 0.ToString();
            }
                

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
              
                mkuptxtbox1.Enabled = true;
            }
            else
            {
                
                mkuptxtbox1.Enabled = false;
                mkuptxtbox1.Text = "leave blank if not use";
            }
        }
        private void InitialStcktxtbox_TextChanged(object sender, EventArgs e)
        {

            if (InitialStcktxtbox.Text != "0")
            {
                //CREATE TABLE SUPPLIERLISTPROD(SUPPLIERLISTID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,PRODUCTID INT,COMPANYNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUM VARCHAR(50),ADDRESS VARCHAR(50));



            }
        }
        private void OriginalPricetxtbox_TextChanged(object sender, EventArgs e)
        {
            if (OriginalPricetxtbox.Text == "")
            {
                OriginalPricetxtbox.Text = 0.ToString();
            }
            if (Regex.IsMatch(OriginalPricetxtbox.Text,@"[^0-9]") == false && Regex.IsMatch(label6.Text, @"[^0-9]") == false)
            {
                totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();
            }
        }
        private void ADDNEWSPLR_Click(object sender, EventArgs e)
        {
            int lastid = grablastID();
            Messageboxes.newsupplierAddProd Addsupp = new Messageboxes.newsupplierAddProd(ITEMSBOXSPLR,lastid,reloadSupplier);
            Addsupp.ShowDialog();
        }
        private int grablastID()
        {
            int ID = 0;
            SQLiteCommand sq1 = new SQLiteCommand("SELECT PRODUCTID FROM PRODUCTS ORDER BY PRODUCTID DESC LIMIT 1;", initd.scon);
            ID = Convert.ToInt32(sq1.ExecuteScalar());
            return ID + 1;
        }
        private void reloadSupplier()
        {
            splcmbox.Items.Clear();
            Supplier.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT  * FROM SUPPLIERS;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();    
            while (sq1.Read())
            {
                splcmbox.Items.Add(sq1["SUPPLIERNAME"].ToString());
                Supplier.Add(sq1["SUPPLIERNAME"].ToString(), Convert.ToInt32(sq1["SUPPLIERID"]));
            }
        }
        private void addsupplier()
        {
            //process kung saan mag aadd ka ng list.
            bool test1 = true;
            String con = "";
            foreach (UserControl i in ITEMSBOXSPLR.Controls)
            {
                con = i.Controls.Find("label1",true)[0].Text;
                if (splcmbox.Text == con)
                {
                    test1 = false;
                }
            }
            if (test1 == false)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "EXISTING SUPPLIER", "SUPPLIER ALREADY EXIST IN THE LIST.", "RETRY", 2);
                ms.Show();
            }
            else
            {
                SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERID = " + Supplier[splcmbox.Text] + ";", initd.scon);
                SQLiteDataReader sq1 = scom1.ExecuteReader();
                while (sq1.Read())
                {
                    //generate ng query kung saan mag iinsert ito sa supplier table list ng product
                    Components.SupplierComponentAddprod supComp = new Components.SupplierComponentAddprod(sq1["SUPPLIERNAME"].ToString(), sq1["CONTACTPERSON"].ToString(), sq1["CONTACTNUMBER"].ToString(), sq1["COMPANYADDRESS"].ToString(),generateQueryAndID(sq1["SUPPLIERNAME"].ToString(), sq1["CONTACTPERSON"].ToString(), sq1["CONTACTNUMBER"].ToString(), sq1["COMPANYADDRESS"].ToString()),0);
                    ITEMSBOXSPLR.Controls.Add(supComp);
                }
                sq1.Close();
                sq1 = null;
                scom1 = null;
            }
        }
        private int generateQueryAndID(String compname,String Cntacperson,String contactnum,String Address)
        {
          
            String ID = "";
            Random ran1 = new Random();
            for (int i = 0;i != 7;i++)
            {
                ID = ID + ran1.Next(1, 9).ToString();
            }
            ran1 = null;
            GC.Collect();
            //for displaying //need ng junction table
            int idtouse = grablastID();
            Console.WriteLine("ID TO USE SUPLPRODLIST" + idtouse);
            initd.QueryIDsProd.Add(Convert.ToInt32(ID),"INSERT INTO SUPPLIERLISTPROD(PRODUCTID,COMPANYNAME,CONTACTPERSON,CONTACTNUM,ADDRESS) VALUES ("+idtouse+",'"+compname+"','"+Cntacperson+"','"+contactnum+"','" +Address+"');");
            return Convert.ToInt32(ID);
        }
        private void INSERTTODBSUPPLIERLIST(SQLiteCommand sq1){
            //dito eexecute ung mga query
            foreach (KeyValuePair<int,String> i in initd.QueryIDsProd)
            {
                sq1.CommandText = i.Value;
                sq1.ExecuteNonQuery();
            }
        }
        private void addtolistbtn_Click(object sender, EventArgs e)
        {
            if (splcmbox.Text == "")
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NO SUPPLIER SELECTED", "NO SUPPLIER HAS SELECTED PLEASE SELECT SUPPLIER FIRST IN THE COMBOBOX", "RETRY", 2);
                ms.Show();
            }
            else
            {
                addsupplier();

            }
        }
        //ONclOSE ALL HASTABLE WILL BE VANISHED
    }
}
