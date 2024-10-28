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
        private static int total = 0;
        int swtichtriger = 0;
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
            loaddatabase();
            dateissued.Text = "DATE ISSUED: " + DateTime.Now.ToShortDateString(); ;
            generatePOID();
            label1.Text = "P.O NUMBER : PO-" +initd.POID.ToString() ;
            autoselect();    
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
            splr1.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                splr1.Add(sread1["SUPPLIERNAME"].ToString(),Convert.ToInt32(sread1["SUPPLIERID"]));
                splr.Items.Add(sread1["SUPPLIERNAME"].ToString());
                SUPPLIERNAME.Items.Add(sread1["SUPPLIERNAME"].ToString());  
            }
            sread1.Close();
            if (splr1.Count != 0)
            {
               splr.SelectedIndex = 0;
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE SUPPLIERID = " + splr1[splr.Text] + ";";
                sread1 = scom1.ExecuteReader();
                while (sread1.Read())
                {
                    //insert into items box
                    ///ItemsBoxOfferd.Controls.Add();
                    Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), sread1["UOMID"].ToString(), Convert.ToInt32(sread1["PRODUCTID"]),ItemsBoxPoList);
                    ItemsBoxOfferd.Controls.Add(prod1);
                }
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
            swtichtriger = 1;//once na maging 1 ito pwede nang tawagin ung function na splr_SelectedIndexChanged to filter inputs pag naka 0 kasi walang trigger and madoudouble yung  call ng function na splr_SelectedIndexChanged
            GC.Collect();
        }
        private void filterer()
        {
            //delete all items
            foreach (UserControl items in ItemsBoxOfferd.Controls){items.Dispose();}
            ItemsBoxOfferd.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE SUPPLIERID = " + splr1[splr.Text] + ";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), sread1["UOMID"].ToString(), Convert.ToInt32(sread1["PRODUCTID"]), ItemsBoxPoList);
                ItemsBoxOfferd.Controls.Add(prod1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
        }
        public void totalall()
        {
            initd.number.Clear();
            GC.Collect();
            foreach (UserControl i in ItemsBoxPoList.Controls)
            {
                initd.number.Add(Convert.ToDouble(i.Controls.Find("TotalValue", true)[0].Text));
            }
            subtotalvallbl.Text = initd.number.Sum().ToString() + ".00";
            //verifier for non character input
            totalamount.Text = (initd.number.Sum() + (Convert.ToDouble(Tax.Text) + Convert.ToDouble(Shipping.Text) + Convert.ToDouble(others.Text))).ToString() + ".00";
        }
        private void generatePOID()
        {
            String id = "";
            Random ran1 = new Random();
            for (int i = 0; i != 5; i++)
            {
                id = id + ran1.Next(1, 10);
            }
            ran1 = null;
            initd.POID = Convert.ToInt32(id);
            id = "";
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
        private void insertinto()
        {
            this.Cursor = Cursors.WaitCursor;
            //"TABLE PURCHASEORDER(POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS),
            //"TABLE POITEMORDERTABLE(ORDERTABLEID,USERID,POID,ITEMID)
            //insert to PO talbe first then into POITEMORDERTABLE with the same ID's 
            //CREATE TABLE PO INFORMATION NG DELIVERY
            //execute each string 
            //detect kung wala munang laman ung itemsbox
            if (ItemsBoxPoList.Controls.Count != 0)
            {
                SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO PURCHASEORDER (POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS) VALUES (" + initd.POID + "," + initd.UserID + ",'" + DateTime.Now.ToShortDateString() + "','" + dateTimePicker1.Text + "','" + splr.Text + "','" + DateTime.Now.ToShortTimeString() + "','" + ItemsBoxPoList.Controls.Count + "'," + Convert.ToDouble(totalamount.Text) + ",'PENDING');", initd.scon);
                scom1.ExecuteNonQuery();
                foreach (KeyValuePair<int, String> i in initd.QueryID)
                {
                    scom1.CommandText = i.Value;//foreign key constraint fe
                    scom1.ExecuteNonQuery();
                    Thread.Sleep(100);
                }
                //Vendor info
                if (Existing.Checked == true)
                {
                    //if no selected please insert data first
                   scom1.CommandText = "INSERT INTO POVENDORINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS) VALUES (" + generateOrder() + "," + initd.POID + ",'"+SUPPLIERNAME.Text+ "','" + ContactPer.Text + "','" + ContactNo.Text + "','" + ADdresss.Text + "');";
                   scom1.ExecuteNonQuery();
                }
                else
                {
                    scom1.CommandText = "INSERT INTO POVENDORINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS) VALUES (" + generateOrder() + "," + initd.POID + ",'" + CCompname.Text + "','" +CcontactP.Text + "','" + Ccontactno.Text + "','" +Caddress.Text + "');";
                    scom1.ExecuteNonQuery();
                }
                //SHIP TO ADDRESS
                if (DefaultAddress.Checked == true)
                {
                    //if no selected please insert data first
                    scom1.CommandText = "INSERT INTO POSHIPTOINFO(ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS,REMARKS) VALUES (" + generateOrder() + "," + initd.POID + ",'JUFAV CONSTRUCTION AND SUPPLY','Lanie Vinluan','+63 956-679-7330 , +63 942-010-8528','ZONE 6,SITIO MALIGAYA, MALIWALO, TARLAC CITY','"+ Remarks.Text+ "');";
                    scom1.ExecuteNonQuery();
                }
                else
                {
                    scom1.CommandText = "INSERT INTO POSHIPTOINFO(ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS,REMARKS) VALUES (" + generateOrder() + "," + initd.POID + ",'"+CompanynameShipto.Text+"','"+ContactPersonShipTo.Text+"','"+ContactNoShipto.Text+"','"+AddressShipto.Text+"','"+Remarks.Text+"');";
                    scom1.ExecuteNonQuery();
                }
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
            Panel[] panels = {SHIPTO,TOTAL_VALUE,CUSTOM_SUPPLIER,REMARKS_PANEL};
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
                if (breaker == 1){
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in panel : '" + b.Name + "' where text in this field : "+ containertometion.Name + " : '" + containertometion.Text + "' contains the non letter character.", "RETRY", 1);
                    ms.Show();
                    break;
                }else if (breaker == 2)
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NO DATA INPUTTED", "Please please provide informaion in panel : '" + b.Name + "' where text in this : " + containertometion.Name + " : '" + containertometion.Text + "' contains no value.", "RETRY", 1);
                    ms.Show();
                    break;
                }

            }
            if (test1 == true && test2 == true)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(insertinto, 0, "CREATE P.O", "ARE YOU SURE YOU INPUTTED THE RIGHT DATA?", "OK", 2);
                ms.Show();
              
            }
        }
        private void splr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //once na maging 1 ito pwede nang tawagin ung function na splr_SelectedIndexChanged to filter inputs pag naka 0 kasior walang trigger na if else,madoudouble yung  call ng function na splr_SelectedIndexChanged
            if (swtichtriger == 1)
            {
                filterer();
            }
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
        private void Existing_CheckedChanged(object sender, EventArgs e)
        {
            if (Existing.Checked == true)
            {
                CustomSupplier.Checked = false;
                foreach (Control i in CUSTOM_SUPPLIER.Controls)
                {
                    i.Enabled = false;
                }
                label30.Enabled = true;
                CustomSupplier.Enabled = true;
            }
            else
            {
                CustomSupplier.Checked = true;
                foreach (Control i in CUSTOM_SUPPLIER.Controls)
                {
                    i.Enabled = true;
                }
            }
        }
        private void CustomSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSupplier.Checked == true)
            {
                Existing.Checked = false;
                foreach (Control i in VENDOR_INFORMATION.Controls)
                {
                    i.Enabled = false;
                }
                Vendor.Enabled = true;
                Existing.Enabled = true;
                //clears the text
            }
            else
            {
                //inserts text like space to prevent the verifyer
                CCompname.Text = " ";
                Ccontactno.Text = " ";
                CcontactP.Text = " ";
                Caddress.Text = " ";
                Existing.Checked = true;
                foreach (Control i in VENDOR_INFORMATION.Controls)
                {
                    i.Enabled = true;
                }
            }
        }
        private void SUPPLIERNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kapag ung combobox na SUPPLIERNAME sa VendorInfo ay napalitan kukunin nya ung information  ng supplier na yun  tas ididisplay nya ung information tungkol dun sa supplier
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERID = " +Convert.ToInt32(splr1[SUPPLIERNAME.Text])+ ";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
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
            if (Regex.IsMatch(toscan.Text,@"^\d+$") == true)
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
        private void Shipping_TextChanged(object sender, EventArgs e)
        {
            verifier(Shipping);
        }
        private void others_TextChanged(object sender, EventArgs e)
        {
            verifier(others);
        }
        private void Tax_TextChanged(object sender, EventArgs e)
        {
            verifier(Tax);
        }
    }
}
