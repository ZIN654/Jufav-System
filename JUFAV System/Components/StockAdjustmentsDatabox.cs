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
using System.Text.RegularExpressions;
using System.Threading;
using JUFAV_System.dll;
namespace JUFAV_System.Components
{
    public partial class StockAdjustmentsDatabox : UserControl
    {
        String Remarks1 = "";
        int stckID1;
        public StockAdjustmentsDatabox(String Date, String Prodname,String  Adjustmenttype,int previousquantity,int Adjustedquantity,String Reason,String Remarks,int stckID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            stckID1 = stckID;
            label1.Text = Date;
            label2.Text = Prodname;
            label3.Text = Adjustmenttype;
            label4.Text = previousquantity.ToString();
            label5.Text = Adjustedquantity.ToString();
            label6.Text = Reason;
            Remarks1 = Remarks;
            if (Remarks == "")
            {
                viewRemarks.Visible = false;
            }
        }

        private void viewRemarks_Click(object sender, EventArgs e)
        {  
                Components.RemarksBox rm1 = new RemarksBox(Remarks1);
                this.Parent.Controls.Add(rm1);
                rm1.BringToFront();
                rm1.Location = new Point(viewRemarks.Location.X - 150,this.Location.Y);
        }
        private void archive()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO ARCSTOCKADJUSTMENTS (USERID,DATEOFADJUSTMENT,PRODUCTID,PRODUCTNAME,ADJUSTMENTTYPE,PREVIOUSQUANTITY,ADJUSTEDQUANTITY,REASON,OTHERS) SELECT USERID,DATEOFADJUSTMENT,PRODUCTID,PRODUCTNAME,ADJUSTMENTTYPE,PREVIOUSQUANTITY,ADJUSTEDQUANTITY,REASON,OTHERS FROM STOCKADJUSTMENTS WHERE STOCKADJUSTMENTID = " + stckID1+";", initd.scon);
            scom1.ExecuteNonQuery();
            Thread.Sleep(2000);
            
            scom1.CommandText = "DELETE FROM STOCKADJUSTMENTS WHERE STOCKADJUSTMENTID = " + stckID1 + ";";
            scom1.ExecuteNonQuery();//unique constraint failed
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
            ms.Show();
        }
        private void DeleteRecords()
        {
            this.Cursor = Cursors.WaitCursor;//only available sa cencel
            SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM STOCKADJUSTMENTS WHERE STOCKADJUSTMENTID =  " + stckID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK",0);
            ms.Show();
        }
        private void trash_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(DeleteRecords, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?", "OK", 1);
            ms.Show();
        }
        private void archbtn_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD?\n THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.", "OK", 2);
            ms.Show();
        }
    }
}
