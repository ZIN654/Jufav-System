using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;

namespace JUFAV_System.Components
{
    public partial class AuditTrailComponent : UserControl
    {
        int UserID;
        int aud;
        public AuditTrailComponent(int auditID, int USERID, String name, String Role, String Date, String Time, String TotalAciton, String TimeIn, String Timeout)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            aud = auditID;
            UserID = USERID;
            label1.Text = name;
            label2.Text = Date;
            label3.Text = Time;
            label4.Text = TotalAciton;
            label5.Text = Role;
            label6.Text = TimeIn;
            label7.Text = Timeout;


            dataGridView1.Columns.Add("ACTIONS", "ACTIONS");
            dataGridView1.Columns.Add("ACTION TYPE", "ACTION TYPE");
            dataGridView1.Columns.Add("TIMEOFACTION", "TIMEOFACTION");


            dataGridView1.Columns["ACTIONS"].Width = 350;
            dataGridView1.Columns["ACTION TYPE"].Width = 150;
            dataGridView1.Columns["TIMEOFACTION"].Width = 150;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loaddata()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            dataGridView1.Rows.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM AUDITTRAILACTIONSLIST WHERE AUDITID = " + initd.UserIDACtionAudit + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                dataGridView1.Rows.Add(sread1["ACTIONS"].ToString(), sread1["ACTIONTYPE"].ToString(), sread1["TIMEOFACTION"].ToString());
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
            initd.con1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.Size.Height == 62)
            {
                this.Size = new System.Drawing.Size(0, 190);
                loaddata();
            }
            else
            {
                this.Size = new System.Drawing.Size(0, 62);
            }
            GC.Collect();
        }

        private void Archbtn_Click(object sender, EventArgs e)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM AUDITTRAIL WHERE AUDITID = " + aud + ";", initd.con1);
            scom1.ExecuteNonQuery();
            this.Dispose();
            initd.con1.Close();
        }
    }
}
