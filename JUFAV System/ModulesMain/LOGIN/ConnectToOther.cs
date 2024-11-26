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
using System.Threading;
using System.Collections;
namespace JUFAV_System.ModulesMain.LOGIN
{

    public partial class ConnectToOther : UserControl
    {
        private static Hashtable account = new Hashtable();
        public ConnectToOther()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResponsiveUI1.spl2.Controls.Find(ResponsiveUI1.title3, true)[0].Dispose();//error here outside the array
            ModulesMain.LOGIN.LoginPanel connect = new ModulesMain.LOGIN.LoginPanel();
            ResponsiveUI1.title3 = "ConnectToOther";
            ResponsiveUI1.spl2.Controls.Add(connect);
        }

        private void txtBxUSER_Click(object sender, EventArgs e)
        {
            IPADRESS.Clear();
        }

        private void txtBxUSER_MouseLeave(object sender, EventArgs e)
        {
            if (IPADRESS.Text == ""){

                IPADRESS.Text = "IP ADDRESS : 192.168.0.1";

            }
         
        }
        private void connectother()
        {

        }


        private void lgnBTN_Click(object sender, EventArgs e)
        {

            if (initd.con1.State == ConnectionState.Closed) {//renewal ng connection
                initd.con1 = new MySql.Data.MySqlClient.MySqlConnection(@"server=" + IPADRESS.Text.Trim() + ";user=root;password=H2xOlrcWqVdfesacs;port=3306;database=jufav2;");//add to sa part pag coconnect si client
                initd.constringtouserefresh = initd.con1.ConnectionString;
                GC.Collect();
                initd.con1.Open();
            }else
            {
                initd.con1.Close();
                initd.con1 = new MySql.Data.MySqlClient.MySqlConnection(@"server=" + IPADRESS.Text.Trim() + ";user=root;password=H2xOlrcWqVdfesacs;port=3306;database=jufav2;");//add to sa part pag coconnect si client
                initd.constringtouserefresh = initd.con1.ConnectionString;
                GC.Collect();
                initd.con1.Open();
            }
            ///EXEPTION SUMMARY
            /*NEED NG INBOUND RULES sa 3306
             * viceversa para maaccess ang DB
             * Create Inbound rules in firewall 3306
             * Create account both side 'root'@'%' tas grant privelages all
             * 
             */
            //tempo
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            Fetchdata();
            Thread.Sleep(500);
            verlogin();
            this.Cursor = Cursors.Default;




            //process step one fetch constring then check connection /verifiy if account existing 

        }

        public void Fetchdata()
        {


            account.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("SELECT USERNAME,PASSWORDS FROM USER_INFO;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread = scom.ExecuteReader();
            while (sread.Read())
            {
                //hindi pwede ang same username thats why we shoudl create a counter measure 
                account.Add(sread["USERNAME"].ToString(), sread["PASSWORDS"].ToString());
                //kapag gumagawa ng account make sure na yung ininsert na user  name ay walang ka same value
                //reader can not execute other commands when actives
            }
            sread.Close();

            scom = null;
            sread = null;
            GC.Collect();

        }
        private int GenID()
        {
            String IDtouse = "";
            var ran = new Random();
            for (int i = 0; i != 8; i++)
            {
                IDtouse = IDtouse + ran.Next(0, 9);
            }
            GC.Collect();
            return Convert.ToInt32(IDtouse);
        }
        public void verlogin()
        {

            //check kung admin tas kunin yungmga access level sa modules sa modulesmain na yun each button click check kung available aky user 
            //2 options store globaly ung data ng access level or each click retreive ? may audit trail pa tandaaan mo 
            //LARGE SPIKE HERE 
            GC.Collect();
            if (account.ContainsKey(txtBxUSER.Text.ToString()) == true)
            {
                //paano to please explain
                if (account[txtBxUSER.Text.ToString()].Equals(txtboxPASS.Text.ToString()))
                {

                    //change into the main form 

                    initd.UserID = initd.getID(txtBxUSER.Text);
                    initd.username = txtBxUSER.Text;
                    txtboxPASS.PasswordChar = '\0';
                    txtboxPASS.Clear();
                    this.Hide();


                    int Touse = GenID();
                    initd.UserIDACtionAudit = Touse;

                    MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO AUDITTRAIL VALUES(" + Touse + "," + initd.UserID + ",'" + txtBxUSER.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','0:00',0);", initd.con1);
                    scom1.ExecuteNonQueryAsync();
                    initd.scon.Close();


                    ModulesMain.CORE core1 = new CORE(this, (Panel)this.Parent);//last stop here
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
    }
}
