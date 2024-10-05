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
            SQLiteCommand sq1 = new SQLiteCommand("SELECT * FROM VAT;", initd.scon);
            SQLiteDataReader sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                Vattxtbox.Text = sread1["VATVALUE"].ToString();
            }
            sq1 = null;
            sread1 = null;
        }

        private void setvat()
        {
            SQLiteCommand sq1 = new SQLiteCommand("UPDATE VAT SET VATVALUE =" + Convert.ToInt32(Vattxtbox.Text)+ " WHERE VATID = 01100001;", initd.scon);
            sq1.ExecuteNonQuery();
          

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
