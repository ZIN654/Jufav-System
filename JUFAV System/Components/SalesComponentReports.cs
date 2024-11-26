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
    public partial class SalesComponentReports : UserControl
    {
        int saleID = 0;
        String ref1;
        //32 -143
        public SalesComponentReports(String Custname, String TotalAmount, String Discount, String NumbITEMS, String DateOfsales, String PaymentMethod, String CustomerPayment, int SaleID, String reference)
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;
            ref1 = reference;
            saleID = SaleID;
            label1.Text = Custname;
            label5.Text = DateOfsales;
            label2.Text = TotalAmount;
            label4.Text = NumbITEMS;
            label3.Text = Discount;
            label7.Text = CustomerPayment;
            label6.Text = PaymentMethod;
            if (PaymentMethod == "GCASH")
            {
                button2.Visible = true;
            }

        }

        private void LoadInfo()
        {
            dataGridView1.Columns.Add("PRODUCT NAME", "PRODUCT NAME");
            dataGridView1.Columns.Add("QUANTITY", "QUANTITY");
            dataGridView1.Columns.Add("UNIT COST", "UNIT COST");
            dataGridView1.Columns.Add("TOTAL COST", "TOTAL COST");
            dataGridView1.Columns["PRODUCT NAME"].Width = 350;
            dataGridView1.Columns["QUANTITY"].Width = 70;
            dataGridView1.Columns["UNIT COST"].Width = 150;
            dataGridView1.Columns["TOTAL COST"].Width = 150;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            //  mamay aito
            //insert into data gridview
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM ORDERSTABLE WHERE SALEID = " + saleID + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //ang order data dapat product name at kung ilang items ung laman nya
                dataGridView1.Rows.Add(sread1["ITEMNAME"].ToString(), sread1["QUANTITY"].ToString(), sread1["ITEMPRICE"].ToString(), sread1["TOTALPURCHASE"].ToString());
                /// DatatoUpdate.Add(new KeyValuePair<String, String>(sread1["ITEMID"].ToString(), sread1["QUANTITY"].ToString()));
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
            GC.Collect();


        }
        private void ViewItems_Click(object sender, EventArgs e)
        {
            LoadInfo();
            if (this.Size.Height == 32)
            {
                this.Size = new System.Drawing.Size(0, 143);
            }
            else
            {
                this.Size = new System.Drawing.Size(0, 32);
            }
            GC.Collect();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Components.RemarksBox rm1 = new RemarksBox(ref1);
            rm1.Controls.Find("remarks", true)[0].Text = "REFERENCE NUMBER: ";
            this.Parent.Controls.Add(rm1);
            rm1.BringToFront();
            rm1.Location = new Point(panel1.Location.X - 200, this.Location.Y);
        }
    }
}
