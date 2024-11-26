using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;
using System.Data.SQLite;

namespace JUFAV_System.Components
{
    public partial class SupplierComponentAddprod : UserControl
    {
        int QueryID;
        int productID;
        int summonmode2;
        int splidl;
        public SupplierComponentAddprod(String Compname, String ConPer, String ConNum, String ConAdd, int queryID1, int summonmode, int prodID1, int supplierID)
        {
            //if summon mode EDIT tangal rekta sa query
            InitializeComponent();
            this.Dock = DockStyle.Top;
            productID = prodID1;

            label1.Text = Compname;
            label2.Text = ConPer;
            label3.Text = ConNum;
            label4.Text = ConAdd;
            summonmode2 = summonmode;

            if (summonmode2 == 0)
            {
                QueryID = queryID1;

            }
            else
            {
                splidl = supplierID;

            }



        }
        private void delete1()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM PRODUCTSUPPLIER WHERE PRODUCTID = " + productID + " AND SUPPLIERID = " + splidl + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            initd.con1.Close();
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE SUPPLIER", "THE SELECTED SUPPLIER WAS REMOVED SUCCESSFULLY!", "CLOSE", 1);
            msg1.Controls.Find("btnclose", true)[0].Visible = false;
            msg1.Show();

            //removes itslef froom querybank also
        }
        private void deleteQuery()
        {
            this.Dispose();
            initd.QueryIDsProd.Remove(QueryID);
            //removes itslef froom querybank also
        }
        private void deleteSQL()
        {
            Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(delete1, 0, "DELETE SUPPLIER", "ARE YOU SURE YOU WANT TO REMOVE THIS SUPPLIER?", "DELETE", 2);
            msg1.Show();
        }
        private void deleteBTN_Click(object sender, EventArgs e)
        {
            if (summonmode2 == 0)
            {
                deleteQuery();
            }
            else
            {
                deleteSQL();
                //for edit mode

            }
        }
    }
}
