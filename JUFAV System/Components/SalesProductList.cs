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


namespace JUFAV_System.Components
{
    public partial class SalesProductList : UserControl
    {
        int prodid1;
        int quantity1;
        public SalesProductList(String Productname,int quantity,String  UnitOfMeasure,String Price,int ProdID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            prodid1 = ProdID;
            quantity1 = quantity;
            label1.Text = Productname;
            label2.Text = quantity.ToString();
            label3.Text = UnitOfMeasure;
            label4.Text = Price.ToString();
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
        private void btnadd_Click(object sender, EventArgs e)
        {
            //must be like the batch products
            if (quantity1 == 0)
            {

                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "ADD ITEM", "UNABLE TO ADD THE SELECTED ITEM DUE TO OUT OF STOCK", "CLEAR", 2);
                msg2.Show();
            }
            else
            {
                bool test1 = true;
                //inserts into INITD.QUerysales
                foreach (UserControl i in initd.itemsboxselected.Controls){
                    if (i.Controls.Find("Prodname",true)[0].Text == label1.Text)
                    {
                        test1 = false;
                    }
                }
                if (test1 == false)
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "ADD ITEM", "UNABLE TO ADD THE SAME SELECTED ITEM", "CLEAR", 2);
                    msg2.Show();

                }
                else
                {
                    Components.SalesOrdersList item1 = new SalesOrdersList(label1.Text, Convert.ToInt32(label4.Text), prodid1, generateID());
                    initd.itemsboxselected.Controls.Add(item1);

                }
               
            }
           
        }
    }
}
