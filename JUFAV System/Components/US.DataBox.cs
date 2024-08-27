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
using System.Collections;
namespace JUFAV_System.Components
{
    public partial class DataBox : UserControl
    {

        private Panel itembox;
        public DataBox(Panel itemsbox)
        {
            
            InitializeComponent();
            this.itembox = itemsbox;
            this.Dock = DockStyle.Top;
            addevents();
        }
        public void addevents()
        {
            deletebtn.Click += deleteBTNClick;

        }
        private void deleteBTNClick(object sender,EventArgs e)
        {
            determine();
            
        }
        
        private void successfully()
        {
           
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(successfully, 1, "ACCOUNT DELETION", "ACCOUNT SUCCESSFULLY ARCHIVED", "OK", 2);
            msg1.Show();
            this.Dispose();
        }
        private void disposethis()
        {
            this.Cursor = Cursors.WaitCursor;
            int id = 0;
            //here items from database must be delete
            //indicate warning if  the name is used
            SQLiteCommand sq1 = new SQLiteCommand("SELECT USERIDS FROM USER_INFO WHERE NAME = '" + lblname.Text + "';", initd.scon);
            SQLiteDataReader read1 = sq1.ExecuteReader();
            while (read1.Read())
            {
                id = Convert.ToInt32(read1["USERIDS"]);
            }
            read1.Close();
            //achive to hindi delete
         
            sq1.CommandText = "DELETE FROM USERS WHERE USERID = " + id + ";";
            sq1.ExecuteNonQuery();

            this.Cursor = Cursors.Default;
            successfully();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String username = "";
            String password = "";
            SQLiteCommand sq1 = new SQLiteCommand("SELECT USERNAME,PASSWORDS FROM USER_INFO WHERE NAME = '" + lblname.Text + "';", initd.scon);
            SQLiteDataReader read1 = sq1.ExecuteReader();
            while (read1.Read())
            {
                username = read1["USERNAME"].ToString();
                password = read1["PASSWORDS"].ToString();
            }
            read1.Close();///hide yung na show na recover button
            Messageboxes.MessageboxConfirmation showpass = new Messageboxes.MessageboxConfirmation(null,1,"PASSSWORD RECOVERY","YOUR USERNAME : " + username+ "\n" + "YOUR PASSWORD :" + password,"OK",0);
            showpass.Show();
            //recovers password only appears when 
            
        }
        private void determine()
        {
            if (lblusername.Text == initd.username)
            {
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(null, 1, "ACCOUNT DELETION", "UNABLE TO DELETE THIS ACCOUNT", "DELETE", 2);
                msg1.Show();
            }
            else
            {
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(disposethis, 0, "ACCOUNT DELETION", "ARE YOU SURE YOU WANT TO ARCHIVE THIS ACCOUNT?", "DELETE", 1);
                msg1.Show();
            }
            
            
        }

       
}
}
