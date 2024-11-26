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

namespace JUFAV_System.Components
{
    public partial class MarkUpDatabox : UserControl
    {
        int id;
        public MarkUpDatabox(String value, int IDtoedit)
        {

            InitializeComponent();
            id = IDtoedit;
            label1.Text = value;
            this.Dock = DockStyle.Top;
        }

        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.markup.AddMarkup sup1 = new ModulesSecond.FileMaintenance.markup.AddMarkup(0, id);
            sup1.Name = "editMarkup";
            ResponsiveUI1.title = "editMarkup";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);


        }
        private void delete()
        {
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM MARKUP WHERE MARKUPID = " + id + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK", 0);
            ms.Show();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void trash_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(delete, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?", "OK", 1);
            ms.Show();
        }
        private void MarkUpDatabox_Leave(object sender, EventArgs e)
        {
            editBTN.Click += null;
            trash.Click += null;
        }
    }
}
