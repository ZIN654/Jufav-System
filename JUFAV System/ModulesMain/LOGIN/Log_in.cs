﻿using System;
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
using System.Net;




namespace JUFAV_System.ModulesMain.LOGIN
{
    public partial class JUFAV_LOGIN : Form
    {

    
        public JUFAV_LOGIN()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "None";
           //axWindowsMediaPlayer1.URL = @"C://Users//asus//Desktop//CAPSTONE 2//JUFAVSYSTEM//Jufav-System//JUFAV System//Resources//JufavLogoback.mp4";
           //set this one if publishing
           axWindowsMediaPlayer1.URL = @Environment.CurrentDirectory + "//Resources//JufavLogoback.mp4";
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            ResponsiveUI1.spl2 = itemsbox;
           
            loadpanel();
        }
        private void loadpanel()
        {
          
            ModulesMain.LOGIN.LoginPanel login = new ModulesMain.LOGIN.LoginPanel();//perhaps us the name of the username txtbx
            ResponsiveUI1.title3 = "LoginPanel";
            itemsbox.Controls.Add(login);
        }
        private void JUFAV_LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void JUFAV_LOGIN_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("TEST WRERITE");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
