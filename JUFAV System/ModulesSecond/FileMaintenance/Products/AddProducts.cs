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

using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;


namespace JUFAV_System.ModulesSecond.FileMaintenance.Products
{
    public partial class AddProducts : UserControl
    {
        Dictionary<string, int> category;
        Dictionary<string, int> Subcategory;
        Dictionary<string, int> UoM;
        Dictionary<string, int> Supplier;
        Dictionary<string, double> SubcategoryMarkup;


        Dictionary<int, string> categoryload;
        Dictionary<int, string> Subcategoryload;
        Dictionary<int, string> UoMload;
        Dictionary<int, string> Supplierload;
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
            categoryload = new Dictionary<int, string>();
            Subcategoryload = new Dictionary<int, string>();
            UoMload = new Dictionary<int, string>();
            Supplierload = new Dictionary<int, string>();


            category = new Dictionary<string, int>();
            Subcategory = new Dictionary<string, int>();
            UoM = new Dictionary<string, int>();
            categoryinfo = new Hashtable();
            Supplier = new Dictionary<string, int>();
            SubcategoryMarkup = new Dictionary<string, double>();
            initd.QueryIDsProd.Clear();
            idtoedit1 = idtoedit;
            // Supplier.Add("Unknown",00000);
            //splcmbox.Items.Add("Unknown");
            //note na dapatat mag iinsert sya ng name ng product
            onload();
            if (summontype == 0)
            {

                LoadAsUpdate();


                Suplir.Visible = true;
                splcmbox.Visible = true;
                label9.Enabled = false;
                InitialStcktxtbox.Enabled = false;
                totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();
                addMainBTN.Text = "UPDATE PRODUCT";

            }
            else
            {
                OnloadIDBatch();
            }


        }
        private void onload()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            category.Clear();
            Subcategory.Clear();
            UoM.Clear();

