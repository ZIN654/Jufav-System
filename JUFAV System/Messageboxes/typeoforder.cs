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
        public typeoforder()
        {
            InitializeComponent();
        }

        private void CONFRIMBTN_Click(object sender, EventArgs e)
        {
            determinewhich();
            this.Dispose();
        }
        private void determinewhich()
        {
            int summontype = 0;
            RadioButton[] todetermine = {radioButton1,radioButton2,radioButton3,radioButton4 };
            foreach (RadioButton i in todetermine){
                if (i.Checked == true){determine(summontype);break;}
                summontype++;
            }
        }
        private void determine(int summon)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Sales.SalesPaymentMethod cat1 = new ModulesSecond.Sales.SalesPaymentMethod();
            switch (summon)
            {
                case 0:
                    //optimize edit function assignage
                    cat1.Controls.Find("otherpaymentttype",true)[0].Text = "GCASH";
                    cat1.Click += cat1.gcash;
                   
                    break;
                case 1:
                    cat1.Controls.Find("otherpaymentttype", true)[0].Text = "CASH ON DELIVERY";
                    cat1.Click += cat1.COD;
                    break;
                case 2:
                    cat1.Controls.Find("otherpaymentttype", true)[0].Text = "GCASH";
                    cat1.Click += cat1.COP;
                    break;
            }
            ResponsiveUI1.title = "SalesPaymentMethod";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }
    }
}
