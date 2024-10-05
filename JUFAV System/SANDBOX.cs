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
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using JUFAV_System.dll;
using System.Data.SqlClient;


using System.Data.SQLite;

namespace JUFAV_System
{
    public partial class SANDBOX : Form
    {
        public static String[] users = {"admin1","admin2","admin3","admin4","admin5","admin6","admin7","admin8","admin9","admin10","admin11","admin12","admin13","admin14","admin15","admin16","admin17","admin18","admin19","admin20","admin21","admin22","admin23","admin24"};
        public static int lastcount;
        public static int loopset = 0;//kung saan mag iistart ulet yung loop
        public static int current = 0;//kung saan last tumigil yung loop
        public static int countlimit = 10;
        //check length /record the index start count if 10 na yung item record mo kung saang index so we can read it based on that gaya ng starting point 0
        //ang starting point ay 0 then ang show count ay 10  
        public SANDBOX()
        {
            InitializeComponent();

            // set();
            // Thread.Sleep(1500);
            // set();
            // Thread.Sleep(1500);
            // set();
            loaddata();

        }
        public void loaddata()
        {
         
        }
        public void set()
        {
            //for changing array starting point to read
            LastIndex.Text = users.Length.ToString();


            //before loop begins musst check kung yung natirang last part ay equally or greater 10
            //if not set the last ammount to  the count limit to avoid exception
            //but kung greater set to 10
            // int check = lastcount - users.Length;

            Console.WriteLine("LAST COUNT :" + lastcount + "   " + "LOOP SET: " + loopset + "   " + "COUNT LIMIT " + countlimit + "    " + "CURRENT" + current);
            for (int i = loopset;i != countlimit;i++)
            {
                Console.WriteLine("DISPLAYING DATA 10 Entry Data : " + users[i]);
                lastcount = i;
            }
          
            current = users.Length - lastcount;//ilan nalng ang natitira 10
           // Console.WriteLine("nasaanoart na ? :" + lastcount);//9

            loopset = lastcount ;//iseset nito kung saan sya mag iistart 

            //check sa natitira
            int check =  users.Length -lastcount ;
            if (check > 10)
            {
                countlimit += 10;
            }
            else
            {
                countlimit += check - 1;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //salt
            //hash algorithm
         //implement hashing algorithm using SHA-256 with salting technique
            // finds any non word character \\W
            //finds any space white character \\S
            /*
            if (Regex.IsMatch(textBox1.Text,"\\W\\S")){
                MessageBox.Show("FIND ONE");



            }
            else
            {

                MessageBox.Show("FIND NOT ONE");

            }
            */
        }
    }
}
