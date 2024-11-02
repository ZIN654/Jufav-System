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
        private bool isverfied3;
        int idtoedit1;
        int summontype1;
        public AddSubCategory(int summontype,int idtoedit,String Category)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            summontype1=  summontype;
            if (summontype == 0)
            {
                onload();//loads items of the category
                addBTN.Text = "UPDATE SUBCATEGORY";
                idtoedit1 = idtoedit;
                onload2();//loads the current data 
                comboBox1.Text = Category;

            }
            else
            {
                onload();


            }
           
            //verify na numbers lang ang makakapasok sa markup
            //di pwedeng mag typ si user sa combo box
        }
        private void onload2()
        {
            //load database
          
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUBCATEGORY WHERE SUBCATEGORYID = "+idtoedit1+";",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                SubCattxtbox.Text = sread1["SUBCATEGORYDESC"].ToString();
                comboBox2.Text = sread1["MARKUPVALUE"].ToString();

            }




        }
        private void update()
        {
            this.Cursor = Cursors.WaitCursor;
            //Update function here 
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE SUBCATEGORY SET SUBCATEGORYDESC = '" + SubCattxtbox.Text.ToLower() + "',CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE CATEGORYDESC = '"+comboBox1.Text+ "'),MARKUPVALUE = "+Convert.ToDouble(comboBox2.Text)+" WHERE SUBCATEGORYID = " + idtoedit1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE CATEGORY", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();


            
        }

       private void onload()
        {
            //use dispose
            category.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                category.Add(sq1["CATEGORYDESC"], sq1["CATEGORYID"]);
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());
            }
            sq1.Close();
            scom1.CommandText = "SELECT * FROM MARKUP";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                comboBox2.Items.Add(sq1["MARKUPVALUE"].ToString());


            }
            //insert into combobox


        }
        //core
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;
            isverfied3 = true;
            Control[] textboxes = { SubCattxtbox,comboBox1,comboBox2 };
            PictureBox[] notificationimage = { subCatIm,catimg,Markupimg };
            Label[] textnoti = { subCatnot ,catnotassignment,markupnot};
            //check pass and conf is =
            if (SubCattxtbox.Text == "" || comboBox1.Text == ""|| comboBox2.Text == "")
            {
                for (int i = 0; i != 3; i++)
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
            //
            if (summontype1 != 0) { 
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { SubCattxtbox.Text.ToLower() },3) == false)
                {
                    isverfied3 = false;
                }
            }
            else
            {

                isverfied3 = true;

            }
            //
            if (isverfied2 == true && isverfied1 == true && isverfied3 == true)
            {
                //are you sure 
                if (summontype1 == 1)
                {

                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD NEW SUBCATEGORY", "ARE YOU SURE YOU WANT TO ADD THIS NEW SUBCATEGORY?", "ADD", 2);
                    msg1.Show();

                }
                else
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(update, 0, "UPDATE SUBCATEGORY", "ARE YOU SURE YOU WANT TO UPDATE THIS SUBCATEGORY?", "UPDATE", 2);
                    msg1.Show();


                }
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
           //make msg box if user entered a text in markup value
            SQLiteCommand scom = new SQLiteCommand("INSERT INTO SUBCATEGORY VALUES (" + Convert.ToInt32(unitid) + "," + initd.UserID + "," + category[comboBox1.Text] + ",'" + SubCattxtbox.Text.ToLower() + "'," + Convert.ToInt32(comboBox2.Text) + ");", initd.scon);
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
