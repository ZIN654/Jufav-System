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
using System.Text.RegularExpressions;
using System.Threading;

namespace JUFAV_System.Components
{
    public partial class SalesOrdersList : UserControl
    {
        int ItemID;
        int queryID1 = 0;//magnangaling sa parent
        int quantity = 1;
        int price1 = 0;
        int currentstock;
        public SalesOrdersList(String Prodname1,int Price2,int ProductID,int QueryID,int currentquantity)
        {
            InitializeComponent();
            currentstock = currentquantity;
            queryID1 = QueryID;
            Dock = DockStyle.Top;
            ItemID = ProductID;
            price1 = Price2;
            Prodname.Text = Prodname1;
            Price.Text = Price2.ToString() + ".00";
            total.Text = (quantity * price1).ToString() +".00";
            //first insertion
            initd.QueryIDsSALES.Add(queryID1, "INSERT INTO ORDERSTEMPO (ProductID,ProductDesc,USERID,QUANTITY,PRICE,TOTALPRICE) VALUES ("+ItemID+",'"+Prodname.Text+"'," + initd.UserID + "," + quantity + "," + price1 + "," + (price1 * quantity) + ");");
        }
        private bool detectnonDigit()
        {
            bool test1 = true;
            //verify id its a digit
            //check if it doesnt have value
            // Console.WriteLine(Regex.IsMatch(quantitytxtbox.Text, @"\D").ToString());

            if (Regex.IsMatch(quantitytxtbox.Text, @"\D") == false)
            {
                if (quantitytxtbox.Text == "")
                {
                    quantitytxtbox.Text = 1.ToString();
                }
                else if (quantitytxtbox.Text == "0")
                {
                    quantitytxtbox.Text = 1.ToString();
                }
                else
                {
                    quantity = Convert.ToInt32(quantitytxtbox.Text);
                }
                test1 = true;
            }
            else
            {
                //show messagebx
                quantitytxtbox.Text = Regex.Replace(quantitytxtbox.Text, @"\D", "");
                test1 = false;
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "QUANTITY", "NON  NUMBER INPUT AT QUANTITY FIELD OF " + Prodname.Text + " PLEASE CHANGE THE TEXT INTO A DIGIT VALUE.", "OK", 0);
                msg2.Show();

            }
            // TotalValue.Text = (itemcount * Origprice1).ToString();
            //problem here setting the subtotal of the  label
            total.Text = (quantity * price1).ToString() + ".00";
            return test1;
        }
        private int generateID()//for hashtable/dictionary
        {
            String id = "";
            Random ran1 = new Random();
            for (int i = 0; i != 9; i++)
            {
                id = id + ran1.Next(1, 10);
            }
            ran1 = null;
            return Convert.ToInt32(id);
            id = "";

        }
        private void insertintoquery()
        {
            initd.QueryIDsSALES.Remove(queryID1);
            //Console.WriteLine("sample query");
            Thread.Sleep(250);
            initd.QueryIDsSALES.Add(queryID1, "INSERT INTO ORDERSTEMPO (ProductID,ProductDesc,USERID,QUANTITY,PRICE,TOTALPRICE) VALUES ("+ItemID+",'"+Prodname.Text+"'," + initd.UserID+","+quantity+","+price1+","+(price1 * quantity)+");");
        }
        private void TrashBTN_Click(object sender, EventArgs e)
        {
            initd.QueryIDsSALES.Remove(queryID1);
            this.Dispose();
        }
        private void IncrmentBTN_Click(object sender, EventArgs e)
        {
            quantity++;
            quantitytxtbox.Text = quantity.ToString();
        }
        private void DecrementBTN_Click(object sender, EventArgs e)
        {
            quantity--;
            quantitytxtbox.Text = quantity.ToString();
        }
        private void quantitytxtbox_TextChanged(object sender, EventArgs e)
        {
            if (detectnonDigit() == true )
            {
                if (Convert.ToInt32(quantitytxtbox.Text) > currentstock)
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "QUANTITY", "INSERTED VALUE CANNOT BE HIGHER THAN THE CURRENT QUANTITY  OF THE PRODUCT", "OK", 2);
                    msg2.Show();
                    quantitytxtbox.Text = currentstock.ToString();
                }
                else
                {
                    insertintoquery();
                    initd.salestoexe.totalallSales();
                }         
            }

        }

        private void quantitytxtbox_Click(object sender, EventArgs e)
        {
            quantitytxtbox.SelectAll();
        }
    }
}
