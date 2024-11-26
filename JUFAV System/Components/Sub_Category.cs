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
    public partial class Sub_Category : UserControl
    {
        int Idtoedit1 = 0;
        String categoryname;
        public Sub_Category(String Subcatname, object Catname, String markup, int idtoedit)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            Idtoedit1 = idtoedit;
            categoryname = Catname.ToString();
            label5.Text = Subcatname;
            label6.Text = Catname.ToString();
            label7.Text = markup;

        }
        private void CallEdit(int summontype)
        {
            //revise paano kung same yung name
            //how do we fetch the data if it has a same name ?
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.SubCategory.AddSubCategory sup1 = new ModulesSecond.FileMaintenance.SubCategory.AddSubCategory(summontype, Idtoedit1, categoryname);
            sup1.Name = "editSubCategory";
            ResponsiveUI1.title = "editSubCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void archive()
        {
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);

            //array ng query
            //unahin mo munang insert ung tatlong column tas ung PO na madaming column
            String[] query = { "INSERT INTO ARCSUBCATEGORY (SUBCATEGORYID,USERID,CATEGORYID,SUBCATEGORYDESC,MARKUPVALUE) SELECT * FROM SUBCATEGORY WHERE SUBCATEGORYID = " + Idtoedit1 + ";"
       , "INSERT INTO ARCPRODUCTS (PRODUCTID,USERID,CATEGORYID,SUBCATEGORYID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY) SELECT PRODUCTID,USERID,CATEGORYID,SUBCATEGORYID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY FROM PRODUCTS WHERE SUBCATEGORYID = " + Idtoedit1+";"};

            //execute nya yunh bawat laman nung string query
            foreach (String i in query)
            {
                scom1.CommandText = i;
                scom1.ExecuteNonQuery();

            }

            Thread.Sleep(2000);
            scom1.CommandText = "DELETE FROM SUBCATEGORY WHERE SUBCATEGORYID = " + Idtoedit1 + ";";//bug because of references
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
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM SUBCATEGORY WHERE SUBCATEGORYID = " + Idtoedit1 + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK", 0);
            ms.Show();

        }
        private void editBTN_Click(object sender, EventArgs e)
        {
            CallEdit(0);
        }
        private void TrashBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(delete, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?\n NOTE: ALL OF RECORDS THAT USES THIS SUBCATEGORY WILL BE ARCHIVED AS WELL.", "OK", 1);
            ms.Show();
        }
        private void Archive_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?. \n NOTE: ALL OF RECORDS THAT USES THIS SUBCATEGORY WILL BE ARCHIVED AS WELL.", "OK", 2);
            ms.Show();
        }
        private void Sub_Category_Leave(object sender, EventArgs e)
        {
            editbtn.Click += null;
            trashbtn.Click += null;
        }
    }
}
