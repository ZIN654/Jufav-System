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
using JUFAV_System.dll;
using System.Text.RegularExpressions;

namespace JUFAV_System.Messageboxes
{
    public partial class StockAdjustmentEditQuantity : Form
    {
        int adjustments = 0;
        int ProductID1 = 0;//to use when Updating // to place later :
        public StockAdjustmentEditQuantity(String Name, double quantity, String Category, String SubCategory,bool isperishable,String UoM, int ProductID)
        {
            InitializeComponent();
           
            ProductID1 = ProductID;
            prodName.Text = Name;
            label9.Text = UoM;
            ProdCat.Text = Category;
            ProdSubCat.Text = SubCategory;
            CurrentVallbl.Text = quantity.ToString();
            UpdateQuantity.Text = adjustments.ToString();
            if (isperishable == false)
            {
                EXPIRED.Enabled = false;
            }
            else
            {
                EXPIRED.Enabled = true;
            }
           
        }
        private void UpdateDatabaseInsertAdjustments()
        {
            this.Cursor = Cursors.WaitCursor;
            
             // updates the database but also insert a new item in StockAdjustmentTable
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PRODUCTS SET QUANTITY = "+Convert.ToDouble(UpdateQuantity.Text)+"  WHERE PRODUCTID = "+ProductID1+";",initd.scon);
            scom1.ExecuteNonQuery();

            //STOCKADJUSTMENTID,USERID,DATEOFADJUSTMENT,PRODUCTID,PRODUCTNAME,ADJUSTMENTTYPE,PREVIOUSQUANTITY,ADJUSTEDQUANTITY,REASON 
            //STOCKADJUSTMENTID,USERS,DATEOFADJUSTMENT,PRODUCTID,PRODUCTNAME,ADJUSTMENTTYPE,PREVIOUSQUANTITY,ADJUSTEDQUANTITY,REASON
            //error here insertion of adjustments
            scom1.CommandText = "INSERT INTO STOCKADJUSTMENTS VALUES("+generateID()+","+initd.UserID+",'"+DateTime.Now.ToShortDateString()+"',"+ProductID1+",'"+prodName.Text+"','"+ determinetypeofAdjustment(determineadjustment(Convert.ToInt32(CurrentVallbl.Text), Convert.ToInt32(UpdateQuantity.Text))) +"',"+ Convert.ToInt32(CurrentVallbl.Text) +","+ (Convert.ToInt32(UpdateQuantity.Text) - Convert.ToInt32(CurrentVallbl.Text)) + ",'"+ DetermineReason().ToString() +"','"+Remarks.Text+"');";
            scom1.ExecuteNonQuery();



            this.Cursor = Cursors.Default; 
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(CloseForm, 0, "ADJUST STOCK", "ADJUSTMENTS SUCCESSFULLY APPLIED! \n WOOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);    
            ms.Show();
            //but when just pressed close this form will auto  close
            //go back at the Stock adjustment module and insrt the newly created adjustments

        }
        private String DetermineReason()
        {
            String reasons = "";
            CheckBox[] Reasons = {DEFECT,EXPIRED,MISPLACED,RtrnBCust,OTHERS};
            foreach (CheckBox I in Reasons)
            {
                if (I.Checked == true)
                {
                    reasons = reasons + I.Text + ", ";
                }
            }
            return reasons;
        }
        private String determinetypeofAdjustment(int adjtype)
        {
            String adjustment = "DECREMENT";
            if (adjtype == 0)
            {
                adjustment = "INCREMENT";

            }
            return adjustment;
        }
        private int determineadjustment(float oldvalue,float newvalue)
        {
            //determine what kind of adjustment user made in the quantity of the
            int adjtype = 0;
            if (oldvalue > newvalue)
            {
                adjtype = 1;
            }
            return adjtype;
        }
        private int generateID()
        {
            String IDStck = "";
            Random rs1 = new Random();
            for (int i = 0; i != 8;i++)
            {
                IDStck = IDStck +  rs1.Next(0,10).ToString();
            }
            Console.WriteLine(IDStck);
            return Convert.ToInt32(IDStck);
        }
        private void CloseForm()
        {
           
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.INVENTORY.StockAdjustment unit1 = new ModulesMain.INVENTORY.StockAdjustment();
            ResponsiveUI1.title = "StockAdjustment";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);
            this.Close();


        }
        private void verifier()
        {
            //verify inputs first
            if (Regex.IsMatch(UpdateQuantity.Text, @"^\d+$") == false)
            {
                UpdateQuantity.Text = 0.ToString();
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "INVALID INPUT", "INVALID INPUT DUE TO A NON NUMERIC CHARACTER", "OK", 2);
                ms.Show();
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(DetermineReason());
            //verifyier first
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(UpdateDatabaseInsertAdjustments, 0, "ADJUST STOCK", "ARE YOU SURE YOU WANT TO APPLY THIS ADJUSTMENT?", "OK", 2);
            ms.Show();
        }
        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
        private void StockAdjustmentEditQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
         
        }
        private void Increment_Click(object sender, EventArgs e)
        {
            adjustments++;
            UpdateQuantity.Text = adjustments.ToString();
        }
        private void Decrement_Click(object sender, EventArgs e)
        {
            adjustments--;
            UpdateQuantity.Text = adjustments.ToString();
        }
        private void UpdateQuantity_TextChanged(object sender, EventArgs e)
        {
            verifier();   
        }
    }
}
