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
using System.Net;



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
            String TouseIP = "";
            var hostname = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var IP in hostname.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    TouseIP = IP.ToString();
                    break;
                }
            }
            initd sql1 = new initd();
            this.Cursor = Cursors.WaitCursor;
           //delay(12, progressBar1);

           sql1.CreateDB();

            delay(12, progressBar1);
      

            sql1.InitializeTable();
            delay(12, progressBar1);
            sql1.InitializeArcTable();

            delay(12, progressBar1);
            sql1.InitTableFilemaintenance();//fm
            delay(12, progressBar1);
            sql1.InitTableArcFilemaintenance();
          
            delay(12, progressBar1);
            sql1.InitTableInventory();//inventory
            delay(12, progressBar1);
            sql1.ArcInitTableInventory();

            delay(12, progressBar1);
            sql1.InitTableSales();//sales
            delay(12, progressBar1);

            initd.con1.ConnectionString = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;database=jufav2;";//
            initd.constringtouserefresh = @"server=" + TouseIP.Trim() + ";user=root;password=zxcvbnm12;port=3306;database=jufav2;";
            //ARCHIVES
            this.Cursor = Cursors.Default;
            this.Hide();
            Ffirstrun.FirstRun f1 = new Ffirstrun.FirstRun();
            f1.Show();
            f1.BringToFront();
     
        }
        public void delay(int value, ProgressBar sb1)
        {
            for (int i = 0; i != value; i++)
            {
                sb1.Value += 1;
            }
        }

    }
}
