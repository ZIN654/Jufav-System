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
using System.Threading;


namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class Products : UserControl
    {
        Dictionary<int, String> catinfo1 = new Dictionary<int, String>();
        Dictionary<int, String> subcatinfo1 = new Dictionary<int, String>();
        Dictionary<int, int> subcatinfoMarkup = new Dictionary<int, int>();
        Dictionary<int, String> Uominfo1 = new Dictionary<int, String>();
        Dictionary<String, int> categoryinfo = new Dictionary<String, int>();
      

        //private String valuetofilter = "";
        public Products()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevent();
           onload2();
            onload();
            
        }
        public void addevent()
        {

            addprdBTN.Click += addprod;


        }
        private void addprod(object sender,EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Products.AddProducts prod1 = new ModulesSecond.FileMaintenance.Products.AddProducts(1,0);
            ResponsiveUI1.title = "AddProducts";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(prod1);


        }
        private void onload()
        {
            //use joins table AS

            //tables that are used :
            /*CATEGORY
             * SUBCATEGORY
             * MARKUP
             *PRODUCTS
             * SELECT t.sas,r.qwe FROM Tabl1 join table2 on t1.sad = t2.sad JOIN table3 s ON t1.sad = s.sad;
             * 
             */
            SQLiteCommand sq1 = new SQLiteCommand("SELECT * FROM PRODUCTS", initd.scon);
            SQLiteDataReader read1 = sq1.ExecuteReader();
            while (read1.Read())
            {
                //generic key not found
                Components.ProductComponent prod1 = new Components.ProductComponent(read1["PRODUCTNAME"].ToString(), catinfo1[Convert.ToInt32(read1["CATEGORYID"])],subcatinfo1[Convert.ToInt32(read1["SUBCATEGORYID"].ToString())], Convert.ToInt32(read1["QUANTITY"]),Uominfo1[Convert.ToInt32(read1["UOMID"])], Convert.ToDouble(read1["ORIGINALPICE"]),Convert.ToDouble(read1["ORIGINALPICE"]) + Convert.ToDouble(read1["MARKUPVALUE"]), Convert.ToInt32(read1["PRODUCTID"]));
                ItemsBox.Controls.Add(prod1);
                
            }


        }
        private void onloadArrays()
        {




        }
        private void onload2()
        {
            Uominfo1.Clear();
            catinfo1.Clear();
            subcatinfo1.Clear();
            categoryinfo.Clear();
            SubCatCombo.Items.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
               
                CategoryCombo.Items.Add(sq1["CATEGORYDESC"]);
                catinfo1.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT * FROM SUBCATEGORY;";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                SubCatCombo.Items.Add(sq1["SUBCATEGORYDESC"]);
                subcatinfo1.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT * FROM UNITOFMEASURE;";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                Uominfo1.Add(Convert.ToInt32(sq1["UNITID"]), sq1["UNITDESC"].ToString());

            }
            sq1.Close();
            sq1 = null;
            scom1 = null;
          //  GC.Collect();

        }
        private void onload2filter()
        {
            
            SubCatCombo.Items.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUBCATEGORY WHERE CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE CATEGORYDESC = '"+CategoryCombo.Text+"');", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
          
            while (sq1.Read())
            {
                SubCatCombo.Items.Add(sq1["SUBCATEGORYDESC"]);
            }



        }
        private void CategoryCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            SubCatCombo.ResetText();
            onload2filter();
            
          
        }
    }
}
