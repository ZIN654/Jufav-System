using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using JUFAV_System.dll;
using System.Threading;

namespace JUFAV_System.ModulesMain.UTILITIES
{
    public partial class BCKRS : UserControl
    {
        public BCKRS()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            Pane.Dock = DockStyle.Fill;
            loaddata();

        }
        private void loaddata()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM BACKUPINFO ORDER BY BPID DESC LIMIT 1;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                label2.Text = "PATH : " + sread1["PATH"].ToString();
                label4.Text = sread1["DATEOFB"].ToString();
            }
            sread1.Close();
             initd.con1.Close();
        }
        public void databaseBack()
        {
            //first replace the name of the db 
            //filename for directpry
         

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                this.Cursor = Cursors.WaitCursor;
    
       
                if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand();
                scom1.Connection = initd.con1;
                MySql.Data.MySqlClient.MySqlBackup bc1 = new MySql.Data.MySqlClient.MySqlBackup(scom1);
                bc1.ExportToFile(saveFileDialog1.FileName);


                scom1.CommandText = "INSERT INTO BACKUPINFO(DATEOFB,PATH) VALUES('"+DateTime.Now.ToShortDateString()+"','"+saveFileDialog1.FileName+"')";
                scom1.ExecuteNonQuery();
                initd.con1.Close();


            
                this.Cursor = Cursors.Default;
                Console.WriteLine("SUCCESSFULLY BACKED UP");



                Messageboxes.MessageboxConfirmation ms2 = new Messageboxes.MessageboxConfirmation(null, 1, "DATABASE BACKUP", "DATABASE SUCCESSFULLY CREATED BACKUP!", "RETRY", 0);
                ms2.Show();
            }

        }
        public void databaserest()
        {
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
              

              
                if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
                MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand();
                scom1.Connection = initd.con1;

                MySql.Data.MySqlClient.MySqlBackup bc1 = new MySql.Data.MySqlClient.MySqlBackup(scom1);
                bc1.ImportFromFile(openFileDialog1.FileName);
                initd.con1.Close();
               
                this.Cursor = Cursors.Default;
                Console.WriteLine("SUCCESSFULLY BACKED UP");

                Messageboxes.MessageboxConfirmation ms2 = new Messageboxes.MessageboxConfirmation(null, 0, "DATABASE RESTORATION", "DATABASE RESTORED SUCCESSFULLY!", "RETRY", 2);
                ms2.Show();

            }

        }

        private void bxkBTN_Click(object sender, EventArgs e)
        {
            databaseBack();
        }

        private void rstrBTN_Click(object sender, EventArgs e)
        {
            databaserest();
        }

      
    }
}
