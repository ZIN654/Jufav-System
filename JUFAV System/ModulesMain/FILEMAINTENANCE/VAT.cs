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
using System.Text.RegularExpressions;
namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class VAT : UserControl
    {
        public VAT()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            onload1();
        }
        private void onload1()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM VAT;", initd.con1);
            Vattxtbox.Text = sq1.ExecuteScalar().ToString();
            sq1 = null;
           
            initd.con1.Close();
        }

        private void setvat()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE VAT SET VATVALUE =" + Convert.ToDouble(Vattxtbox.Text)+ " WHERE VATID = 01100001;", initd.con1);
            sq1.ExecuteNonQuery();

            sq1 = null;
            GC.Collect();
            initd.con1.Close();

        }
        private void onclose()
        {



        }
        private void verifyinput()
        {
            if (Regex.IsMatch(Vattxtbox.Text,@"[^0-9]") == true)
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "SET VAT", "THE INPUTED VALUE CONTAINS A NON VALUE CHARACTER PLEASE REMOVE IT AND TRY AGAIN", "OK", 2);
                msg2.Show();
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                setvat();
                this.Cursor = Cursors.Default;
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "SET VAT", "THE INPUTED VALUE WAS UPDATED SUCCESSFULLY!", "OK", 0);
                msg2.Show();
                
                

            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            verifyinput();
        }
    }
}
