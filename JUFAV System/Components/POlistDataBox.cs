using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Windows.Forms;
using System.Text.RegularExpressions;
using JUFAV_System.dll;

namespace JUFAV_System.Components
{
    public partial class POlistDataBox : UserControl
    {
        int ProdID1;
        int itemcount = 1;//pag inserting convert to double
        public double Origprice1;
        int subtotID1;
       
        public POlistDataBox(String Prodname,String UOM,double Origprice,int ProdID,int subtotID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label19.Text = Prodname;
            label15.Text = UOM;
            label14.Text = Origprice.ToString();
            Origprice1 = Origprice;
            ProdID1 = ProdID;
            quantitytxtbox.Text = itemcount.ToString();
            subtotID1 = subtotID;
            
        }


        private void detectnonDigit()
        {
            //verify id its a digit
            //check if it doesnt have value
            // Console.WriteLine(Regex.IsMatch(quantitytxtbox.Text, @"\D").ToString());

            if (Regex.IsMatch(quantitytxtbox.Text, @"\D") == false)
            {
                if (quantitytxtbox.Text == "")
                {
                    quantitytxtbox.Text = 0.ToString();
                }
                else
                {
                    itemcount = Convert.ToInt32(quantitytxtbox.Text);
                }
            }
            else
            {
                //show messagebx
                quantitytxtbox.Text = Regex.Replace(quantitytxtbox.Text, @"\D", "");
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "QUANTITY", "NON  NUMBER INPUT AT QUANTITY FIELD OF " + label19.Text + " PLEASE CHANGE THE TEXT INTO A DIGIT VALUE.", "OK", 0);
                msg2.Show();

            }
            TotalValue.Text = (itemcount * Origprice1).ToString();
            //problem here setting the subtotal of the  label



        }

        private void TrashBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void DecrementBTN_Click(object sender, EventArgs e)
        {

            //not consistent
            itemcount--;
            quantitytxtbox.Text = itemcount.ToString();
        }
        private void IncrmentBTN_Click(object sender, EventArgs e)
        {
            itemcount++;
            quantitytxtbox.Text = itemcount.ToString();
        }
        private void quantitytxtbox_TextChanged(object sender, EventArgs e)
        {
            detectnonDigit();
            //updates the data in the subtotal dictionarry 
            initd.Subtotal[subtotID1] = Convert.ToInt32(TotalValue.Text);
            //each time controll added a event may trigger that way we can summ all the inserted items in the itemsboxlist PO
        }
    }
}
