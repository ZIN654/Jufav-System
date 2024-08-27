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

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class UnitOfMeasures : UserControl
    {
        public UnitOfMeasures()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevents();
            loaddata();

        }
        public void addevents()
        {
            addUoMBTN.Click += AddnewUoM;

        }
        private void AddnewUoM(object sender,EventArgs e)
        {
            // data box must have parameters  Components.UOMDataBox data = new Components.UOMDataBox(String KG,String Abbreviation);
            //its usable for data box array and insert using loop such as kgvalue[i] "i" loop 
            
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure unit1 = new ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure();
            ResponsiveUI1.title = "AddUnitOfMeasure";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        //when the entry count was changed the items will lod also 
        private void loaddata()
        {
            SQLiteCommand sq1 = new SQLiteCommand("SELECT UNITABBREVIATION,UNITDESC FROM UNITOFMEASURE;", initd.scon) ;
            SQLiteDataReader sqread = sq1.ExecuteReader();
            while (sqread.Read())
            {
                Components.UOMDataBox uomdbx = new Components.UOMDataBox();
                uomdbx.Controls.Find("Abbreviationlbl", true)[0].Text = sqread["UNITABBREVIATION"].ToString();
                uomdbx.Controls.Find("Unitofmelbl", true)[0].Text = sqread["UNITDESC"].ToString();
                ItemsBox.Controls.Add(uomdbx);
            }


        }
    }
}
