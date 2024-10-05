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
            ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure unit1 = new ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure(1,0);
            ResponsiveUI1.title = "AddUnitOfMeasure";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        private void search(String text)
        {
            foreach (UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM UNITOFMEASURE WHERE UNITDESC LIKE '%" + text + "%';", initd.scon);
            SQLiteDataReader sqread = scom1.ExecuteReader();
            while (sqread.Read())
            {
                Components.UOMDataBox uomdbx = new Components.UOMDataBox(sqread["UNITDESC"].ToString(), sqread["UNITABBREVIATION"].ToString(), Convert.ToInt32(sqread["UNITID"]));
                ItemsBox.Controls.Add(uomdbx);
            }
            scom1 = null;
            sqread = null;
        }
        //when the entry count was changed the items will lod also 
        private void loaddata()
        {
            SQLiteCommand sq1 = new SQLiteCommand("SELECT * FROM UNITOFMEASURE;", initd.scon) ;
            SQLiteDataReader sqread = sq1.ExecuteReader();
            while (sqread.Read())
            {
                Components.UOMDataBox uomdbx = new Components.UOMDataBox(sqread["UNITDESC"].ToString(),sqread["UNITABBREVIATION"].ToString(),Convert.ToInt32(sqread["UNITID"]));
      
                ItemsBox.Controls.Add(uomdbx);
            }


        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            search(txtboxSearchBox.Text);
        }

        private void txtboxSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtboxSearchBox.Text = "";
        }
        //om close rdispose oitemsbox
    }
}
