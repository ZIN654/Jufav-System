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
    public partial class OfferedProdsPODataBox : UserControl
    {
        int Prodid;
     
        Panel List;
       
        public OfferedProdsPODataBox(String prodname,double ProdCost,String UOM,int ProdID,Panel ItemsboxList)
        {
            //no need na daw sa pricing sabi ni ser alivn

            InitializeComponent();
            this.Dock = DockStyle.Top;
            List = ItemsboxList;
            Prodid = ProdID;
            label2.Text = ProdCost.ToString() + ".00";
            label1.Text = prodname;
            label3.Text = UOM;

           

           



        }
        private void POListAdd()
        {
           
            Components.POlistDataBox items1 = new Components.POlistDataBox(label1.Text,label3.Text,Convert.ToDouble(label2.Text),Prodid, initd.Subtotalid);
            List.Controls.Add(items1);
            initd.Subtotalid++;//increments for the next summon


        }
        private void AddtoPOList_Click(object sender, EventArgs e)
        {
           
                bool test1 = true;
                //inserts into INITD.QUerysales
                foreach (UserControl i in initd.itemsboxselectedPO.Controls)
                {
                    if (i.Controls.Find("ProducName1", true)[0].Text == label1.Text)
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
                     POListAdd();

                 }

            
           
        }
    }
}
