using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Threading;
using System.Text.RegularExpressions;



namespace JUFAV_System.ModulesSecond.Inventory
{
    public partial class AddPurchaseOrder : UserControl
    {
        Dictionary<String, int> splr1;
        Dictionary<int, String> UOM1;
        private static int total = 0;
        int swtichtriger = 0;
        bool test3 = true;

        //POID ay global
        //find way na kapag nag insert sya nanamn ng same item mag aad nalng sa same container
        //use find(); gaya nung sa pag tally ng total value
        //in custom supplier if the PO was created the supplier supplied will be inserted at the suppliers table too
        //humiliation huh?
        public AddPurchaseOrder()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            initd.toexe = this;
            splr1 = new Dictionary<String, int>();
            UOM1 = new Dictionary<int, string>();
            loaddatabase();
            dateissued.Text = "DATE ISSUED: " + DateTime.Now.ToShortDateString(); ;
            generatePOID();
            initd.itemsboxselectedPO = ItemsBoxPoList;
            label1.Text = "P.O NUMBER : PO-" + initd.POID.ToString();

            autoselect();
            filterer();
            swtichtriger = 1;
            DefaultAddress.Checked = true;
        }
        private void findsimilar()
        {
            // ProducName1
            foreach (UserControl i in ItemsBoxPoList.Controls)
            {
                Console.WriteLine(i.Controls.Find("ProducName1", true)[0].Text);
            }

        }

