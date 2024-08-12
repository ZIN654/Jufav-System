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
namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class Sales : UserControl
    {
        private int switch1 = 1;
        private int sizewidth = 234;
        public Sales()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
        }
        public void Addevents()
        {
            //use static variables for allocation
           
            //when this clicked the user setting will appear this is just an divider
            SalesBTN.Click += (sender, e) =>
            {
                sales1();


            };
        }
        //=============================================METHODS CLICK============================
        public void sales1()
        {
            ResponsiveUI1.asigntext("SALES");
            if (switch1 == 1)
            {
                //226
                this.Size = new Size(sizewidth, 114);
                switch1 = 0;
            }
            else
            {
                //36
                this.Size = new Size(sizewidth, 38);
                switch1 = 1;
            }

        }

        public void SalesMain()
        {

        }
        public void ReservedProd()
        {

        }



    }
    }


