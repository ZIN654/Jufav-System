using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;


namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class MarkUp : UserControl
    {
        public MarkUp()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            Loaddata();
        }
        public void releasemem()
        {
            addmkupBTN.Click -= addmkupBTN_Click;


        }
        private void Loaddata()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM MARKUP;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Components.MarkUpDatabox mku1 = new Components.MarkUpDatabox(sq1["MARKUPVALUE"].ToString(), Convert.ToInt32(sq1["MARKUPID"]));
                ItemsBox.Controls.Add(mku1);

            }

        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.markup.AddMarkup unit1 = new ModulesSecond.FileMaintenance.markup.AddMarkup(1,0);
            ResponsiveUI1.title = "AddMarkup";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        private void addmkupBTN_Click(object sender, EventArgs e)
        {
            goback();
        }
    }
}
