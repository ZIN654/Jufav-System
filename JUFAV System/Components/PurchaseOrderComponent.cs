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
using System.Threading;

namespace JUFAV_System.Components
{
    public partial class PurchaseOrderComponent : UserControl
    {
        int POID1;
        public PurchaseOrderComponent(int POIDs,String Date1,String Supplier,String time,int ItemCount,double total,String Status,String ExpectedDate)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            POID1 = POIDs;
            POID.Text ="PO " + POIDs.ToString();
            ReceivingDate.Text = ExpectedDate;
            Dateissued.Text = Date1;
            suppliername.Text = Supplier;
            Date.Text = time;
            TotalProducts.Text = ItemCount.ToString();
            totalamount.Text = total.ToString();
            status.Text = Status;
            loaddata();
            //Deter//mineDate(DateTime.Parse(Date1));
            if (Status == "CANCELLED")
            {
                CnclPOBTN.Visible = false;
                Delete.Visible = true;
                Archive.Visible = true;
                //incase na mag kamali just in case na tanungin kami
                //CnclPOBTN.Click += reOrder;
                //CnclPOBTN.Text = "REORDER";
            }
        }
        private void loaddata()
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
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM POITEMORDERTABLE WHERE POID = "+POID1+";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //ang order data dapat product name at kung ilang items ung laman nya
                dataGridView1.Rows.Add(sread1["PRODUCTNAME"].ToString(), sread1["QUANTITY"].ToString(), sread1["ORIGINALPRICE"].ToString(), sread1["TOTAL"].ToString());
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
        }
        private void DeleteRecords()
        {
            this.Cursor = Cursors.WaitCursor;//only available sa cencel
            SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM PURCHASEORDER WHERE POID =  " + POID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY CANCELED!", "OK", 0);
            ms.Show();
        }
        private void Cancel()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PURCHASEORDER SET ORDERSTATUS = 'CANCELLED' WHERE POID = " + POID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "CANCEL ORDER", "ORDER SUCCESSFULLY CANCELED!", "OK", 0);
            ms.Show();
        }
        private void archive()
        {

            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            String[] Queries1 = {"INSERT INTO ARCPURCHASEORDER(POID,USERID, ORDERDATE, EXPECTEDORDERDATE, SUPPLIER, TIMES, TOTALPRODUCTS, TOTALCOST, ORDERSTATUS) SELECT * FROM PURCHASEORDER WHERE POID = " + POID1 + ";", "INSERT INTO ARCPOITEMORDERTABLE(ORDERID,USERID,POID,ITEMID,QUANTITY,PRODUCTNAME,ORIGINALPRICE,TOTAL) SELECT * FROM POITEMORDERTABLE WHERE POID = " + POID1+";","INSERT INTO ARCPOSHIPTOINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS,REMARKS) SELECT * FROM POSHIPTOINFO WHERE POID = " +POID1+";","INSERT INTO ARCPOVENDORINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS) SELECT * FROM POVENDORINFO WHERE POID = "+POID1+";"};//delete /insert,
            foreach (String i in Queries1)
            {
                scom1.CommandText = i;
                scom1.ExecuteNonQuery();
                Thread.Sleep(250);
            }
            Thread.Sleep(2000);
            //if mawala ung mga nakaraang records nasa table an problemna ung mga references
          scom1.CommandText = "DELETE FROM PURCHASEORDER WHERE POID = " + POID1 + ";";
          scom1.ExecuteNonQuery();//unique constraint failed
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
            ms.Show();
        }
        public void receiveOrder(object sender, EventArgs e)
        {
            MessageBox.Show("ARE YOU SURE YOU WANT OT RECEIVE YOU ORDERS");
            SQLiteCommand scsom1 = new SQLiteCommand("UPDATE PRODUCTS SET ",initd.scon);
          //di pa sure 
            //receive data insert to database
        }
        private void releaseLeaks(object sender,EventArgs e)
        {
            
        }     
        public void CnclPOBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(Cancel, 0, "CANCEL ORDER", "ARE YOU SURE YOU WANT TO CANCEL THIS ORDER?", "OK", 2);
            ms.Show();
        }
        private void reOrder(object sender, EventArgs e)
        {



        }//tempo 
        private void Preview_Click(object sender, EventArgs e)
        {
            //292 and 81
            if (this.Size.Height == 81)
            {
                this.Size = new Size(0,292);  
            }
            else
            {      
                this.Size = new Size(0, 81);
            }
            GC.Collect();
        }
        private void PurchaseOrderComponent_Leave(object sender, EventArgs e)
        {
            pdf.Click += null;
            Print.Click += null;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(DeleteRecords, 0, "DELETE RECORD","ARE YOU SURE YOU WANT TO DELETE THIS RECORD?", "OK", 2);
            ms.Show();
        }
        private void Archive_Click(object sender, EventArgs e)
        {

            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD?\n THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.", "OK", 0);
            ms.Show();
        
        }
    }
}
