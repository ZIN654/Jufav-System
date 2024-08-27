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
using System.Text.RegularExpressions;
using System.Collections;


namespace JUFAV_System.ModulesSecond.FileMaintenance.SubCategory
{
    public partial class AddSubCategory : UserControl
    {
        private static Hashtable category = new Hashtable();
        private bool isverfied1;
        private bool isverfied2;
        public AddSubCategory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            onload();
            //verify na numbers lang ang makakapasok sa markup
            //di pwedeng mag typ si user sa combo box
        }


       private void onload()
        {
            category.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                category.Add(sq1["CATEGORYDESC"], sq1["CATEGORYID"]);
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());
            }
            sq1.Close();
            //insert into combobox
            

        }
        //core
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;

            TextBox[] textboxes = { SubCattxtbox };
            PictureBox[] notificationimage = { subCatIm,catimg,Markupimg };
            Label[] textnoti = { subCatnot ,catnotassignment,markupnot};
            //check pass and conf is =
            if (SubCattxtbox.Text == "")
            {
                for (int i = 0; i != 1; i++)
                {
                    if (textboxes[i].Text == "")
                    {
                        // MessageBox.Show("error please Enter input from textbox text : " + textboxes[i].Name);
                        notificationimage[i].Visible = true;
                        textnoti[i].Visible = true;
                        isverfied1 = false;
                        break;
                    }


                }


            }
            else
            {
                for (int i = 0; i != 1; i++)
                {
                    // \\W\\S
                    if (Regex.IsMatch(textboxes[i].Text, "\\W"))
                    {
                        Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                        ms.Show();
                        isverfied2 = false;
                        break;
                    }


                }
            }
            if (isverfied2 == true && isverfied1 == true)
            {
                //are you sure 
                Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD UNIT OF MEASURE", "ARE YOU SURE YOU WANT TO ADD THIS NEW UNIT OF MEASURE?", "ADD", 2);
                msg1.Show();
            }

        }
        public void hide()
        {
            PictureBox[] notificationimage = { subCatIm, catimg, Markupimg };
            Label[] textnoti = { subCatnot, catnotassignment, markupnot };
            for (int i = 0; i != 2; i++)
            {


                notificationimage[i].Visible = false;
                textnoti[i].Visible = false;



            }

        }
        private void Insertdata()
        {
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String unitid = "";//Users table
          

            //retreive make sure it doesnt match any in the db
            //CATEGORY 8
            for (int i = 0; i != 9; i++)
            {
                unitid = string.Concat(unitid, rs1.Next(0, 9).ToString());
            }
           
            SQLiteCommand scom = new SQLiteCommand("INSERT INTO SUBCATEGORY VALUES (" + Convert.ToInt32(unitid) + "," + initd.UserID + "," + category[comboBox1.Text] + ",'" + SubCattxtbox.Text + "'," + Convert.ToInt32(comboBox2.Text) + ");", initd.scon);
            scom.ExecuteNonQuery();
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD SUB CATEGORY", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Sub_category unit1 = new ModulesMain.FILEMAINTENANCE.Sub_category();
            ResponsiveUI1.title = "Sub_category";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            hide();
            verify();
        }

        private void CANCELBTN_Click(object sender, EventArgs e)
        {
            goback();
        }
        //core
    }
}
