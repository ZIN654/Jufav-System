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
    public partial class ProdListtDataBoxComponent : UserControl
    {
        private Size sz1 = new Size(0, 0);
        private int ProdID1;
        public ProdListtDataBoxComponent(String Prodname, String Categpry, String SubCat, Double Quantity, Double UniCost, Double MarkUp, int ProdID)
        {
            InitializeComponent();
            ProdID1 = ProdID;
            this.Dock = DockStyle.Top;


            label1.Text = Prodname;
            label2.Text = Categpry;
            label3.Text = SubCat;
            label4.Text = Quantity.ToString();

            label6.Text = Convert.ToDouble(UniCost).ToString();
            label7.Text = Convert.ToDouble(MarkUp).ToString();


        }
        private void loaddata(int IDtoret)
        {
            //to du bukas//batch products/pdf ng PO/SAles/tas sa PO pag mag aad ng order dapat nag aad sa iisang panel hindi duplicate

            //fix revise
            dataGridView1.Columns.Add("PRODUCT NAME", "PRODUCT NAME");
            dataGridView1.Columns.Add("BATCHNO", "BATCHNO");
            dataGridView1.Columns.Add("QUANTITY", "QUANTITY");
            dataGridView1.Columns.Add("EXPIRATION DATE", "EXPIRATION DATE");
            dataGridView1.Columns["PRODUCT NAME"].Width = 350;
            dataGridView1.Columns["QUANTITY"].Width = 70;
            dataGridView1.Columns["BATCHNO"].Width = 150;
            dataGridView1.Columns["EXPIRATION DATE"].Width = 150;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            //  mamay aito

            //insert into data gridview
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTBATCH WHERE PRODUCTID= " + IDtoret + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //ang order data dapat product name at kung ilang items ung laman nya
                //bug here 

                dataGridView1.Rows.Add(sread1["PRODUCTDESC"].ToString(), sread1["BATCHNO"].ToString(), sread1["QUANTITY"].ToString(), sread1["EXPIRATIONDATE"].ToString());
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
        }


        private void BATCPROD_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 79)
            {
                sz1.Height = 217;
                this.Size = sz1;
            }
            else
            {
                sz1.Height = 79;
                this.Size = sz1;
            }

        }
        private void determinebatchpersh(bool data, PictureBox pc1)
        {
            if (data == true)
            {
                pc1.BackgroundImage = JUFAV_System.Properties.Resources.chkbox;
            }
            else
            {
                pc1.BackgroundImage = null;
            }


        }
    }
}
