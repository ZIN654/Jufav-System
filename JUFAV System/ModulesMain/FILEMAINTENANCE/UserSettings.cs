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

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class UserSettings : UserControl
    {
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
            //load data from database 
            //add containter  containing the data from database
        }
        private void AddacountClick(object sender,EventArgs e)
        {
            //show panel where enter acount information
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.UsersettingsAddUser Sup = new ModulesSecond.UsersettingsAddUser();
            ResponsiveUI1.title = "UsersettingsAddUser";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sup);
            /// Messageboxes.MessageboxConfirmation masg1 = new Messageboxes.MessageboxConfirmation(Insertintodatabase,0,"ADD ACCOUNT","ARE YOU SURE YOU WANT TO ADD THIS ACCOUNT?","CONFIRM",2);
            // masg1.Show();
            // masg1.BringToFront();
        }




        private void Insertintodatabase()
        {
            //INSERT DATABSE

            //debug
            Components.DataBox datadebug1 = new Components.DataBox();
            ItemsBox.Controls.Add(datadebug1);
            Console.WriteLine("THE ITEM IS SUCCESSFULLY INSERTED INTO DATABASE");


            
        }
    }
}
