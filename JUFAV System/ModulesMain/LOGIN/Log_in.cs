using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.Properties;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Collections;
using System.IO;


namespace JUFAV_System.ModulesMain.LOGIN
{
    public partial class JUFAV_LOGIN : Form
    {
        private static Hashtable account = new Hashtable();
       
        private static int switch1 = 1;
        public JUFAV_LOGIN()
        {
            InitializeComponent();
            addevents();
            //temporary
            axWindowsMediaPlayer1.uiMode = "None";
            //replace with your own path .dapat makuha yung path ng file kung saan sya mag iinstall 
            axWindowsMediaPlayer1.URL = @"C://Users//asus//Desktop//CAPSTONE 2//JUFAV System//JUFAV System//Resources//JufavLogoback.mp4";
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.setMode("loop",true);
            //
            initd.closedatabase();
            initd.opendatabase();
            //Directory.GetFiles;
         
            Fetchdata();
           
            
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



        private void loginBTN(object sender,EventArgs e) {

            verlogin();
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
       

        private void clickpass(object sender, EventArgs e) {
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
            while(sread.Read())
            {
                account.Add(sread["USERNAME"],sread["PASSWORDS"]);
                Console.WriteLine(sread["USERNAME"]);
                Console.WriteLine(sread["PASSWORDS"]);

                //reader can not execute other commands when actives
            }
           
        }
        public void verlogin()
        {
           //check kung admin tas kunin yungmga access level sa modules sa modulesmain na yun each button click check kung available aky user 
           //2 options store globaly ung data ng access level or each click retreive ? may audit trail pa tandaaan mo 
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
                    ModulesMain.CORE core1 = new CORE(this);
                    core1.Show();
                    core1.BringToFront();

                   
                }
                else
                {

                    MessageBox.Show("PLEASE TRY AGAIN", "INVALID PASSWORD",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("PLEASE TRY AGAIN", "INVALID INPUTS",MessageBoxButtons.OK,MessageBoxIcon.Error);

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

        private void JUFAV_LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            initd.closedatabase();
        }

        private void JUFAV_LOGIN_VisibleChanged(object sender, EventArgs e)
        {
            Fetchdata();
        }
    }
}
