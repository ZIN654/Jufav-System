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
        private bool isverified4;
        private bool isverfied5;
        private bool isverfied3;
        int idtoedit1;
        int summontype1;
        String texttouse = "";
        public AddSubCategory(int summontype, int idtoedit, String Category)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            summontype1 = summontype;
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
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //load database

            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUBCATEGORY WHERE SUBCATEGORYID = " + idtoedit1 + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                SubCattxtbox.Text = sread1["SUBCATEGORYDESC"].ToString();
                texttouse = sread1["SUBCATEGORYDESC"].ToString();
                markupTxtBx.Text = sread1["MARKUPVALUE"].ToString();

            }
            sread1.Close();


            initd.con1.Close();
        }
        private void update()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            //Update function here 
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE SUBCATEGORY SET SUBCATEGORYDESC = '" + SubCattxtbox.Text.ToLower() + "',CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE CATEGORYDESC = '" + comboBox1.Text + "'),MARKUPVALUE = " + Convert.ToDouble(markupTxtBx.Text) + " WHERE SUBCATEGORYID = " + idtoedit1 + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE CATEGORY", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();


            initd.con1.Close();
        }

        private void onload()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //use dispose
            category.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                category.Add(sq1["CATEGORYDESC"], sq1["CATEGORYID"]);
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());
            }
            sq1.Close();

            //insert into combobox

            initd.con1.Close();
        }
        public bool checkDuplicate()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            //important things when checking for duplicate is : name/
            //search must be selected in all  fields
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUBCATEGORY WHERE SUBCATEGORYDESC LIKE '%" + SubCattxtbox.Text.Normalize().ToLower().Trim() + "%'", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (SubCattxtbox.Text == sread1["SUBCATEGORYDESC"].ToString())
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 1, "SUBCATEGORY NAME", "THE SUBCATEGORY NAME IS ALREADY IN USE IN THIS CATEGORY\n PLEASE USE OTHER NAME.", "OK", 0);
                    msg2.Show();
                    test1 = false;
                    break;
                }
            }
            sread1.Close();
            /*
            if (Regex.IsMatch(Cattxtbox.Text, "@gmail.com") == false)
            {
                MessageBox.Show(this, "Invalid email,Please try again", "Email not Valid", MessageBoxButtons.OK);
                Cattxtbox.Text = "";
            }
            */
            initd.con1.Close();
            return test1;
        }
        public bool checkDuplicate2()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            //important things when checking for duplicate is : name/
            //search must be selected in all  fields

            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUBCATEGORY WHERE SUBCATEGORYDESC != '" + texttouse.Normalize().ToLower().Trim() + "'", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (SubCattxtbox.Text == sread1["SUBCATEGORYDESC"].ToString())
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 1, "SUBCATEGORY NAME", "THE SUBCATEGORY NAME IS ALREADY IN USE IN THIS CATEGORY\n PLEASE USE OTHER NAME.", "OK", 0);
                    msg2.Show();
                    test1 = false;
                    break;
                }
            }
            sread1.Close();
            /*
            if (Regex.IsMatch(Cattxtbox.Text, "@gmail.com") == false)
            {
                MessageBox.Show(this, "Invalid email,Please try again", "Email not Valid", MessageBoxButtons.OK);
                Cattxtbox.Text = "";
            }
            */
            initd.con1.Close();
            return test1;
        }
        //core
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;
            isverfied3 = true;
            Control[] textboxes = { SubCattxtbox, comboBox1, markupTxtBx };
            PictureBox[] notificationimage = { subCatIm, catimg, Markupimg };
            Label[] textnoti = { subCatnot, catnotassignment, markupnot };
            //check pass and conf is =
            if (SubCattxtbox.Text == "" || comboBox1.Text == "" || markupTxtBx.Text == "")
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
                    if (Regex.IsMatch(textboxes[i].Text, @"[^a-zA-Z0-9\s]"))
                    {
                        Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                        ms.Show();
                        isverfied2 = false;
                        break;
                    }


                }
            }
            //
            if (summontype1 != 0)
            {
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { SubCattxtbox.Text.Normalize().ToLower().Trim() }, 3) == false)
                {
                    isverfied3 = false;
                }
            }
            else
            {

                isverfied3 = true;

            }
            //
            if (Regex.IsMatch(markupTxtBx.Text, @"[^0-9]"))
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + markupTxtBx.Name + " field where text '" + markupTxtBx.Text + "' contains the non letter character.", "RETRY", 1);
                ms.Show();
                isverified4 = false;

            }
            else
            {
                isverified4 = true;
            }
            if (summontype1 != 0)
            {
                if (isverfied2 == true && isverfied1 == true && isverfied3 == true && isverified4 == true && checkDuplicate() == false)
                {
                    isverfied5 = false;
                }
                else
                {
                    isverfied5 = true;


                }


            }
            else
            {
                if (isverfied2 == true && isverfied1 == true && isverfied3 == true && isverified4 == true && checkDuplicate2() == false)
                {
                    isverfied5 = false;
                }
                else
                {
                    isverfied5 = true;


                }



            }


            if (isverfied2 == true && isverfied1 == true && isverfied3 == true && isverified4 == true && isverfied5 == true)
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
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
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
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO SUBCATEGORY VALUES (" + Convert.ToInt32(unitid) + "," + initd.UserID + "," + category[comboBox1.Text] + ",'" + SubCattxtbox.Text.Normalize().ToLower().Trim() + "'," + Convert.ToInt32(markupTxtBx.Text) + ");", initd.con1);
            scom.ExecuteNonQuery();

            this.Cursor = Cursors.Default;

            initd.con1.Close();
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
