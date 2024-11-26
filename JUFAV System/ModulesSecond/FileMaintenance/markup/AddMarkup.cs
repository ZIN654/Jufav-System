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
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace JUFAV_System.ModulesSecond.FileMaintenance.markup
{
    public partial class AddMarkup : UserControl
    {
        private bool isverfied1 = true;
        private bool isverfied2 = true;
        int summontype1;
        int idtoedit;
        public AddMarkup(int summontype, int IDtoedit)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            summontype1 = summontype;
            if (summontype == 0)
            {
                idtoedit = IDtoedit;
                addBTN.Text = "UPDATE MARKUP";
                OnLoad1(IDtoedit);

            }
        }
        private void OnLoad1(int id)
        {
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM MARKUP WHERE MARKUPID = " + id + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Markuptxtbx.Text = sread1["MARKUPVALUE"].ToString();

            }
            sread1.Close();
            sread1 = null;
            scom1 = null;



        }
        private void update1()
        {
            this.Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE MARKUP SET MARKUPVALUE =" + Convert.ToDouble(Markuptxtbx.Text) + " WHERE MARKUPID = " + idtoedit + ";", initd.con1);
            scom1.ExecuteNonQuery();
            scom1 = null;

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE CATEGORY", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();


        }
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;


            //check pass and conf is =


            if (Markuptxtbx.Text == "")
            {
                // MessageBox.Show("error please Enter input from textbox text : " + textboxes[i].Name);
                MKimg.Visible = true;
                MKnot.Visible = true;
                isverfied1 = false;

            }
            else
            {

                // \\W\\S
                if (Regex.IsMatch(Markuptxtbx.Text, @"[^0-9]"))
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + Markuptxtbx.Name + " field where text '" + Markuptxtbx.Text + "' contains the non letter character.", "RETRY", 1);
                    ms.Show();
                    isverfied2 = false;

                }



            }
            if (isverfied2 == true && isverfied1 == true)
            {
                //are you sure 
                if (summontype1 == 1)
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD MARK UP", "ARE YOU SURE YOU WANT TO ADD THIS NEW MARKUP?", "ADD", 2);
                    msg1.Show();


                }
                else
                {
                    //must add markup desc
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(update1, 0, "UPDATE MARK UP", "ARE YOU SURE YOU WANT TO UPDATE THIS NEW MARKUP ALL RECORDS THAT USES THIS MARKUP WILL BE UPDATED?", "ADD", 2);
                    msg1.Show();


                }
            }

        }
        private void Insertdata()
        {
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String MarkupID = "";//Users table


            //retreive make sure it doesnt match any in the db
            //CATEGORY 8
            for (int i = 0; i != 6; i++)
            {
                MarkupID = string.Concat(MarkupID, rs1.Next(0, 9).ToString());
            }
            //define kung sinong user ang nag insert 
            //create table 
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO MARKUP VALUES (" + Convert.ToInt32(MarkupID) + "," + initd.UserID + "," + Convert.ToInt32(Markuptxtbx.Text) + ");", initd.con1);
            scom.ExecuteNonQuery();
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD SUB CATEGORY", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.MarkUp unit1 = new ModulesMain.FILEMAINTENANCE.MarkUp();
            ResponsiveUI1.title = "MarkUp";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        private void CANCELBTN_Click(object sender, EventArgs e)
        {
            goback();
        }
        private void addBTN_Click(object sender, EventArgs e)
        {
            MKnot.Visible = false;
            MKimg.Visible = false;
            verify();
        }
    }
}
