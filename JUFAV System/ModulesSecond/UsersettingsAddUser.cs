﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.Messageboxes;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Threading;
//notes //tangalin ung notificationsa login 
namespace JUFAV_System.ModulesSecond
{
    public partial class UsersettingsAddUser : UserControl
    {
        public bool isverfied1;
        public bool isverfied2;
        public bool isverfied3;
        public bool trig = false;
        public int summontype;
        public String username1;
        public ModulesSecond.Userssetaddditems.FileMaintenenance Gitem1;
        public ModulesSecond.Userssetaddditems.Inventory Gitem2;
        public ModulesSecond.Userssetaddditems.Reports Gitem3;
        public ModulesSecond.Userssetaddditems.Sales Gitem4;
        public ModulesSecond.Userssetaddditems.Utilities Gitem5;
        public UsersettingsAddUser(int typeofsummon, String username)
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            CheckifAdmin();
            this.summontype = typeofsummon;
            this.username1 = username;
            if (typeofsummon == 1)
            {
                RoleBox.SelectedIndex = 0;
                onload();
                trig = true;
            }
            else
            {
                //RoleBox.SelectedIndex = 0;
                onloadtype0(username1);

                //update here load current data of the user account 
                button1.Text = "UPDATE ACCOUNT";
                trig = false;


            }


        }


        private void updatedata(String username)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //make sure na yung verification sa txt box ay gumagana paden
            //"UPDATE FROM SUBMODULES SET WHERE USERID = (SELECT USERID FROM USER_INFO WHERE USERNAME = '" +username+"');"
            //array if chbox then for loop? to execute the query or just hereby declare each chbox name in set()
            this.Cursor = Cursors.WaitCursor;
            Gitem5.update1();//execute the method directly into the utlitities databox checkbox same with other databox
            Gitem4.update1();
            Gitem3.update1();
            Gitem2.update1();
            Gitem1.update1();
            UpdateUserInfo();



