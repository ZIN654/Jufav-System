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
//using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace JUFAV_System.Ffirstrun
{
    public partial class FirstRun : Form
    {
        public static bool isverfied1;
        public static bool isverfied2;
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
                ModulesMain.LOGIN.JUFAV_LOGIN log = new ModulesMain.LOGIN.JUFAV_LOGIN();
                log.Show();
         
            }
            else
            {
                MessageBox.Show("YOU DONT HAVE ACCOUNTS PLEASE CREATE ACCOUNTS FIRST","ACCOUNT CREATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

      
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
            scom = null;
            return accountcount;
        }
        public void insertintodb()
        {
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
            new ModulesSecond.Userssetaddditems.FileMaintenenance(1).InsertData(Convert.ToInt32(id));
            new ModulesSecond.Userssetaddditems.Inventory(1).InsertData(Convert.ToInt32(id));
            new ModulesSecond.Userssetaddditems.Sales(1).InsertData(Convert.ToInt32(id));
            new ModulesSecond.Userssetaddditems.Reports(1).InsertData(Convert.ToInt32(id));
            new ModulesSecond.Userssetaddditems.Utilities(1).InsertData(Convert.ToInt32(id));
            MessageBox.Show("ACCOUNT SUCCESSFULLY CREATED!");
            
        }

        private void Viewpass_Click(object sender, EventArgs e)
        {
            if (PASSWORD.PasswordChar == '*')
            {
                PASSWORD.PasswordChar = '\0';
                Viewpass.Image = JUFAV_System.Properties.Resources.Eye;

            }
            else
            {
                PASSWORD.PasswordChar = '*';
                Viewpass.Image = JUFAV_System.Properties.Resources.Hide;

            }
        }

        private void Viewpasscon_Click(object sender, EventArgs e)
        {
            if (CONFIRM_PASSWORD.PasswordChar == '*')
            {
                CONFIRM_PASSWORD.PasswordChar = '\0';
                Viewpasscon.Image = JUFAV_System.Properties.Resources.Eye;
            }
            else
            {
                CONFIRM_PASSWORD.PasswordChar = '*';
                Viewpasscon.Image = JUFAV_System.Properties.Resources.Hide;


            }
        }
        public void EncryptPassword()
        {




        }
        private void FirstRun_FormClosed(object sender, FormClosedEventArgs e)
        {
            initd.closedatabase();
        }
    }
}
