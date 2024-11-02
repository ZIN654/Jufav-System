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
using System.Threading;

namespace JUFAV_System.Components
{
    public partial class CategoryComponent : UserControl
    {
        int id1;
        public CategoryComponent(String text,int id)
        {
            InitializeComponent();
            this.id1 = id;
            this.Dock = DockStyle.Top;
            label1.Text = text;
        }
        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Category.AddCategory sup1 = new ModulesSecond.FileMaintenance.Category.AddCategory(0, id1);
            sup1.Name = "editCategory";
            ResponsiveUI1.title = "editCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void archive()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            String[] query = { "INSERT INTO ARCCATEGORY (CATEGORYID,USERID,CATEGORYDESC) SELECT * FROM CATEGORY WHERE CATEGORYID = " + id1 + ";", "INSERT INTO ARCSUBCATEGORY (SUBCATEGORYID,USERID,CATEGORYID,SUBCATEGORYDESC,MARKUPVALUE) SELECT * FROM SUBCATEGORY WHERE CATEGORYID = " + id1 + ";", "INSERT INTO ARCPRODUCTS (PRODUCTID,USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE) SELECT * FROM PRODUCTS WHERE CATEGORYID = " + id1 + ";" };
            foreach (String i in query)
            {
                scom1.CommandText = i;
                scom1.ExecuteNonQuery();

            }
            Thread.Sleep(2000);
            scom1.CommandText = "DELETE FROM CATEGORY WHERE CATEGORYID = " + id1 + ";";//references bug
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
            ms.Show();
        }
        private void delete()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM CATEGORY WHERE CATEGORYID = "+id1+";",initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK", 0);
            ms.Show();
           
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(delete, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?\n ALL OF ITS RELATIVE DATA WILL BE ALSO DELETED.", "OK", 1);
            ms.Show();
        }
        private void ArchiveCatBtn_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.\n NOTE: ALL OF RECORDS THAT USES THIS CATEGORY WILL BE ARCHIVED AS WELL.", "OK", 2);
            ms.Show();
        }
        private void CategoryComponent_Leave(object sender, EventArgs e)
        {
            pictureBox2.Click += null;
            DeleteBTN.Click += null;
        }    
    }
}
