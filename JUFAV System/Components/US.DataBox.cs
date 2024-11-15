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
        public String username1;
        public DataBox(Panel itemsbox,String name,String Username,String role)
        {
            
            InitializeComponent();
            this.itembox = itemsbox;
            this.Dock = DockStyle.Top;
           
            lblname.Text = name;
            lblusername.Text = Username;
            lblrole.Text = role;
            this.username1 = Username;
            Console.WriteLine(Username + username1);
        }
          
        private void successfully()
        {
           
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(successfully, 1, "ACCOUNT DELETION", "ACCOUNT SUCCESSFULLY DELETED", "OK", 2);
            msg1.Show();
            this.Dispose();
        }
        private void delete()
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
        private void determine2()
        {
            if (lblusername.Text == initd.username)
            {
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(null, 1, "ACCOUNT ARCHIVE", "UNABLE TO ARCHIVE THIS ACCOUNT", "DELETE", 2);
                msg1.Show();
            }
            else
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ACCOUNT ARCHIVE", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE TO PROCEED?.\n NOTE: ALL OF RECORDS OF THIS ACCOUNT WILL BE ARCHIVED AS WELL.", "OK", 2);
                ms.Show();
            }


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
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(delete, 0, "ACCOUNT DELETION", "ARE YOU SURE YOU WANT TO DELETE THIS ACCOUNT? \n NOTE: ALL OF RECORDS OF THIS ACCOUNT WILL BE ARCHIVED AS WELL.", "DELETE", 1);
                msg1.Show();
            }
            
            
        }
        private void goedit()
        {
            //updating tayo ngayon
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
           
            ModulesSecond.UsersettingsAddUser unit1 = new ModulesSecond.UsersettingsAddUser(0,this.username1);
            initd.UsernameToedit = this.username1;
            Console.WriteLine("USER TO EDIT IN DATABOX US" + username1);
            unit1.Name = "EDITUSERACCOUNT";
            ResponsiveUI1.title = unit1.Name;
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        private void archive()
        {
            //all tables that has the userid will be archived


        }
        private void editbut_Click(object sender, EventArgs e)
        {
            goedit();
        }
        private void Recover_Click(object sender, EventArgs e)
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
            Messageboxes.MessageboxConfirmation showpass = new Messageboxes.MessageboxConfirmation(null, 1, "PASSSWORD RECOVERY", "YOUR USERNAME : '" + username + "'\n" + "YOUR PASSWORD : '" + password + "'", "OK", 0);
            showpass.Show();
            //recovers password only appears when 

        }
        private void deleteBTNClick(object sender, EventArgs e)
        {
            determine();

        }
        private void DataBox_Leave(object sender, EventArgs e)
        {
            editbut.Click += null;
            deletebtn.Click += null;
            rcvBTN.Click += null;
        }
        private void ARCBTN_Click(object sender, EventArgs e)
        {
            determine2();
        }
    }
}
