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
        private int id;
        public SUPDatabox(String Suppliername,String COntacPerson,String ContactNum,String Address,int ID)
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
            ModulesSecond.FileMaintenance.Supplier.Addsupplier sup1 = new ModulesSecond.FileMaintenance.Supplier.Addsupplier(summontype,id);
            sup1.Name = "editsupplier";
            ResponsiveUI1.title = "editsupplier";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void ArchiveRecords()
        {

            //debug delete /archive
            //test "INSERT INTO ARCHIVESUPPLIERS SELECT * FROM SUPPLIERS WHERE USERSID = "+userid+";"
            SQLiteCommand sq1 = new SQLiteCommand("DELETE FROM SUPPLIERS WHERE SUPPLIERID = "+id+";",initd.scon);
            sq1.ExecuteNonQuery();
            sq1 = null;
            //what if other user uses same the dleted RECORD ?
            //data must not be deleted must be moved in the archive table




        }
        private void editbut_Click(object sender, EventArgs e)
        {
            CallEdit(0);//goes to edit mode
        }
        private void successfully()
        {

            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(successfully, 1, "SUPPLIER DELETION", "SUPPLIER SUCCESSFULLY ARCHIVED", "OK", 2);
            msg1.Show();
            this.Dispose();
        }
        private void delete()
        {
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(ArchiveRecords, 0, "SUPPLIER DELETION", "ARE YOU SURE YOU WANT TO ARCHIVE THIS SUPPLIER?", "DELETE", 1);
            msg1.Show();
            successfully();


        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void SUPDatabox_Leave(object sender, EventArgs e)
        {
            editbut.Click += null;
            deletebtn.Click += null;
        }
    }
}