            Supplier.Clear();
            SubcategoryMarkup.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CATEGORY;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                CategoryCOmbo.Items.Add(sq1["CATEGORYDESC"]);
                category.Add(sq1["CATEGORYDESC"].ToString(), Convert.ToInt32(sq1["CATEGORYID"]));
                categoryload.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());


            }
          
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                SubCatCombo.Items.Add(sq1["SUBCATEGORYDESC"]);
                Subcategory.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToInt32(sq1["SUBCATEGORYID"]));
                SubcategoryMarkup.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToDouble(sq1["MARKUPVALUE"]));
                Subcategoryload.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                UoM.Add(sq1["UNITDESC"].ToString(), Convert.ToInt32(sq1["UNITID"]));


            }
            sq1.Close();
            scom1.CommandText = "SELECT  * FROM SUPPLIERS";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                splcmbox.Items.Add(sq1["SUPPLIERNAME"].ToString());
                Supplier.Add(sq1["SUPPLIERNAME"].ToString(), Convert.ToInt32(sq1["SUPPLIERID"]));

            }
            sq1.Close();
            sq1 = null;
            scom1 = null;
            initd.con1.Close();

        }
        private void OnloadIDBatch()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1;
            sq1.CommandText = "SELECT COUNT(*) AS TOTAL FROM PRODUCTS;";
            sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                idbatch = Convert.ToInt32(sread1["TOTAL"]) + 1;
            }
            sread1.Close();
            sread1 = null;
            sq1 = null;
            initd.con1.Close();
        }
        private void insert()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);
            //auto increment or manual generation ID?id say auto increment sinceproducts are too many
            //"

            // Convert.ToInt32(Supplier[splcmbox.Text]) supplier 
            sq1.CommandText = "INSERT INTO PRODUCTS (USERID,CATEGORYID,SUBCATEGORYID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY)VALUES(" + initd.UserID + "," + Convert.ToInt32(category[CategoryCOmbo.Text]) + "," + Convert.ToInt32(Subcategory[SubCatCombo.Text]) + ",'" + Prodnametxtbox.Text.ToLower() + "'," + Convert.ToInt32(OriginalPricetxtbox.Text) + "," + markuptuse + "," + Convert.ToDouble(InitialStcktxtbox.Text) + ");";
            sq1.ExecuteNonQuery();



            initd.con1.Close();
            //USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT NOT NULL,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,QUANTITY INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE DATE
            INSERTTODBSUPPLIERLIST(sq1);
            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD PRODUCT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
            

        }
        private void update()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE PRODUCTS SET CATEGORYID = " + category[CategoryCOmbo.Text] + ",SUBCATEGORYID = " + Subcategory[SubCatCombo.Text] + ",PRODUCTNAME = '" + Prodnametxtbox.Text + "',ORIGINALPICE = " + Convert.ToInt32(OriginalPricetxtbox.Text) + ",MARKUPVALUE = " + label6.Text + " WHERE PRODUCTID = " + idtoedit1 + ";", initd.con1);
            sq1.ExecuteNonQuery();
            //USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT NOT NULL,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,QUANTITY INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE DATE
            initd.con1.Close();
            INSERTTODBSUPPLIERLIST(sq1);
            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE PRODUCT", "PRODUCT SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();

            


        }
        private void LoadAsUpdate()
        {
            //no query  in the current reader
            // initd.con1.Close();
      
                if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT PRODUCTNAME, CATEGORYID, SUBCATEGORYID, ORIGINALPICE, QUANTITY, MARKUPVALUE FROM PRODUCTS WHERE PRODUCTID = " + idtoedit1 + ";", initd.con1);
                 
                MySql.Data.MySqlClient.MySqlDataReader sq4 = scom1.ExecuteReader();
            var subcat1 = 0;
            var cat1 = 0;
            while (sq4.Read())
            {
                //problem  here gwing normal na drop down tas pag ung ininput na cat ay wala invalid
                //here this two
                //nag loload dito pero sasubcat hinde
                Prodnametxtbox.Text = sq4["PRODUCTNAME"].ToString();
                OriginalPricetxtbox.Text = sq4["ORIGINALPICE"].ToString();
                InitialStcktxtbox.Text = sq4["QUANTITY"].ToString();
                label6.Text = sq4["MARKUPVALUE"].ToString();

                cat1 = Convert.ToInt32(sq4["CATEGORYID"]);
                subcat1 = Convert.ToInt32(sq4["SUBCATEGORYID"]);

                break;
                }
                CategoryCOmbo.Text = categoryload[cat1].ToString();
                SubCatCombo.Text = Subcategoryload[subcat1].ToString();
                
            
                 sq4.Close();
                initd.con1.Close();
                // loads also suppliers 
                if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
                scom1.CommandText = "SELECT sp.* FROM SUPPLIERS sp JOIN PRODUCTSUPPLIER ps ON sp.SUPPLIERID = ps.SUPPLIERID  WHERE ps.PRODUCTID = " + idtoedit1 + ";";
                sq4 = scom1.ExecuteReader();
                while (sq4.Read())
                {
                    Components.SupplierComponentAddprod supComp = new Components.SupplierComponentAddprod(sq4["SUPPLIERNAME"].ToString(), sq4["CONTACTPERSON"].ToString(), sq4["CONTACTNUMBER"].ToString(), sq4["COMPANYADDRESS"].ToString(), 000, 1, idtoedit1, Convert.ToInt32(sq4["SUPPLIERID"]));//nasa DB n ito so directa bura na agad        
                    ITEMSBOXSPLR.Controls.Add(supComp);

                }
                sq4.Close();
                sq4 = null;
                scom1 = null;
                initd.con1.Close();
                GC.Collect();
            
          
        }
        private void onload2Filter(String texttofilter)
        {
            initd.con1.Close();
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            categoryinfo.Clear();
            SubCatCombo.Items.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CATEGORY WHERE CATEGORYDESC = '" + texttofilter + "';", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
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
            sq1.Close();
            initd.con1.Close();


        }
        public void verify(int summonmode)
        {

            isverfied1 = true;
            isverfied2 = true;
            isverfied4 = true;
            //define
            //mag kasama ung text number field and integer
            Control[] textboxes = { CategoryCOmbo, SubCatCombo, Prodnametxtbox, OriginalPricetxtbox, InitialStcktxtbox };
            PictureBox[] notificationimage = { CatSubIm, CatSubIm, ProdnameImg, OrigPUnitImg, InitStckImg };
            Label[] textnoti = { Catnot, Catnot, ProdnameNot, OrigPriceUnittypenot, initnot };
            //check pass and conf is =
            if (CategoryCOmbo.Text == "" || SubCatCombo.Text == "" || Prodnametxtbox.Text == "" || OriginalPricetxtbox.Text == "" || InitialStcktxtbox.Text == "")
            {
                for (int i = 0; i != 5; i++)
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
                for (int i = 0; i != 5; i++)
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
            if (summonmode != 0)
            {
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

            PictureBox[] notificationimage = { CatSubIm, CatSubIm, splrnot, ProdnameImg, MarkUp, OrigPUnitImg, OrigPUnitImg, InitStckImg };
            Label[] textnoti = { Catnot, Catnot, ProdnameNot, splrlabel, MKupnot, OrigPriceUnittypenot, OrigPriceUnittypenot, initnot };
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
            for (int i = 0; i <= 1; i++)
            {
                if (Regex.IsMatch(textboxes[i].Text, @"[^0-9]"))
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
            for (int i = 0; i != 8; i++)
            {
                ID = ID + ra1.Next(0, 9).ToString();
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
            if (Regex.IsMatch(OriginalPricetxtbox.Text, @"[^0-9]") == false && Regex.IsMatch(label6.Text, @"[^0-9]") == false)
            {
                totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();
            }
        }
        private void itemsBox_ControlRemoved(object sender, ControlEventArgs e)
        {
            // batchcount--;
            //Batchno1.SelectedIndex--;

        }
        private void mkuptxtbox1_Click(object sender, EventArgs e)
        {
            mkuptxtbox1.SelectAll();
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
                if (SubCatCombo.Text == "")
                {

                    label6.Text = mkuptxtbox1.Text;
                }
                else
                {
                    mkuptxtbox1.Enabled = false;
                    mkuptxtbox1.Text = "leave blank if not use";
                    label6.Text = SubcategoryMarkup[SubCatCombo.Text].ToString();
                }

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
            if (Regex.IsMatch(OriginalPricetxtbox.Text, @"[^0-9]") == false && Regex.IsMatch(label6.Text, @"[^0-9]") == false)
            {
                totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();
            }
        }
        private void ADDNEWSPLR_Click(object sender, EventArgs e)
        {
            int lastid = grablastID();
            if (summonmode != 0)
            {
                Messageboxes.newsupplierAddProd Addsupp = new Messageboxes.newsupplierAddProd(ITEMSBOXSPLR, lastid, reloadSupplier);
                Addsupp.ShowDialog();

            }
            else
            {
                Messageboxes.newsupplierAddProd Addsupp = new Messageboxes.newsupplierAddProd(ITEMSBOXSPLR, idtoedit1, reloadSupplier);
                Addsupp.ShowDialog();

            }


        }
    
        private int grablastID()
        {
            int ID = 0;
            initd.con1.Close();
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            try
            {
                //error here 
             
                MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT PRODUCTID FROM PRODUCTS ORDER BY PRODUCTID DESC LIMIT 1;", initd.con1);
                ID = Convert.ToInt32(sq1.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION SA GRAB LAST ID");
                initd.con1.Close();
              

            }
            initd.con1.Close();
            return ID + 1;
          
        }
        private void reloadSupplier()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            splcmbox.Items.Clear();
            Supplier.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  * FROM SUPPLIERS;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                splcmbox.Items.Add(sq1["SUPPLIERNAME"].ToString());
                Supplier.Add(sq1["SUPPLIERNAME"].ToString(), Convert.ToInt32(sq1["SUPPLIERID"]));
            }
            sq1.Close();
            initd.con1.Close();
        }
        private void addsupplier()
        {
            //process kung saan mag aadd ka ng list.
            bool test1 = true;
            String con = "";
            foreach (UserControl i in ITEMSBOXSPLR.Controls)
            {
                con = i.Controls.Find("label1", true)[0].Text;
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
                if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
                MySql.Data.MySqlClient.MySqlCommand scom43 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERID = " + Supplier[splcmbox.Text] + ";", initd.con1);
                MySql.Data.MySqlClient.MySqlDataReader sq2 = scom43.ExecuteReader();
                while (sq2.Read())
                {
                    //generate ng query kung saan mag iinsert ito sa supplier table list ng product
                    Components.SupplierComponentAddprod supComp = new Components.SupplierComponentAddprod(sq2["SUPPLIERNAME"].ToString(), sq2["CONTACTPERSON"].ToString(), sq2["CONTACTNUMBER"].ToString(), sq2["COMPANYADDRESS"].ToString(), generateQueryAndID(), 0, idtoedit1, 000);//query ppalang to
                    Console.WriteLine("INSERTION NG SUPPLIER PROD " + Supplier[splcmbox.Text]);
                    ITEMSBOXSPLR.Controls.Add(supComp);
                    break;
                }
                sq2.Close();
                initd.con1.Close();
                sq2 = null;
                scom43 = null;
            }
        }
        private int generateQueryAndID()
        {

            String ID = "";
            Random ran1 = new Random();
            for (int i = 0; i != 7; i++)
            {
                ID = ID + ran1.Next(1, 9).ToString();
            }
            ran1 = null;
            GC.Collect();
            //kapag new product goods to pero pag editing 
            //bad dahil grab ny ung last ID tas aad sya ng new value

            int idtouse = grablastID();
            Console.WriteLine("ID TO USE SUPLPRODLIST" + idtouse);
            if (summonmode != 0)
            {

                initd.QueryIDsProd.Add(Convert.ToInt32(ID), "INSERT INTO PRODUCTSUPPLIER(PRODUCTID,SUPPLIERID) VALUES (" + idtouse + "," + Supplier[splcmbox.Text] + ");");//problem sa ID 

            }
            else
            {

                initd.QueryIDsProd.Add(Convert.ToInt32(ID), "INSERT INTO PRODUCTSUPPLIER(PRODUCTID,SUPPLIERID) VALUES (" + idtoedit1 + "," + Supplier[splcmbox.Text] + ");");//problem sa ID 
            }

            return Convert.ToInt32(ID);
        }
        private void INSERTTODBSUPPLIERLIST(MySql.Data.MySqlClient.MySqlCommand sq1)
        {

            //dito eexecute ung mga query
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            try
            {
                if (initd.QueryIDsProd.Count != 0)
                {
                    foreach (KeyValuePair<int, String> i in initd.QueryIDsProd)
                    {
                        sq1.CommandText = i.Value;
                        //update anomaly sa add ng new supplier
                        sq1.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {




            }
            initd.con1.Close();
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

        private void OriginalPricetxtbox_Click(object sender, EventArgs e)
        {
            OriginalPricetxtbox.SelectAll();
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(OriginalPricetxtbox.Text, @"[^0-9]") == false && Regex.IsMatch(label6.Text, @"[^0-9]") == false)
            {
                //ERRO EXCEPTION NON NUMBER INPUT
                if (OriginalPricetxtbox.Text == "" || label6.Text == "")
                {
                    OriginalPricetxtbox.Text = 0.ToString();
                    label6.Text = 0.ToString();
                }
                else
                {

                    totalSRP.Text = (Convert.ToDouble(OriginalPricetxtbox.Text) + Convert.ToDouble(label6.Text)).ToString();

                }

            }
        }

        private void InitialStcktxtbox_Click(object sender, EventArgs e)
        {
            InitialStcktxtbox.SelectAll();
        }

        private void CategoryCOmbo_TextChanged(object sender, EventArgs e)
        {
           
            CategoryCOmbo.SelectedIndex = CategoryCOmbo.FindString(CategoryCOmbo.Text);
            CategoryCOmbo.SelectAll();
            //verify or change to index1
            if (!CategoryCOmbo.Items.Contains(CategoryCOmbo.Text))
            {
                CategoryCOmbo.Text = "";
                //  CategoryCOmbo.SelectedIndex = 0;

            }
            if (!CategoryCOmbo.Items.Contains(CategoryCOmbo.Text) && CategoryCOmbo.Items.Count != 0)
            {
                CategoryCOmbo.Text = "";
              //  CategoryCOmbo.SelectedIndex = 0;
              
            }
            
        }

        private void SubCatCombo_TextChanged(object sender, EventArgs e)
        {

            SubCatCombo.SelectedIndex = SubCatCombo.FindString(SubCatCombo.Text);
            SubCatCombo.SelectAll();
            //verify or change to index1
            if (!SubCatCombo.Items.Contains(SubCatCombo.Text))
            {
                SubCatCombo.Text = "";
                //  SubCatCombo.SelectedIndex = 0;

            }
            if (!SubCatCombo.Items.Contains(SubCatCombo.Text) && SubCatCombo.Items.Count != 0)
            {
                SubCatCombo.Text = "";
              //  SubCatCombo.SelectedIndex = 0;
               
            }

        }
        //ONclOSE ALL HASTABLE WILL BE VANISHED
    }
}
