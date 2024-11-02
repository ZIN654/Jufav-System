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
        double markuptuse;
       bool isverfied1 = true;
       bool isverfied2 = true;
        bool isverfied4;
        bool isverfied5 = true;
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
           
           // Supplier.Add("Unknown",00000);
            //splcmbox.Items.Add("Unknown");
            //note na dapatat mag iinsert sya ng name ng product

            if (summontype == 0)
            {
                idtoedit1 = idtoedit;



            }
            else
            {
                label14.Text = Prodnametxtbox.Text;
                onload();
             

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
        private void insert()
        {

            this.Cursor = Cursors.WaitCursor;
            //auto increment or manual generation ID?id say auto increment sinceproducts are too many
            //USERID INT NOT NULL,CATEGORYID INT NOT NULL,SUBCATEGORYID INT NOT NULL,UOMID INT NOT NULL,PRODUCTNAME VARCHAR(50),ORIGINALPICE INT,QUANTITY INT,PERISHABLEPRODUCT VARCHAR(2),ISBATCH VARCHAR(2),EXPIRINGDATE DATE
            SQLiteCommand sq1 = new SQLiteCommand("INSERT INTO PRODUCTS (USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE)VALUES(" + initd.UserID + "," + Convert.ToInt32(category[CategoryCOmbo.Text])+"," + Convert.ToInt32(Subcategory[SubCatCombo.Text])+"," + Convert.ToInt32(UoM[Unittypecombobox.Text])+",'" +Prodnametxtbox.Text.ToLower()+"'," + Convert.ToInt32(OriginalPricetxtbox.Text)+","+markuptuse+"," + Convert.ToDouble(InitialStcktxtbox.Text) +"," + Convert.ToInt32(Supplier[splcmbox.Text]) + ","+determinevalue2(prsishablechbox.Checked) +"," +determinevalue()+",'" +date()+ "');",initd.scon);
            sq1.ExecuteNonQuery();

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD PRODUCT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();

        }
        private void update()
        {
            //updates the data of theitem except for the Quantity
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
            Control[] textboxes = { CategoryCOmbo,SubCatCombo,splcmbox,Prodnametxtbox,OriginalPricetxtbox,Unittypecombobox,InitialStcktxtbox};
            PictureBox[] notificationimage = {CatSubIm, CatSubIm,splrnot, ProdnameImg, OrigPUnitImg, OrigPUnitImg, InitStckImg };
            Label[] textnoti = { Catnot, Catnot, splrlabel, ProdnameNot, OrigPriceUnittypenot, OrigPriceUnittypenot, initnot};
            //check pass and conf is =
            if (CategoryCOmbo.Text == "" || SubCatCombo.Text == "" || Prodnametxtbox.Text == "" || OriginalPricetxtbox.Text == "" || Unittypecombobox.Text == "" || InitialStcktxtbox.Text == "")
            {
                for (int i = 0; i != 7; i++)
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
                for (int i = 0; i != 7; i++)
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

            //insertion
                if (isverfied2 == true && isverfied1 == true && isverfied4 == true && isverfied5 == true && verify2() == true)
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
        private int determinevalue()
        {
            int ret = 0;
            if (prsishablechbox.Checked == true && SingleProdBTN.Checked == false)
            {

                ret = 1;
                //non batch is equal to 1
            }
            else
            {
                //batch products is equal to zero
                ret = 0;


            }

            return ret;
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
        private String date()
        {
            string toret = "";
            if (prsishablechbox.Checked == false)
            {

                toret = "01/12/1999";
                //toret = DateTime.Parse("00/00/0000").ToShortDateString();

                //nonn perishable
            }
            else if (prsishablechbox.Checked == true && SingleProdBTN.Checked == true)
            {
                toret = DateTime.Parse(dateTimePicker1.Text).ToShortDateString();
          
                //peroshable single product
              
            }
            else
            {

                toret = "01/12/1999";
                //batch product

            }

            return toret;
        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Products unit1 = new ModulesMain.FILEMAINTENANCE.Products();
            ResponsiveUI1.title = "Products";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }  
        private void BatchProdRadioBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (BatchProdRadioBTN.Checked == true)
            {
                label14.Text = Prodnametxtbox.Text;

                SingleProdBTN.Checked = false;
                batchprodadd.Enabled = true;
                itemsBox.Enabled = true;
                
            }
            else
            {
                label14.Text = Prodnametxtbox.Text;

                SingleProdBTN.Checked = true;
                batchprodadd.Enabled = false;
                itemsBox.Enabled = false;

            }
        }
        private void SingleProdBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (SingleProdBTN.Checked == true)
            {
            
                BatchProdRadioBTN.Checked = false;
               

            }
            else
            {
                BatchProdRadioBTN.Checked = true;

            }
        }
        private void prsishablechbox_CheckedChanged(object sender, EventArgs e)
        {
            if (prsishablechbox.Checked == true)
            {
                //insert addbatch
                singlprod.Enabled = true;
                batchprod.Enabled = true;
                itemsBox.Enabled = true;

            }
            else
            {
                singlprod.Enabled = false;
                batchprod.Enabled = false;
                itemsBox.Enabled = false;


            }
        }
        private void AddBatchBTn_Click(object sender, EventArgs e)
        {
            //exeption messages and warning boxes bruh
           // Components.BatchingDataBox bt1 = new Components.BatchingDataBox(label14.Text,Batchno.Text,dateexpiration.Text,Convert.ToInt32(StockQuantitytxtbox.Text));
           // itemsBox.Controls.Add(bt1);
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
            label6.Text = "CURRENT MARK-UP : " + SubcategoryMarkup[SubCatCombo.Text.ToString()].ToString();
        }
        private void mkuptxtbox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "CURRENT MARK-UP : " + mkuptxtbox1.Text;
        }
        //ONclOSE ALL HASTABLE WILL BE VANISHED
    }
}