        public void loaddatabase()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            splr1.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUPPLIERS", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                splr1.Add(sread1["SUPPLIERNAME"].ToString(), Convert.ToInt32(sread1["SUPPLIERID"]));
                splrCMBox.Items.Add(sread1["SUPPLIERNAME"].ToString());
                SUPPLIERNAME.Items.Add(sread1["SUPPLIERNAME"].ToString());
            }
            sread1.Close();
            scom1.CommandText = "SELECT * FROM UNITOFMEASURE;";
            sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                UOM1.Add(Convert.ToInt32(sread1["UNITID"]), sread1["UNITDESC"].ToString());
            }
            sread1.Close();

            if (splr1.Count != 0)
            {
                splrCMBox.SelectedIndex = 0;
                //
                scom1.CommandText = "SELECT p.* FROM PRODUCTS p JOIN PRODUCTSUPPLIER sp ON p.PRODUCTID = sp.PRODUCTID WHERE sp.SUPPLIERID = " + splr1[splrCMBox.Text] + ";";
                sread1 = scom1.ExecuteReader();
                while (sread1.Read())
                {
                    //insert into items box
                    ///ItemsBoxOfferd.Controls.Add();

                    Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), "", Convert.ToInt32(sread1["PRODUCTID"]), ItemsBoxPoList);
                    ItemsBoxOfferd.Controls.Add(prod1);
                }
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
            swtichtriger = 1;//once na maging 1 ito pwede nang tawagin ung function na splr_SelectedIndexChanged to filter inputs pag naka 0 kasi walang trigger and madoudouble yung  call ng function na splr_SelectedIndexChanged
            GC.Collect();
         initd.con1.Close();
        }
        private void filterer()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            //delete all items
            //bug dito 
            if (SUPPLIERNAME.Items.Count != 0)
            {

                foreach (UserControl items in ItemsBoxOfferd.Controls) { items.Dispose(); }
                ItemsBoxOfferd.Controls.Clear();
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT p.* FROM PRODUCTS p JOIN PRODUCTSUPPLIER sp ON p.PRODUCTID = sp.PRODUCTID WHERE sp.SUPPLIERID = " + splr1[splrCMBox.Text] + ";", initd.con1);
                MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
                while (sread1.Read())
                {
                    Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), "", Convert.ToInt32(sread1["PRODUCTID"]), ItemsBoxPoList);
                    ItemsBoxOfferd.Controls.Add(prod1);
                }
                sread1.Close();
                scom1 = null;
                sread1 = null;

            }
         initd.con1.Close();
        }
        public void totalall()
        {
            initd.number.Clear();
            GC.Collect();
            foreach (UserControl i in ItemsBoxPoList.Controls)
            {
                initd.number.Add(Convert.ToDouble(i.Controls.Find("TotalValue", true)[0].Text));
            }

            //verifier for non character input
            totalamount.Text = initd.number.Sum().ToString() + ".00";
        }
        private void generatePOID()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT POID FROM PURCHASEORDER ORDER BY POID DESC LIMIT 1;", initd.con1);
            int idtouse = Convert.ToInt32(scom1.ExecuteScalar()) + 1;
            initd.POID = Convert.ToInt32(idtouse);
            initd.con1.Close();
        }
        private int generateOrder()
        {
            String id = "";
            Random ran1 = new Random();
            for (int i = 0; i != 6; i++)
            {
                id = id + ran1.Next(1, 10);
            }
            ran1 = null;
            return Convert.ToInt32(id);
            id = "";
            GC.Collect();
        }
        private void autoselect()
        {
            if (SUPPLIERNAME.Items.Count != 0)
            {
                SUPPLIERNAME.SelectedIndex = 0;
            }
        }
        //ung order status dapat pag pinindot 
        private int determinesuppID()
        {
            int id = 0;

            id = Convert.ToInt32(splr1[SUPPLIERNAME.Text]);


            //Create its own ID
            foreach (char i in "1111111")
            {
                id = id + new Random().Next(1, 9);
            }
            GC.Collect();

            return id;
        }
        private String determinesuppNAME()
        {
            String name = "";
            name = SUPPLIERNAME.Text;
            return name;
        }
        private void insertinto()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            if (ItemsBoxPoList.Controls.Count != 0)
            {
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO PURCHASEORDER (POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIERID,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS) VALUES (" + initd.POID + "," + initd.UserID + ",'" + DateTime.Now.ToShortDateString() + "','" + dateTimePicker1.Text + "'," + determinesuppID() + ",'" + determinesuppNAME() + "','" + DateTime.Now.ToShortTimeString() + "','" + ItemsBoxPoList.Controls.Count + "'," + Convert.ToDouble(totalamount.Text) + ",'PENDING');", initd.con1);
                scom1.ExecuteNonQuery();
                foreach (KeyValuePair<int, String> i in initd.QueryID)
                {
                    scom1.CommandText = i.Value;//foreign key constraint failed
                    scom1.ExecuteNonQuery();
                    Thread.Sleep(100);
                }
                //Vendor info

                //if no selected please insert data first
                scom1.CommandText = "INSERT INTO POVENDORINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS) VALUES (" + generateOrder() + "," + initd.POID + ",'" + SUPPLIERNAME.Text + "','" + ContactPer.Text + "','" + ContactNo.Text + "','" + ADdresss.Text + "');";
                scom1.ExecuteNonQuery();

                scom1.CommandText = "INSERT INTO POSHIPTOINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS,REMARKS) VALUES (" + generateOrder() + "," + initd.POID + ",'" + CompanynameShipto.Text + "','" + ContactPersonShipTo.Text + "','" + ContactPersonShipTo.Text + "','" + AddressShipto.Text + "','" + Remarks.Text + "');";
                scom1.ExecuteNonQuery();
                scom1 = null;
                GC.Collect();
                // scom1.CommandText = "";
                //scom1.ExecuteNonQuery();
                //insert sa suppliers at information ng "shipto"
                //tig isang table for Customsupplier at shipto
                //dun muna ung supplier until mareceive na ni user ? or insert agad? .
                Messageboxes.MessageboxConfirmation msgsuccess = new Messageboxes.MessageboxConfirmation(Goback, 0, "CREATE P.O", "PURCHASE ORDER SUCCESSFULLY CREATED!", "OK", 0);
                msgsuccess.Show();
            }
            else
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "EMPTY ORDER", "PLEASE CHOOSE ATLEAST 1-2 ITEMS TO CREATE A PURCHASE ORDER", "OK", 2);
                ms.Show();
            }
            this.Cursor = Cursors.Default;
           initd.con1.Close();
        }
        private void Goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.INVENTORY.PurchaseOrder unit1 = new ModulesMain.INVENTORY.PurchaseOrder();
            ResponsiveUI1.title = "PurchaseOrder";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);
        }
        private void verifydatainputs()
        {
            //checks fo null and non character inputs in each text boxes
            int breaker = 0;
            bool test1 = false;
            bool test2 = false;
            Control containertometion = null;
            Panel[] panels = { SHIPTO, TOTAL_VALUE, REMARKS_PANEL };
            foreach (Panel b in panels)
            {
                foreach (Control i in b.Controls)
                {
                    if (Regex.IsMatch(i.Text, @"(--|[-'_])"))
                    {
                        containertometion = i;
                        test1 = false;
                        breaker = 1;
                        break;
                    }
                    else if (i.Text == "")
                    {
                        containertometion = i;
                        test2 = false;
                        breaker = 2;
                        break;
                    }
                    else
                    {
                        test1 = true;
                        test2 = true;
                    }
                }
                if (breaker == 1)
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in panel : '" + b.Name + "' where text in this field : " + containertometion.Name + " : '" + containertometion.Text + "' contains the non letter character.", "RETRY", 1);
                    ms.Show();
                    break;
                }
                else if (breaker == 2)
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NO DATA INPUTTED", "Please please provide informaion in panel : '" + b.Name + "' where text in this : " + containertometion.Name + " : '" + containertometion.Text + "' contains no value.", "RETRY", 1);
                    ms.Show();
                    break;
                }

            }



            if (test1 == true && test2 == true)//
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(insertinto, 0, "CREATE P.O", "ARE YOU SURE YOU INPUTTED THE RIGHT DATA?", "OK", 2);
                ms.Show();

            }
        }
        private bool determineifSupplierhasPO()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            bool pak = true;
            //sqlite querry
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PURCHASEORDER WHERE ORDERSTATUS = 'PENDING';", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (sread1["SUPPLIER"].ToString() == determinesuppNAME())
                {
                    pak = false;
                    break;
                }
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
           initd.con1.Close();
            return pak;
        }
        private void splr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //once na maging 1 ito pwede nang tawagin ung function na splr_SelectedIndexChanged to filter inputs pag naka 0 kasior walang trigger na if else,madoudouble yung  call ng function na splr_SelectedIndexChanged
            /*
            if (swtichtriger == 1)
            {
                filterer();
            }
            */
        }
        private void AddPurchaseOrder_Leave(object sender, EventArgs e)
        {
            //kapag nag leave na si purchase order panel mag tatangal  tayo ng mga variables and array na naka allocate sa memory
            splr1 = null;
            initd.toexe = null;
            GC.Collect();   //garbage collector responsible for collecting null variables to clean from  memory   
        }
        private void ItemsBoxPoList_ControlAdded(object sender, ControlEventArgs e)
        {
            totalall();
        }
        private void DefaultAddress_CheckStateChanged(object sender, EventArgs e)
        {
            if (DefaultAddress.Checked == false)
            {
                CompanynameShipto.Text = "";
                AddressShipto.Text = "";
                ContactNoShipto.Text = "";
                ContactPersonShipTo.Text = "";
                foreach (Control i in SHIPTO.Controls)
                {
                    i.Enabled = true;
                }
            }
            else
            {
                CompanynameShipto.Text = "JUFAV CONSTRUCTION AND SUPPLY";
                AddressShipto.Text = "ZONE 6,SITIO MALIGAYA, MALIWALO, TARLAC CITY";
                ContactNoShipto.Text = "+63 9566797330 , +63 9420108528";
                ContactPersonShipTo.Text = " Lanie Vinluan";
                foreach (Control i in SHIPTO.Controls)
                {
                    i.Enabled = false;

                }
                label31.Enabled = true;
                DefaultAddress.Enabled = true;
                label4.Enabled = true;
            }
        }
        private void SUPPLIERNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            //kapag ung combobox na SUPPLIERNAME sa VendorInfo ay napalitan kukunin nya ung information  ng supplier na yun  tas ididisplay nya ung information tungkol dun sa supplier
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERID = " + Convert.ToInt32(splr1[SUPPLIERNAME.Text]) + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                ContactPer.Text = sread1["CONTACTPERSON"].ToString();
                ContactNo.Text = sread1["CONTACTNUMBER"].ToString();
                ADdresss.Text = sread1["COMPANYADDRESS"].ToString();
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
            initd.con1.Close();
        }
        private void CreatePO_Click(object sender, EventArgs e)
        {
            verifydatainputs();  //verify muna yung input sa textbox kung may laman ba o wala then sa loob nito  
        }
        private void CancelBTn_Click(object sender, EventArgs e)
        {
            Goback();
        }
        private void verifier(TextBox toscan)
        {
            //verify inputs first
            if (Regex.IsMatch(toscan.Text, @"^\d+$") == true)
            {
                totalall();
            }
            else
            {
                toscan.Text = 0.ToString();
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "INVALID INPUT", "INVALID INPUT DUE TO A NON NUMERIC CHARACTER", "OK", 2);
                ms.Show();
            }
        }

        private void splrCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (swtichtriger == 1)
            {
                filterer();
            }

        }
    }
}
