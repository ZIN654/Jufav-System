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
using System.Threading;

namespace JUFAV_System.Components
{
    public partial class UOMDataBox : UserControl
    {
        int ID1;
        public UOMDataBox(String KG, String Abbreviation, int ID)
        {
            InitializeComponent();
            ID1 = ID;
            this.Dock = DockStyle.Top;
            Abbreviationlbl.Text = KG;
            Unitofmelbl.Text = Abbreviation;

        }
        private void edit()
        {
            //0for edit  1 for default
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure sup1 = new ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure(0, ID1);
            sup1.Name = "editunitofmeasures";
            ResponsiveUI1.title = "editunitofmeasures";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void archive()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO ARCUNITOFMEASURE (UNITID,USERID,UNITDESC,UNITABBREVIATION) SELECT * FROM UNITOFMEASURE WHERE UNITID = " + ID1 + ";", initd.con1);
                scom1.ExecuteNonQuery();
                Thread.Sleep(2000);
                scom1.CommandText = "DELETE FROM UNITOFMEASURE WHERE UNITID = " + ID1 + ";";//references bug
                scom1.ExecuteNonQuery();
                scom1 = null;
                GC.Collect();
                this.Cursor = Cursors.Default;
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
                ms.Show();
            }
            catch (Exception e)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "ARCHIVE RECORD", "UNABLE TO ARCHIVE RECORD BECAUSE IT WAS STILL USED BY OTHER MODULES", "OK", 1);
                ms.Show();
            }
        }
        private void delete()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM UNITOFMEASURE WHERE UNITID = " + ID1 + ";", initd.con1);
                scom1.ExecuteNonQuery();
                scom1 = null;
                GC.Collect();
                this.Cursor = Cursors.Default;
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK", 0);
                ms.Show();
            }
            catch (Exception e)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "DELETE RECORD", "UNABLE TO DELETE RECORD BECAUSE IT WAS STILL USED BY OTHER MODULES", "OK", 1);
                ms.Show();
            }


        }
        private void editbut_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(delete, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?\n ALL OF ITS RELATIVE DATA WILL BE ALSO DELETED.", "OK", 1);
            ms.Show();
        }
        private void ARCBTn_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD?\n THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.", "OK", 2);
            ms.Show();
        }
        private void UOMDataBox_Leave(object sender, EventArgs e)
        {
            editbut.Click += null;
            deletebtn.Click += null;

        }


    }
}
