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
            label1.Text = prodname;
            label2.Text = ProdCost.ToString();
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
            POListAdd();
        }
    }
}
