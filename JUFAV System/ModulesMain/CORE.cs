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

using System.IO;


namespace JUFAV_System.ModulesMain
{
    public partial class CORE : Form
    {
        public static int switchshow = 0;
        
        //apply margin zero later
        public CORE()
        {

            // this.container1.Controls.Add(Bcres);
            InitializeComponent();
            SET_CONTROLS_PARAMETER();
            addevents();
            ResponsiveUI1.headingtitle = TITLEHEADING;

          //  ModulesMain.UTILITIES.raikage akp = new ModulesMain.UTILITIES.raikage();
           ResponsiveUI1.spl1 = panel1;


            //debug
            ModulesMain.DASHBOARD dash1 = new ModulesMain.DASHBOARD();
            panel1.Controls.Add(dash1);
            ResponsiveUI1.title = "DASHBOARD";

        }
        public void addevents()
        {
            backgroundWorker1.RunWorkerAsync();
           
            //=====================================BACK GROUND PROCESS============================SEPARETE THREAD
            backgroundWorker1.DoWork += (sender,e) =>
            {
               SetTime();
               
            };
            //DATE SETT
            SetDate(DateTime.Now);
            //NOTE USE PANEL FOR BUTTONS TO REMOVE THE BORDER  OUTLINES TO  BECOM SEAMLES
            //refine this part clean optimize


            Button logout = new Button();
            logout.Hide();
            logout.Size = new Size(100, 25);
            logout.Text = "LOGOUT";
            logout.Location = new Point(12, 12);
            logout.FlatAppearance.BorderSize = 2;
            logout.FlatAppearance.BorderColor = Color.AntiqueWhite;
            logout.BackColor = Color.AliceBlue;
            logout.Cursor = Cursors.Hand;
            PROFILE.Controls.Add(logout);
            //leakable
            panel1.ControlRemoved += release;
            //un leakable
            LOGOUTBTN.Click += (sender,e) => {logout.BringToFront(); logout.Show();
               
            };
            logout.MouseLeave += (sender, e) => { logout.Hide(); };
            logout.Click += (sender,e) => { Environment.Exit(0); };
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
            COREUTILITIES.Utilities Option5 = new COREUTILITIES.Utilities();
            COREUTILITIES.Reports Option4 = new COREUTILITIES.Reports();
            COREUTILITIES.Sales Option3 = new COREUTILITIES.Sales();
            COREUTILITIES.Inventory Option2 = new COREUTILITIES.Inventory();
            COREUTILITIES.Filemaintenance Option1 = new COREUTILITIES.Filemaintenance();
            COREUTILITIES.DASHBOARD Option = new COREUTILITIES.DASHBOARD(TITLEHEADING);
            Control [] objects = {Option5, Option4,Option3,Option2,Option1,Option };
            for (int i =0;i != 6;i++)
            {
               
                OPTIONS.Controls.Add(objects[i]);
                OPTIONS.Controls.SetChildIndex(objects[i],i);
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
            
           while(1 == 1)
            {
                //send this value to the label without changeing the thread and the thread is 
              DateTime.Now.ToLongTimeString();


               Thread.Sleep(1000);
              


            }
           

        }

        private void release(object sender,EventArgs e)
        {
            
            Console.WriteLine("memory leaks released");
        }
    }
}
