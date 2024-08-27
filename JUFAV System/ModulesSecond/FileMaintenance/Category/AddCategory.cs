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
        public AddCategory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        //core
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;

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
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String unitid = "";//Users table

            //retreive make sure it doesnt match any in the db
            //CATEGORY 8
            for (int i = 0; i != 8; i++)
            {
                unitid = string.Concat(unitid, rs1.Next(0, 9).ToString());
            }

            SQLiteCommand scom = new SQLiteCommand("INSERT INTO CATEGORY VALUES (" + Convert.ToInt32(unitid) + "," + initd.UserID + ",'" + Cattxtbox.Text + "');", initd.scon);
            scom.ExecuteNonQuery();
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD UNIT OF MEASUREMENT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
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
