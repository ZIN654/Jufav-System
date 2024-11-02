using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.Properties;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading;

namespace JUFAV_System.ModulesMain.LOGIN
{
    public partial class LoginPanel : UserControl
    {
        private static Hashtable account = new Hashtable();
        private static int switch1 = 1;
       
        public LoginPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
          
            addevents();
           // Fetchdata();
        }
        public void addevents()
        {
            lgnBTN.Click += loginBTN;
            eyeBTN.Click += hideshowpassBTN;

            forgotBTN.Click += forgotpass;
            txtboxPASS.Click += clickpass;
            txtBxUSER.Click += clickuser;
            txtboxPASS.MouseLeave += passleave;
            txtBxUSER.MouseLeave += userleave;
        }
        private void loginBTN(object sender, EventArgs e)
        {
            //revise
            this.Cursor = Cursors.WaitCursor;
            Fetchdata();
            Thread.Sleep(500);
            verlogin();
            this.Cursor = Cursors.Default;
        }
        private void hideshowpassBTN(object sender, EventArgs e)
        {
            if (switch1 == 1)
            {
                eyeBTN.Image = Resources.Eye;
                txtboxPASS.PasswordChar = '\0';
                switch1 = 0;
            }
            else
            {
                eyeBTN.Image = Resources.Hide;
                txtboxPASS.PasswordChar = '*';
                switch1 = 1;

            }

        }
        private void forgotpass(object sender, EventArgs e) { }
        private void clickpass(object sender, EventArgs e)
        {
            txtboxPASS.ForeColor = Color.Black;
            if (txtboxPASS.Text == "PASSWORD")
            {
                txtboxPASS.Text = "";

            }
        }
        private void clickuser(object sender, EventArgs e)
        {
            txtBxUSER.ForeColor = Color.Black;
            if (txtBxUSER.Text == "USERNAME")
            {
                txtBxUSER.Text = "";

            }
        }
        private void passleave(object sender, EventArgs e)
        {
            if (txtboxPASS.Text == "")
            {

                txtboxPASS.Text = "PASSWORD";
                txtboxPASS.ForeColor = Color.Gray;
            }
        }
        private void userleave(object sender, EventArgs e)
        {
            if (txtBxUSER.Text == "")
            {
                txtBxUSER.Text = "USERNAME";
                txtBxUSER.ForeColor = Color.Gray;
            }
        }
        //===========================DATABASE FETCHING  DATA AND VEIFY LOGIN
        public void Fetchdata()
        {
            account.Clear();
            SQLiteCommand scom = new SQLiteCommand("SELECT USERNAME,PASSWORDS FROM USER_INFO;", initd.scon);
            SQLiteDataReader sread = scom.ExecuteReader();
            while (sread.Read())
            {
                //hindi pwede ang same username thats why we shoudl create a counter measure 
                account.Add(sread["USERNAME"].ToString(), sread["PASSWORDS"].ToString());
                //kapag gumagawa ng account make sure na yung ininsert na user  name ay walang ka same value
                Console.WriteLine(sread["USERNAME"]);
                Console.WriteLine(sread["PASSWORDS"]);
                //reader can not execute other commands when actives
            }
            sread.Close();
            scom = null;
            sread = null;

        }
        public void verlogin()
        {
            //check kung admin tas kunin yungmga access level sa modules sa modulesmain na yun each button click check kung available aky user 
            //2 options store globaly ung data ng access level or each click retreive ? may audit trail pa tandaaan mo 
            //LARGE SPIKE HERE 
            if (account.ContainsKey(txtBxUSER.Text.ToString()) == true)
            {
                //paano to please explain
                if (account[txtBxUSER.Text.ToString()].Equals(txtboxPASS.Text.ToString()))
                {
                    //change into the main form
                    initd.UserID = initd.getID(txtBxUSER.Text, initd.scon);
                    initd.username = txtBxUSER.Text;
                    txtboxPASS.PasswordChar = '\0';
                    txtboxPASS.Clear();
                    this.Hide();
                    ModulesMain.CORE core1 = new CORE(this,(Panel)this.Parent);//last stop here
                    core1.Show();
                    core1.BringToFront();


                }
                else
                {

                    MessageBox.Show("PLEASE TRY AGAIN", "INVALID PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("PLEASE TRY AGAIN THE INSERTED USERNAME IS NOT EXISTING ", "USERNAME NOT EXISTING", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //=====================MEMORY MANAGEMENT========================
        public void ClearLeaks()
        {
            lgnBTN.Click -= loginBTN;
            eyeBTN.Click -= hideshowpassBTN;

            forgotBTN.Click -= forgotpass;
            txtboxPASS.Click -= clickpass;
            txtBxUSER.Click -= clickuser;
            txtboxPASS.MouseLeave -= passleave;
            txtBxUSER.MouseLeave -= userleave;
            //dispose memory allocation to avoid memory leaks and reduce memory consumption: garbage collector na  bahala
        }
        private void detectNet()
        {

            String hostnam = Dns.GetHostName().ToString();
            String ip = Dns.GetHostByName(hostnam).AddressList[0].ToString();
            if ("127.0.0.1" == ip)
            {
                MessageBox.Show(this, "PLEASE CONNECT TO INTERNET AND TRY AGAIN", "INTERNET CONNECTION", MessageBoxButtons.OK);
            }
            else
            {
                //sendemail();
                if (MessageBox.Show(this, "NETWORK IS AVAILABLE, YOU CAN NOW RECOVER EMAIL", "INTERNET CONNECTION", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    //transfer to other panel then fill up some nessescary info
                    changepanel();

                }
            }
            hostnam = null;
            ip = null;
        }
        private void changepanel()
        {
            //changes the panel
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();//error here outside the array
            ModulesMain.LOGIN.Fogotpass forgotpas = new ModulesMain.LOGIN.Fogotpass(txtBxUSER.Text);
            ResponsiveUI1.title = "Fogotpass";
            ResponsiveUI1.spl1.Controls.Add(forgotpas);

        }
        private void JUFAV_LOGIN_VisibleChanged(object sender, EventArgs e)
        {
          // Fetchdata();
        }
        private void forgotBTN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            detectNet();
        }
    }
}
