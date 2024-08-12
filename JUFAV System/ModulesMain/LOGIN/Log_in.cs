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

namespace JUFAV_System.ModulesMain.LOGIN
{
    public partial class Log_in : Form
    {
        private static int switch1 = 0;
        public Log_in()
        {
            InitializeComponent();
            addevents();
        }
        public void addevents()
        {
            lgnBTN.Click += loginBTN;
            eyeBTN.Click += hideshowpassBTN;
            clsBTN.Click += closeBTN;
            clsBTN.MouseEnter += Onenter;
            clsBTN.MouseLeave += OnLeave;
            forgotBTN.Click += forgotpass;
            txtboxPASS.Click += clickpass;
            txtBxUSER.Click += clickuser;
            txtboxPASS.MouseLeave += passleave;
            txtBxUSER.MouseLeave += userleave;
        }



        private void loginBTN(object sender,EventArgs e) {
            //connection  /check /login

            ModulesMain.CORE init = new ModulesMain.CORE();
            init.BringToFront();
            init.Show();
            this.Hide();
            //hide() or Dispose()? dispose optimized memory
           //ClearLeaks(); only clear when the login attempts is successfull
        }
        private void hideshowpassBTN(object sender, EventArgs e)
        {
            if (switch1 == 0)
            {
                eyeBTN.Image = Resources.Hide;
                switch1 = 1;
            }
            else
            {
                eyeBTN.Image = Resources.Eye;
                
                switch1 = 0;
            }

        }
        private void closeBTN(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void forgotpass(object sender, EventArgs e) { }
        private void Onenter(object sender,EventArgs e)
        {
            ResponsiveUI1.OnenterUI(clsBTN);

        }
        private void OnLeave(object sender,EventArgs e)
        {
            ResponsiveUI1.OnLeave(clsBTN);
        }

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




        //=====================MEMORY MANAGEMENT========================
        public void ClearLeaks()
        {
            lgnBTN.Click -= loginBTN;
            eyeBTN.Click -= hideshowpassBTN;
            clsBTN.Click -= closeBTN;
            clsBTN.MouseEnter -= Onenter;
            clsBTN.MouseLeave -= OnLeave;
            forgotBTN.Click -= forgotpass;
            txtboxPASS.Click -= clickpass;
            txtBxUSER.Click -= clickuser;
            txtboxPASS.MouseLeave -= passleave;
            txtBxUSER.MouseLeave -= userleave;
            //dispose memory allocation to avoid memory leaks and reduce memory consumption: garbage collector na  bahala
        }
    }
}
