using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections;
using JUFAV_System.dll;
using System.Threading;



namespace JUFAV_System
{
    public partial class DBsetup : Form
    {

        public DBsetup()
        {
            
            InitializeComponent();
          
           
        }

        private void DBsetup_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("This process only runs once so please be patient","DATABSE SETUP" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
            Startboot();


        }
        public void Startboot()
        {
            initd sql1 = new initd();
          
            delay(14, progressBar1);
            sql1.CreatePath();

            
            delay(14, progressBar1);
            sql1.checkpath();

           
            delay(14, progressBar1);
            sql1.CreateDatabase();
            delay(14, progressBar1);
            
           
            sql1.TestConnection(sql1.Constring);
            delay(14, progressBar1);
            sql1.InitializeTable();
            delay(14, progressBar1);
            sql1.InitTableFilemaintenance();
            label1.Text = "PROCESSING" + " COMPLETED";
            delay(14, progressBar1);


            this.Hide();
            Ffirstrun.FirstRun f1 = new Ffirstrun.FirstRun();
            f1.Show();
            f1.BringToFront();
            //after ma set up 
        }
        public void delay(int value, ProgressBar sb1)
        {
            for (int i = 0; i != value; i++)
            {
                sb1.Value += 1;
                Thread.Sleep(100);
            }
        }

    }
}
