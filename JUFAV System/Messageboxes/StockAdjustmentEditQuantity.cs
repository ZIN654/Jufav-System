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
namespace JUFAV_System.Messageboxes
{
    public partial class StockAdjustmentEditQuantity : Form
    {
      
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
            /*
             * updates the database but also insert a new item in StockAdjustmentTable
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PRODUCTS SET  ",initd.scon);
            scom1.ExecuteNonQuery();
            */
            this.Cursor = Cursors.Default;
           
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(CloseForm, 0, "ADJUST STOCK", "ADJUSTMENTS SUCCESSFULLY APPLIED! \n WOOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
         
            ms.Show();

           //but when just pressed close this form will auto  close
            //go back at the Stock adjustment module and insrt the newly created adjustments

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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
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
    }
}
