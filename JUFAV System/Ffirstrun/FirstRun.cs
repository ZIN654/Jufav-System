using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using JUFAV_System.Properties;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Threading;
//using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace JUFAV_System.Ffirstrun
{
    public partial class FirstRun : Form
    {
        bool isverfied1;
        bool isverfied2;
        public bool reason;
        public int AdminAccountLimit = 5;
        //if account has same name email .mag kaka error sa hashtable once na mag insert ulet
        //prevent user from inserting the same information.
        //pag nag update ako ng username at iba pang user info make sure na wala itongka pares
        //pag lumapmpas ng 5 show msg box and disable controls and hindi naden makakagawa si admin ng iba pang admin accounts sa kabilang side
        //Pag same Email,Username,Name mag kakaerror sa retrieval kapag inistore sa hashtable since same sila
        //kapag nag delete si user ng isang user lahat ng data maaarchive 
        //just pass the value from herre to next form to hold the info then if the  databas is created insert it into the database
        //then if the settup is complete change into the log in partt

        public FirstRun()
        {
            InitializeComponent();
            addevent();
            initd.opendatabase();
        }
        public void addevent()
        {
            AddBTN.Click += (sender,e) => { addaccounts(); };
            clearBTN.Click += (sender, e) => { clear(); };
            doneBTN.Click += Done;
           
            

        }



        public void clear()
        {
            NAME.Text = "";
            CONFIRM_PASSWORD.Text = "";
            USERNAME.Text = "";
            PASSWORD.Text = "";
            EMAIL.Text = "";
        }
        public void addaccounts()
        {
            hide();
            verify();
            hasaccount();
           

        }



        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;
           
            TextBox[] textboxes = { NAME, USERNAME, PASSWORD, CONFIRM_PASSWORD, EMAIL };
            PictureBox[] notificationimage = { NameNotification, Usernamenot, paswnot, conpaswnot, emailnot };
            Label[] textnoti = { label3, label4, label5, label6, label13 };
            //check pass and conf is =
            if (PASSWORD.Text == "" || USERNAME.Text == "" || NAME.Text == "" || CONFIRM_PASSWORD.Text == "" || EMAIL.Text == "")
            {
                for(int i = 0;i!= 4;i++)
                {
                    if (textboxes[i].Text == "")
                    {
                       // MessageBox.Show("error please Enter input from textbox text : " + textboxes[i].Name);
                        notificationimage[i].Visible = true;
                        textnoti[i].Visible = true;
                        isverfied1 = false;
                        break;
                    }
                   

                }


            }
            else
            {
                for (int i = 0; i != 4; i++)
                {
                    // \\W\\S
                    if (Regex.IsMatch(textboxes[i].Text, "\\W"))
                    {
                        MessageBox.Show("Please Remove a non-letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.","NON CHARACTER INPUT",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        isverfied2 = false;
                        break;
                    }
                    
                         
                }
            }
            if (isverfied2 == true && isverfied1 == true)
            {
                passwordconfirm();
            }
           
        }
        public void passwordconfirm()
        {
            
            if (PASSWORD.Text == CONFIRM_PASSWORD.Text)//make sure na yung dalawang text scanner wala ng nasagap ng non character
                {
                //Insert into database
                insertintodb();

            }
                else
                {
                    MessageBox.Show("PASSWORD DOES NOT MATCH","CONFIRM PASSWORD",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
          

        }
        private void checkaccount(int count)
        {
            if (5 == count)
            {
                AddBTN.Enabled = false;
                clearBTN.Enabled = false;
                NAME.Enabled = false;
                USERNAME.Enabled = false;
                PASSWORD.Enabled = false;
                CONFIRM_PASSWORD.Enabled = false;
                EMAIL.Enabled = false;
            }
        }
        public void hide()
        {
            PictureBox[] notificationimage = { paswnot, Usernamenot, NameNotification, conpaswnot, emailnot };
            Label[] textnoti = { label5, label4, label3, label6, label13 };
            for (int i = 0; i != 4; i++)
            {
             
                  
                    notificationimage[i].Visible = false;
                    textnoti[i].Visible = false;
                   
              

            }

        }
        private void Done(object sender ,EventArgs e)
        {
            //revise initd 
            if (hasaccount() != 0) {
                this.Hide();
                reason = false;
                ModulesMain.LOGIN.JUFAV_LOGIN log = new ModulesMain.LOGIN.JUFAV_LOGIN();
                log.Show();
         
            }
            else
            {
                reason = true;
               
                MessageBox.Show("YOU DONT HAVE ACCOUNTS. PLEASE CREATE ACCOUNTS FIRST","ACCOUNT CREATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

      
            }


        }
        public int hasaccount()
        {
            int accountcount = 0;
            
            SQLiteCommand scom = new SQLiteCommand("SELECT * FROM USERS;", initd.scon);
            SQLiteDataReader reader1 = scom.ExecuteReader();
            while (reader1.Read())
            {
                accountcount++;
            }
            reader1.Close();
            label1.Text = "Available Slots Left : " + (AdminAccountLimit - accountcount);
            reader1 = null;
            scom = null;
            checkaccount(accountcount);
            return accountcount;
        }
        public void insertintodb()
        {
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String id = "";
            String iduserinfo = "";
           
            //retreive make sure it doesnt match any in the db
            //user digit is only 5
            for (int i = 0;i != 5;i++)
            {

                id = string.Concat(id,rs1.Next(0,9).ToString());

            }
            SQLiteCommand scom = new SQLiteCommand("INSERT INTO USERS VALUES (" + Convert.ToInt32(id) + ");", initd.scon);
            scom.ExecuteNonQuery();
            for (int i = 0; i != 7; i++)
            {

                iduserinfo = string.Concat(iduserinfo, rs1.Next(0, 9).ToString());

            }
            
           scom.CommandText = "INSERT INTO USER_INFO VALUES(" + iduserinfo + "," + id + ",'" + NAME.Text + "','" + USERNAME.Text+ "','" + EMAIL.Text + "','" + PASSWORD.Text + "'," + 1 + ");";
            scom.ExecuteNonQuery();
            Thread.Sleep(500);
            new ModulesSecond.Userssetaddditems.FileMaintenenance(1,1,"").InsertData(Convert.ToInt32(id));
            Thread.Sleep(500);
            new ModulesSecond.Userssetaddditems.Inventory(1,1, "").InsertData(Convert.ToInt32(id));
            Thread.Sleep(500);
            new ModulesSecond.Userssetaddditems.Sales(1,1,"").InsertData(Convert.ToInt32(id));
            Thread.Sleep(500);
            new ModulesSecond.Userssetaddditems.Reports(1,1,"").InsertData(Convert.ToInt32(id));
            Thread.Sleep(500);
            new ModulesSecond.Userssetaddditems.Utilities(1,1,"").InsertData(Convert.ToInt32(id));
            Thread.Sleep(500);
            MessageBox.Show("ACCOUNT SUCCESSFULLY CREATED!");
            this.Cursor = Cursors.Default;

        }
        private void Viewpass_Click(object sender, EventArgs e)
        {
            if (PASSWORD.PasswordChar == '*')
            {
                PASSWORD.PasswordChar = '\0';
                Viewpass.Image = JUFAV_System.Properties.Resources.Hide;

            }
            else
            {
                PASSWORD.PasswordChar = '*';
                Viewpass.Image = JUFAV_System.Properties.Resources.Eye;

            }
        }
        private void Viewpasscon_Click(object sender, EventArgs e)
        {
            if (CONFIRM_PASSWORD.PasswordChar == '*')
            {
                CONFIRM_PASSWORD.PasswordChar = '\0';
                Viewpasscon.Image = JUFAV_System.Properties.Resources.Hide;
            }
            else
            {
                CONFIRM_PASSWORD.PasswordChar = '*';
                Viewpasscon.Image = JUFAV_System.Properties.Resources.Eye;


            }
        }
        public void EncryptPassword()
        {




        }
        private void FirstRun_FormClosing(object sender, FormClosingEventArgs e)
        {
            Done(sender, e);
            e.Cancel = reason;
            
        }
    }
}