            this.Cursor = Cursors.Default;
            initd.con1.Close();

        }
        private void onloadtype0(String username)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //fetch role
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT ROLES FROM USER_INFO WHERE USERIDS = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + username + "' );", initd.con1);
            int role = Convert.ToInt32(scom1.ExecuteScalar());
            MySql.Data.MySqlClient.MySqlDataReader sq1;

            ModulesSecond.Userssetaddditems.FileMaintenenance item1 = new Userssetaddditems.FileMaintenenance(role, 0, username);
            ModulesSecond.Userssetaddditems.Inventory item2 = new Userssetaddditems.Inventory(role, 0, username);
            ModulesSecond.Userssetaddditems.Reports item4 = new Userssetaddditems.Reports(role, 0, username);
            ModulesSecond.Userssetaddditems.Sales item3 = new Userssetaddditems.Sales(role, 0, username);
            ModulesSecond.Userssetaddditems.Utilities item5 = new Userssetaddditems.Utilities(role, 0, username);

            this.Gitem1 = item1;
            this.Gitem2 = item2;
            this.Gitem3 = item4;
            this.Gitem4 = item3;
            this.Gitem5 = item5;
            UserControl[] sp1 = { item5, item4, item1, item2, item3 };

            foreach (UserControl i in sp1)
            {
                ItemsBox.Controls.Add(i);
                //
                // Thread.Sleep(500);
            }
            //also load some data based on the username

            scom1.CommandText = "SELECT * FROM USER_INFO WHERE USERIDS = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + username1 + "' );";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                NAME_FIELD.Text = sq1["NAME"].ToString();
                USERNAME_FIELD.Text = sq1["USERNAME"].ToString();
                PASSWORD_FIELD.Text = sq1["PASSWORDS"].ToString();
                CONFIRM_PASSWORD_FIELD.Text = sq1["PASSWORDS"].ToString();
                EMAIL_FIELD.Text = sq1["EMAIL"].ToString();
                fetchRole2(Convert.ToInt32(sq1["ROLES"]));
            }
           
            sq1.Close();
            sq1 = null;
            scom1 = null;

            initd.con1.Close();
        }
        private void UpdateUserInfo()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE USER_INFO SET NAME = '" + NAME_FIELD.Text + "',USERNAME = '" + USERNAME_FIELD.Text.Trim() + "',PASSWORDS = '" + PASSWORD_FIELD.Text + "',EMAIL = '" + EMAIL_FIELD.Text + "',ROLES = " + fetchRole() + " WHERE USERIDS = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + username1 + "' );", initd.con1);
            Console.WriteLine("USER BEING UPDATED00 CALLING FROM " + this.Name + username1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                NAME_FIELD.Text = sq1["NAME"].ToString();
                USERNAME_FIELD.Text = sq1["USERNAME"].ToString();
                PASSWORD_FIELD.Text = sq1["PASSWORDS"].ToString();
                CONFIRM_PASSWORD_FIELD.Text = sq1["PASSWORDS"].ToString();
                EMAIL_FIELD.Text = sq1["EMAIL"].ToString();
                RoleBox.Text = sq1["ROLES"].ToString();
            }
            sq1.Close();
            sq1 = null;
            scom1 = null;

            initd.con1.Close();

        }
        public void onload()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }

            ItemsBox.HorizontalScroll.Enabled = false;
            ItemsBox.HorizontalScroll.Visible = false;
            ItemsBox.VerticalScroll.Visible = true;
            ItemsBox.VerticalScroll.Enabled = true;

            ModulesSecond.Userssetaddditems.FileMaintenenance item1 = new Userssetaddditems.FileMaintenenance(fetchRole(), 1, "");
            ModulesSecond.Userssetaddditems.Inventory item2 = new Userssetaddditems.Inventory(fetchRole(), 1, "");
            ModulesSecond.Userssetaddditems.Reports item4 = new Userssetaddditems.Reports(fetchRole(), 1, "");
            ModulesSecond.Userssetaddditems.Sales item3 = new Userssetaddditems.Sales(fetchRole(), 1, "");
            ModulesSecond.Userssetaddditems.Utilities item5 = new Userssetaddditems.Utilities(fetchRole(), 1, "");
            this.Gitem1 = item1;
            this.Gitem2 = item2;
            this.Gitem3 = item4;
            this.Gitem4 = item3;
            this.Gitem5 = item5;
            UserControl[] sp1 = { item5, item4, item3, item2, item1 };
            foreach (UserControl i in sp1)
            {
                ItemsBox.Controls.Add(i);

            }

            //from item1 but inconsistent



            initd.con1.Close();
        }
        private void backtousersettings()
        {

            this.Hide();
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.UserSettings Sup = new ModulesMain.FILEMAINTENANCE.UserSettings();
            ResponsiveUI1.title = "UserSettings";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sup);

        }
        private void inserintoDB()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String id = "";//Users table
            String iduserinfo = "";//User_info table
            //retreive make sure it doesnt match any in the db
            //users id digit is only 5
            for (int i = 0; i != 5; i++)
            {
                id = string.Concat(id, rs1.Next(0, 9).ToString());
            }
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO USERS VALUES (" + Convert.ToInt32(id) + ");", initd.con1);
            scom.ExecuteNonQuery();
            //user_info id digit is 7
            for (int i = 0; i != 7; i++)
            {
                iduserinfo = string.Concat(iduserinfo, rs1.Next(0, 9).ToString());
            }
            scom.CommandText = "INSERT INTO USER_INFO VALUES(" + Convert.ToInt32(iduserinfo) + "," + Convert.ToInt32(id) + ",'" + NAME_FIELD.Text.ToLower() + "','" + USERNAME_FIELD.Text.Trim() + "','" + EMAIL_FIELD.Text + "','" + PASSWORD_FIELD.Text + "'," + fetchRole() + ");";
            scom.ExecuteNonQuery();
            Thread.Sleep(1500);
            //need nila IDInserdata(,usersID);
            Gitem1.InsertData(Convert.ToInt32(id));
            Thread.Sleep(1500);
            Gitem2.InsertData(Convert.ToInt32(id));
            Thread.Sleep(1500);
            Gitem3.InsertData(Convert.ToInt32(id));
            Thread.Sleep(1500);
            Gitem4.InsertData(Convert.ToInt32(id));
            Thread.Sleep(1500);
            Gitem5.InsertData(Convert.ToInt32(id));


            this.Cursor = Cursors.Default;
            initd.con1.Close();
        }
        private void successfullyinsertedOK()
        {
            //execute query first and database
            //error
            String[] messages = { "ACCOUNT SUCCESSFULY UPDATED,   WOULD YOU LIKE TO GO BACK IN THE USER SETTINGS FRONT PAGE?", "ACCOUNT SUCCESSFULY CREATED,   WOULD YOU LIKE TO GO BACK IN THE USER SETTINGS FRONT PAGE?" };
            String[] titles = { "UPDATE ACCOUNT", "ACCOUNT CREATION" };
            int messagetypes = 0;
            if (summontype == 0)
            {
                messagetypes = 0;
                updatedata(username1);
            }
            else
            {
                messagetypes = 1;
                inserintoDB();
            }


            Messageboxes.MessageboxConfirmation sp2 = new MessageboxConfirmation(backtousersettings, 0, titles[messagetypes], messages[messagetypes], "OK", 0);
            sp2.Show();
            sp2.BringToFront();



        }
        private void areyousure()
        {
            String[] titles = { "CONFIRM BEFORE UPDATING", "CONFIRM BEFORE INSERTING" };
            int messagetypes = 0;
            if (summontype == 1)
            {
                messagetypes = 0;
            }
            else
            {
                messagetypes = 1;
            }
            Messageboxes.MessageboxConfirmation ms = new MessageboxConfirmation(successfullyinsertedOK, 0, titles[messagetypes], "ARE YOU SURE YOU INPUTED THE RIGHT VALUES?", "OK", 2);
            ms.Show();
            //Insert into database

            // insertintodb();



        }
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;

            TextBox[] textboxes = { NAME_FIELD, USERNAME_FIELD, PASSWORD_FIELD, CONFIRM_PASSWORD_FIELD, EMAIL_FIELD };
            PictureBox[] notificationimage = { NameNotification, Usernamenot, paswnot, conpaswnot, emailnot };
            Label[] textnoti = { label12, label11, label10, label9, label13 };
            //check pass and conf is =
            if (NAME_FIELD.Text == "" || USERNAME_FIELD.Text == "" || PASSWORD_FIELD.Text == "" || CONFIRM_PASSWORD_FIELD.Text == "" || EMAIL_FIELD.Text == "")
            {
                for (int i = 0; i != 5; i++)
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
                    if (Regex.IsMatch(textboxes[i].Text, @"[^a-zA-Z0-9\s]"))
                    {
                        Messageboxes.MessageboxConfirmation ms = new MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                        ms.Show();
                        isverfied2 = false;
                        break;
                    }


                }
            }
            if (isverfied2 == true && isverfied1 == true && checkduplicate() == false)
            {

                isverfied3 = false;

            }
            else
            {
                isverfied3 = true;

            }
            if (isverfied2 == true && isverfied1 == true && isverfied3 == true)
            {
                passwordconfirm();
            }

        }
        public bool checkduplicate()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM USER_INFO;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (USERNAME_FIELD.Text.Trim() == sread1["USERNAME"].ToString())
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "USERNAME DUPLICATION", "THE USERNAME : " + USERNAME_FIELD.Text + " IS ALREADY IN USE \n PLEASE USE OTHER USERNAME.", "OK", 0);
                    msg2.Show();
                    test1 = false;
                    break;
                }
            }
            sread1.Close();
            initd.con1.Close();
            return test1;
        }
        public void passwordconfirm()
        {

            if (PASSWORD_FIELD.Text == CONFIRM_PASSWORD_FIELD.Text)//make sure na yung dalawang text scanner wala ng nasagap ng non character
            {

                areyousure();
            }
            else
            {
                Messageboxes.MessageboxConfirmation ms = new MessageboxConfirmation(null, 1, "CONFIRM PASSWORD", "YOUR PASSWORD DOES NOT MATCH,PLEASE RE CONFIRM YOU", "RETRY", 1);
                ms.Show();
            }


        }
        public void CheckifAdmin()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            int isadmin = 0;
            MySql.Data.MySqlClient.MySqlCommand sql1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT ROLES FROM USER_INFO WHERE USERIDS =" + initd.UserID + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = sql1.ExecuteReader();
            while (sq1.Read())
            {
                isadmin = Convert.ToInt32(sq1["ROLES"]);
            }
            Console.WriteLine(isadmin);

            if (isadmin == 1)
            {

                Console.WriteLine(isadmin);
                //check all checkboexes


            }
            else
            {
                Console.WriteLine(isadmin);


            }
            //check all no need to fetch in database

            initd.con1.Close();
        }
        public void hide()
        {
            PictureBox[] notificationimage = { paswnot, Usernamenot, NameNotification, conpaswnot, emailnot };
            Label[] textnoti = { label12, label10, label11, label9, label13 };
            for (int i = 0; i != 4; i++)
            {


                notificationimage[i].Visible = false;
                textnoti[i].Visible = false;



            }

        }
        private void fetchRole2(int id)
        {


            switch (id)
            {
                case 1:
                    RoleBox.SelectedIndex = 0;
                    break;
                case 2:
                    RoleBox.SelectedIndex = 1;
                    break;
                case 3:
                    RoleBox.SelectedIndex = 2;
                    break;
            }

        }
        private int fetchRole()
        {

            int roletype = 1;
            switch (RoleBox.SelectedItem.ToString())
            {
                case "ADMIN":
                    roletype = 1;
                    break;
                case "SALES CLERK":
                    roletype = 2;
                    break;
                case "INVENTORY CLERK":
                    roletype = 3;
                    break;
            }
            return roletype;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //execute query here 
            Console.WriteLine("TEST ");
            hide();
            verify();



        }
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.UserSettings Sup = new ModulesMain.FILEMAINTENANCE.UserSettings();
            ResponsiveUI1.title = "UserSettings";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sup);

        }
        private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when role box selected changed

            if (trig == true && summontype == 1)
            {
                String[] names = { "FileMaintenenance", "Inventory", "Sales", "Reports", "Utilities" };
                if (ItemsBox.Controls.Count != 0)
                {
                    foreach (String i in names)
                    {
                        ItemsBox.Controls.Find(i, true)[0].Dispose();


                    }
                    ItemsBox.Controls.Clear();
                }
                ModulesSecond.Userssetaddditems.FileMaintenenance item1 = new Userssetaddditems.FileMaintenenance(fetchRole(), 1, "");
                ModulesSecond.Userssetaddditems.Inventory item2 = new Userssetaddditems.Inventory(fetchRole(), 1, "");
                ModulesSecond.Userssetaddditems.Reports item4 = new Userssetaddditems.Reports(fetchRole(), 1, "");
                ModulesSecond.Userssetaddditems.Sales item3 = new Userssetaddditems.Sales(fetchRole(), 1, "");
                ModulesSecond.Userssetaddditems.Utilities item5 = new Userssetaddditems.Utilities(fetchRole(), 1, "");
                this.Gitem1 = item1;
                this.Gitem2 = item2;
                this.Gitem3 = item4;
                this.Gitem4 = item3;
                this.Gitem5 = item5;
                UserControl[] sp1 = { item5, item4, item3, item2, item1 };

                foreach (UserControl i in sp1)
                {
                    ItemsBox.Controls.Add(i);

                }



            }

        }

        private void USERNAME_FIELD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
