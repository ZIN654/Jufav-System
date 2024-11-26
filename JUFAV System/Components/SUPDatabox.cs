using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JUFAV_System.dll;
using System.Windows.Forms;
using System.Data.SQLite;

namespace JUFAV_System.Components
{
    public partial class SUPDatabox : UserControl
    {
        public int id;
        public SUPDatabox(String Suppliername, String COntacPerson, String ContactNum, String Address, int ID)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            lblname.Text = Suppliername;
            lblAddress.Text = Address;
            lblContactbumber.Text = ContactNum;
            ContactPersonlbl.Text = COntacPerson;
            id = ID;

        }
        private void CallEdit(int summontype)
        {
            //revise paano kung same yung name
            //how do we fetch the data if it has a same name ?
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Supplier.Addsupplier sup1 = new ModulesSecond.FileMaintenance.Supplier.Addsupplier(summontype, id);
            sup1.Name = "editsupplier";
            ResponsiveUI1.title = "editsupplier";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void ArchiveRecords()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                String[] Querys = { "INSERT INTO ARCSUPPLIERS (SUPPLIERID,USERID,SUPPLIERNAME,CONTACTPERSON,CONTACTNUMBER,COMPANYADDRESS) SELECT * FROM SUPPLIERS;", "DELETE FROM SUPPLIERS WHERE SUPPLIERID = " + id + ";" };
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);
                foreach (String i in Querys)
                {
                    scom1.CommandText = i;
                    scom1.ExecuteNonQuery();
                }
                scom1 = null;
                //debug delete /archive
                //test "INSERT INTO ARCHIVESUPPLIERS SELECT * FROM SUPPLIERS WHERE USERSID = "+userid+";"

                //what if other user uses same the dleted RECORD ?
                //data must not be deleted must be moved in the archive table
                this.Cursor = Cursors.Default;
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(null, 1, "SUPPLIER ARCHIVE", "SUPPLIER SUCCESSFULLY ARCHIVED", "OK", 2);
                msg1.Show();
                this.Dispose();
            }
            catch (Exception e)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "ARCHIVE RECORD", "UNABLE TO ARCHIVE RECORD BECAUSE IT WAS STILL USED BY OTHER MODULES", "OK", 1);
                ms.Show();
            }
        }
        private void successfully()
        {
            //archive setup
            //deletion setup
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(null, 1, "SUPPLIER DELETION", "SUPPLIER SUCCESSFULLY ARCHIVED", "OK", 2);
            msg1.Show();
            this.Dispose();
        }
        private void delete()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM SUPPLIERS WHERE SUPPLIERID = " + id + ";", initd.con1);
                sq1.ExecuteNonQuery();
                sq1 = null;
                //  successfully();
                this.Cursor = Cursors.Default;
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(null, 1, "SUPPLIER DELETION", "SUPPLIER SUCCESSFULLY DELETED", "OK", 2);
                msg1.Show();
                this.Dispose();
            }
            catch (Exception e)
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "DELETE RECORD", "UNABLE TO DELETE RECORD BECAUSE IT WAS STILL USED BY OTHER MODULES", "OK", 1);
                ms.Show();

            }


        }
        private void editbut_Click(object sender, EventArgs e)
        {
            CallEdit(0);//goes to edit mode
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(delete, 0, "SUPPLIER DELETION", "ARE YOU SURE YOU WANT TO DELETE THIS SUPPLIER?", "YES", 1);
            msg1.Show();
        }
        private void SUPDatabox_Leave(object sender, EventArgs e)
        {
            editbut.Click += null;
            deletebtn.Click += null;
        }
        private void Archive_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(ArchiveRecords, 0, "SUPPLIER ARCHIVE", "ARE YOU SURE YOU WANT TO ARCHIVE THIS SUPPLIER?", "YES", 1);
            msg1.Show();
        }
    }
}
