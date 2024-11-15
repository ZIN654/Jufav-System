using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using JUFAV_System.dll;
using JUFAV_System.ModulesMain;
using System.Data.SQLite;
using System.Collections;

using System.IO;


namespace JUFAV_System.ModulesMain
{
    public partial class CORE : Form
    {
        public static int switchshow = 0;
        bool trig = true;
        private  UserControl loginpanel;//pag nag logout show nalang ito para hindi na ulit susumon magastos memory
        Panel itemsbox1;
        //apply margin zero later
        public CORE(UserControl loginform,Panel itemsbox)
        {
            this.loginpanel = loginform;
            // this.container1.Controls.Add(Bcres);
            InitializeComponent();
             axWindowsMediaPlayer1.URL = @"C://Users//asus//Desktop//CAPSTONE 2//JUFAV SYSTEM NEW - Copy//Jufav-System//JUFAV System//Resources//JufavLogoback.mp4";
            //set this one if publishing
            //axWindowsMediaPlayer1.URL = @Environment.CurrentDirectory + "//Resources//JufavLogoback.mp4";
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);

            addevents();
            itemsbox1 = itemsbox;
            //BUG DITO FIRST RUN TAS ERROR PAH IOPEN MO PRAGMA KEY PAG CLOSE UNG DELETION NG SALES
           // initd.opendatabase();
            //  initd.opendatabase();//do not open database in any other panel since mag bubukas na sya sa 
            //log in panel pa lang  
            Username.Text = initd.username;
            setrole();
            SET_CONTROLS_PARAMETER();
        }
        private void setrole()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT ROLES FROM USER_INFO WHERE USERNAME = '"+initd.username+"';",initd.scon);
            int ROle = Convert.ToInt32(scom1.ExecuteScalar());
            Console.WriteLine("ROLES:" + ROle);
            determinerole(ROle);

        }
        private void determinerole(int role)
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
            Role.Text = Main;
         

        }
        public void addevents()
        {
           //LARGE SPIKE HERE 
            //DATE SETT
            SetDate(DateTime.Now);
            SetTime();
            //NOTE USE PANEL FOR BUTTONS TO REMOVE THE BORDER  OUTLINES TO  BECOM SEAMLES
            //refine this part clean optimize

            /*
            logout.BackColor = Color.AliceBlue;
            logout.Cursor = Cursors.Hand;
            PROFILE.Controls.Add(logout);
            //leakable
            panel1.ControlRemoved += release;
            //un leakable
            //LARGE SPIKE HERE 
            LOGOUTBTN.Click += (sender,e) => {logout.BringToFront(); logout.Show();
            };
            logout.MouseLeave += (sender, e) => { logout.Hide(); };
            logout.Click += (sender,e) => {
                //message box first to determine then if ok 
                

            };
            */

            showide.Click += (sender,e) => {
              if(switchshow  == 0)
                {
                    SplitCon.Panel1Collapsed = true;
                    switchshow = 1;
                    showide.Text = ">";
                }
              else
                {
                    SplitCon.Panel1Collapsed = false;
                    switchshow = 0;
                    showide.Text = "<";
                }
            };

        }
        private void closethis()
        {
            this.Dispose();
            loginpanel.Show();
        }
        public void SET_CONTROLS_PARAMETER()
        {
            //NOTE:in initialize component must verify if the user has accesslevel in this submodule

            //===========Set all controll adjustments here========================
            //same size as the button 130
            TITLEHEADING.Text = "DASHBOARD";
            //add dashboard component
            SplitCon.SplitterDistance = 130;
            OPTIONS.VerticalScroll.Enabled = true;
            OPTIONS.VerticalScroll.Visible = true;
            OPTIONS.HorizontalScroll.Visible = false;
            OPTIONS.HorizontalScroll.Enabled = false;
            //In the first run the DASHBOARD is the first will appearn
            //===========INITIALIZE BUTTONS IN OPTIONS LAYOUT PANEL==============
            //if admin access all id inventory tangal ng iba if sales clerk lagay sales lang
            //check muna kung may access bago add.
            ModulesMain.COREUTILITIES.Filemaintenance2 OptionISClerk = new COREUTILITIES.Filemaintenance2();
            COREUTILITIES.Utilities Option5 = new COREUTILITIES.Utilities();
            COREUTILITIES.Reports Option4 = new COREUTILITIES.Reports();
            COREUTILITIES.Sales Option3 = new COREUTILITIES.Sales();
            COREUTILITIES.Inventory Option2 = new COREUTILITIES.Inventory();
            COREUTILITIES.Filemaintenance Option1 = new ModulesMain.COREUTILITIES.Filemaintenance();
            COREUTILITIES.DASHBOARD Option = new COREUTILITIES.DASHBOARD(TITLEHEADING);
            List<Control> objects = new List<Control>{Option5, Option4,Option1,Option2,Option3, Option };
           
            switch (Role.Text)
            {
                case "ADMINISTRATOR":
                    //do nothing just add all
                  
                    break;
                case "SALES CLERK":
                  
                    break;
                case "INVENTORY CLERK":
                   
                   
                    break;

            }
            foreach(Control items in objects)
            {
               
                OPTIONS.Controls.Add(items);
                
            }
           
        }
        public void SetDate(DateTime today)
        {
            //One time run only each load of the panel
            //time date must be moving 
            //set null when no longer needed garabage collector na bahala
          
            Date.Text = today.ToShortDateString();
        }
        public void SetTime()
        {
            //if this form disposed delete cache
            //if this form is hide pause
            Time.Text = DateTime.Now.ToLongTimeString(); ;
            
        }

        private void release(object sender,EventArgs e)
        {
            
          
        }
        private void CORE_Load(object sender, EventArgs e)
        {
            ResponsiveUI1.headingtitle = TITLEHEADING;

            //  ModulesMain.UTILITIES.raikage akp = new ModulesMain.UTILITIES.raikage();
            ResponsiveUI1.spl1 = panel1;


            //debug
            ModulesMain.DASHBOARD dash1 = new ModulesMain.DASHBOARD();
            panel1.Controls.Add(dash1);
            ResponsiveUI1.title = "DASHBOARD";
            deletesales();
           
        }
        private void deletesales()
        {
            try
            {
                
                    Console.WriteLine("TEST IT WAS CLEARED");
                    initd.closedatabase();
                    initd.opendatabase();
                    SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM ORDERSTEMPO", initd.scon);
                    scom1.ExecuteNonQuery();
                    scom1 = null;
                    GC.Collect();
              
              
            }
            catch (Exception e)
            {
                Console.WriteLine("DATABASE IS LOCKED PLEASE TRY AGAIN LATER" + e);
              
            }



        }
        private void CORE_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResponsiveUI1.title = "LoginPanel";
            ResponsiveUI1.spl1 = itemsbox1;
            deletesales();    
        }
        private void CORE_Leave(object sender, EventArgs e)
        {
            deletesales();          
        }
        private void CORE_FormClosing(object sender, FormClosingEventArgs e)
        {
            deletesales();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(closethis, 0, "LOGOUT", "ARE YOU SURE YOU WANT TO LOGOUT", "LOGOUT", 0);
            msg2.Show();
        }
    }
}
