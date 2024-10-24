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
using System.Data.SQLite;

namespace JUFAV_System.Components
{
    public partial class POlistDataBox : UserControl
    {
        //from here insert mo na agad sa table ung mga pipiliiin ng user  ID lang or buong product?
        int ProdID1;
        int IdQuery;//used in when editing 
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
            insertdata();
            
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
        private int generateID(int type)//for hashtable/dictionary
        {
            String id = "";
            Random ran1 = new Random();
            if (type == 1)
            {
                for (int i = 0; i != 5; i++)
                {
                    id = id + ran1.Next(1, 10);
                }
            }
            else
            {
                for (int i = 0; i != 7; i++)
                {
                    id = id + ran1.Next(1, 10);
                }
            }
          
            ran1 = null;
            return Convert.ToInt32(id);
            id = "";
        }
        private void insertdata()
        {
            //pwde pala yon
            initd.QueryID.Add(IdQuery = generateID(1), "INSERT INTO POITEMORDERTABLE (ORDERTABLEID,USERID,POID,ITEMID) VALUES("+generateID(0)+","+initd.UserID+","+initd.POID+","+ProdID1+")");
            //displaying data
           foreach (KeyValuePair<int,String> i in initd.QueryID)
            {
                Console.WriteLine(i.Value);
           }
            //insert query into init d then  pag  pinindot 
            //pag  dinispose gamitin ung id as IDEntifier para tangalin ung value nya sa initd Hastable

            //hash  table or dictionary 
           //external code 


        }
        private void TrashBTN_Click(object sender, EventArgs e)
        {
            initd.QueryID.Remove(IdQuery);
            this.Dispose();
            initd.toexe.totalall();
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
            initd.toexe.totalall(); 
            GC.Collect();
        }

       
    }
}
