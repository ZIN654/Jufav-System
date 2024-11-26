using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;

namespace JUFAV_System.Messageboxes
{
    public partial class typeoforder : Form
    {
        Action actoexe;
        String addres1 = "";
        String Custname = "";
        public typeoforder( Action actiontoexe,String Customername,String Address)
        {
            InitializeComponent();
            actoexe = actiontoexe;
            Custname = Customername;
            addres1 = Address;
        }

        private void CONFRIMBTN_Click(object sender, EventArgs e)
        {
            actoexe();
            determinewhich();
            this.Dispose();
        }
        private void determinewhich()
        {
            int summontype = 0;
            RadioButton[] todetermine = {radioButton1,radioButton2,radioButton3 };
            foreach (RadioButton i in todetermine){
                if (i.Checked == true){determine(summontype);break;}
                summontype++;
            }
        }
        private void determine(int summon)
        {
            int ordertype = 0;
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            switch (summon)
            {
                case 0:
                    //optimize edit function assignage                 
                    ordertype = 0;
                    break;
                case 1:               
                    ordertype = 1;
                    break;
                case 2:
                    ordertype = 2;
                    break;
            }
            ModulesSecond.Sales.SalesPaymentMethod cat1 = new ModulesSecond.Sales.SalesPaymentMethod(Custname,addres1,ordertype);
            switch (summon)
            {
                case 0:
                    //optimize edit function assignage
                    cat1.Controls.Find("Deliveryfee", true)[0].Enabled = false;
                    cat1.Controls.Find("label23", true)[0].Enabled = false;//SALES RECEIPT
                   
                    break;
                case 1:
                    cat1.Controls.Find("Deliveryfee", true)[0].Enabled = true;
                    cat1.Controls.Find("label23", true)[0].Enabled = true;//DELIVERY 
                  
                    break;
                case 2:
                    cat1.Controls.Find("Deliveryfee", true)[0].Enabled = false;
                    cat1.Controls.Find("label23", true)[0].Enabled = false;//RESERVATION
                  
                    break;
            }
            ResponsiveUI1.title = "SalesPaymentMethod";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }

        private void CAncelBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
