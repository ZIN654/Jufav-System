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

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class UserSettings : UserControl
    {
        private  int trigger = 1;
      
        public UserSettings()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevents();
            //backcolor COntrol
            //panels color Controllight
        }
        public void setcontrol()
        {
            ItemsBox.HorizontalScroll.Enabled = false;
            ItemsBox.VerticalScroll.Enabled = true;
            ItemsBox.HorizontalScroll.Visible = false;
            ItemsBox.VerticalScroll.Visible = true;

        }
        public void addevents()
        {
            addaccountBTN.Click += AddacountClick;

        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            initd.hs1.Clear();
             MySql.Data.MySqlClient.MySqlCommand scom = new  MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM USER_INFO WHERE USERIDS = "+initd.UserID +";",initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
                //if the current user was deleted his/her own account usin his/her account it might show a warning to prevent the inconsistency like : unable  to delete account since it is logged in unless use another Master account
                Components.DataBox item1 = new Components.DataBox(ItemsBox, sq1["NAME"].ToString(), sq1["USERNAME"].ToString(), determinerole(Convert.ToInt32(sq1["ROLES"])));
                initd.hs1.Add(sq1["USERNAME"], sq1["USERIDS"]);
                ItemsBox.Controls.Add(item1);
            }
            sq1.Close();
            scom.CommandText = "SELECT * FROM USER_INFO WHERE ROLES != 1;";
            sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
               //if the current user was deleted his/her own account usin his/her account it might show a warning to prevent the inconsistency like : unable  to delete account since it is logged in unless use another Master account
                Components.DataBox item1 = new Components.DataBox(ItemsBox, sq1["NAME"].ToString(), sq1["USERNAME"].ToString(), determinerole(Convert.ToInt32(sq1["ROLES"])));
                initd.hs1.Add(sq1["USERNAME"],sq1["USERIDS"]);
                ItemsBox.Controls.Add(item1);
               

               

            }
            sq1.Close();
            //load all data from database 
            //add containter  containing the data from database
            initd.con1.Close();
        }
        private void AddacountClick(object sender,EventArgs e)
        {
            //show panel where enter acount information
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.UsersettingsAddUser Sup = new ModulesSecond.UsersettingsAddUser(1,"");
            ResponsiveUI1.title = "UsersettingsAddUser";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sup);
            /// Messageboxes.MessageboxConfirmation masg1 = new Messageboxes.MessageboxConfirmation(Insertintodatabase,0,"ADD ACCOUNT","ARE YOU SURE YOU WANT TO ADD THIS ACCOUNT?","CONFIRM",2);
            // masg1.Show();
            // masg1.BringToFront();
        }





        private String determinerole(int role)
        {
            string Main = "";
            switch (role)
            {
                case 1:
                    Main = "ADMINISTRATOR";
                    break;
                case 2:
                    Main = "SALES CLERK";
                    break;
                case 3:
                    Main = "INVENTORY CLERK";
                    break;
            }

            return Main;

        }

        private void rcverpassBTN_Click(object sender, EventArgs e)
        {
            changevisibility();
        }
        public void changevisibility()
        {
            bool state;

            if (trigger == 1) {
                state = true;
                trigger = 0;
                rcverpassBTN.BackColor = SystemColors.ControlDarkDark;
               
            }
            else {
                state = false;
                trigger = 1;
                rcverpassBTN.BackColor = SystemColors.Control;
            }
            for (int i = 0; i != ItemsBox.Controls.Count; i++)
            {
                ItemsBox.Controls.Find("rcvBTN", true)[i].Visible = state;

            }


        }
    }
}
