using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using JUFAV_System.dll;
using System.Data.SQLite;

namespace JUFAV_System.ModulesSecond.FileMaintenance.Category
{
    public partial class AddCategory : UserControl
    {
        public bool isverfied1 = true;
        public bool isverfied2 = true;
        public bool isverfied3 = true;
        public bool isverfied4 = true;
        int summontype1;
        int idtoedit1;
        String textouse = "";

        public AddCategory(int summontype,int idtoedit)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            summontype1 = summontype;
            if (summontype == 0)
            {
                idtoedit1 = idtoedit;
                loaddata(idtoedit);
                addBTN.Text = "UPDATE CATEGORY";
               


            }
        }
        private void loaddata(int id)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CATEGORY WHERE CATEGORYID = "+id+";",initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Cattxtbox.Text = sread1["CATEGORYDESC"].ToString();
                textouse = sread1["CATEGORYDESC"].ToString();
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            initd.con1.Close();

        }
        public bool checkDuplicate()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            //important things when checking for duplicate is : name/
            //search must be selected in all  fields
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CATEGORY WHERE CATEGORYDESC LIKE '%" + Cattxtbox.Text.Normalize().ToLower().Trim() + "%'", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (Cattxtbox.Text == sread1["CATEGORYDESC"].ToString())
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 1, "CATEGORY NAME", "THE CATEGORY NAME IS ALREADY IN USE \n PLEASE USE OTHER NAME.", "OK", 0);
                    msg2.Show();
                    test1 = false;
                    break;
                }
            }
            /*
            if (Regex.IsMatch(Cattxtbox.Text, "@gmail.com") == false)
            {
                MessageBox.Show(this, "Invalid email,Please try again", "Email not Valid", MessageBoxButtons.OK);
                Cattxtbox.Text = "";
            }
            */
            sread1.Close();
            initd.con1.Close();
            return test1;
        }
        public bool checkDuplicate2()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            //important things when checking for duplicate is : name/
            //search must be selected in all  fields
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CATEGORY WHERE CATEGORYDESC != '" + textouse.Normalize().ToLower().Trim() + "'", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                if (Cattxtbox.Text == sread1["CATEGORYDESC"].ToString())
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 1, "CATEGORY NAME", "THE CATEGORY NAME IS ALREADY IN USE \n PLEASE USE OTHER NAME.", "OK", 0);
                    msg2.Show();
                    test1 = false;
                    break;
                }
            }
            /*
            if (Regex.IsMatch(Cattxtbox.Text, "@gmail.com") == false)
            {
                MessageBox.Show(this, "Invalid email,Please try again", "Email not Valid", MessageBoxButtons.OK);
                Cattxtbox.Text = "";
            }
            */
            sread1.Close();
            initd.con1.Close();
            return test1;

        }
        private void update()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE CATEGORY SET CATEGORYDESC = '" +Cattxtbox.Text.Normalize().ToLower().Trim() +"' WHERE CATEGORYID = " + idtoedit1 + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE CATEGORY", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
            initd.con1.Close();
        }


        //core
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;
            isverfied3 = true;
            TextBox[] textboxes = { Cattxtbox };
            PictureBox[] notificationimage = { CatIm };
            Label[] textnoti = { Catnot };
            //check pass and conf is =
            if (Cattxtbox.Text == "" )
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
                    if (Regex.IsMatch(textboxes[i].Text,@"[^\w\s\d]"))//regex patter  to accept a whitespace 
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
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { Cattxtbox.Text.Normalize().ToLower().Trim()}, 2) == false)
                {
                    isverfied3 = false;
                }
            }
            else
            {

                isverfied3 = true;

            }
            //if yupdate changes here 
            if (summontype1 != 0) {
                if (isverfied2 == true && isverfied1 == true && isverfied3 == true && checkDuplicate() == false)
                {
                    isverfied4 = false;


                } else
                {
                    isverfied4 = true;

                }
            }
            else
            {
                if (isverfied2 == true && isverfied1 == true && isverfied3 == true && checkDuplicate2() == false)
                {
                    isverfied4 = false;


                }
                else
                {
                    isverfied4 = true;

                }
            }






        
            if (isverfied2 == true && isverfied1 == true && isverfied3 == true && isverfied4== true)
            {
                //are you sure 
                if (summontype1 == 1)
                {

                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD CATEGORY", "ARE YOU SURE YOU WANT TO ADD THIS NEW CATEGORY?", "ADD", 2);
                    msg1.Show();


                }
                else
                {


                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(update, 0, "UPDATE CATEGORY", "ARE YOU SURE YOU WANT TO  UPDATE THIS CATEGORY?", "UPDATE", 2);
                    msg1.Show();


                }
               
            }

        }
        public void hide()
        {
            PictureBox[] notificationimage = { CatIm };
            Label[] textnoti = { Catnot };
            for (int i = 0; i != 1; i++)
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
            for (int i = 0; i != 8; i++)
            {
                unitid = string.Concat(unitid, rs1.Next(0, 9).ToString());
            }

            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO CATEGORY VALUES (" + Convert.ToInt32(unitid) + "," + initd.UserID + ",'" + Cattxtbox.Text.Normalize().ToLower().Trim() + "');", initd.con1);
            scom.ExecuteNonQuery();
           
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD UNIT OF MEASUREMENT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
            initd.con1.Close();
        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Category unit1 = new ModulesMain.FILEMAINTENANCE.Category();
            ResponsiveUI1.title = "Category";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
      
        //core



        private void addBTN_Click(object sender, EventArgs e)
        {
         
            hide();
            verify();
            
        }

        private void CANCELBTN_Click(object sender, EventArgs e)
        {
            goback();
        }
    }
}
