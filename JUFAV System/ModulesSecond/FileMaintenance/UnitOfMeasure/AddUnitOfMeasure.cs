using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Text.RegularExpressions;

namespace JUFAV_System.ModulesSecond.FileMaintenance.UnitOfMeasure
{
    public partial class AddUnitOfMeasure : UserControl
    {
        public bool isverfied1 ;
        public bool isverfied2 ;
        public bool isverfied3;
        int idtoedit;
        int summontype1 = 0;
        public AddUnitOfMeasure(int summontype,int IdtoEdit)
        {
            InitializeComponent();
            
            this.Dock = DockStyle.Fill;
            summontype1 = summontype;
            if (summontype == 0)
            {
                //Edit mode
                loaddata(IdtoEdit);
                idtoedit = IdtoEdit;
                addBTN.Text = "UPDATE UNIT";

            }
        }
   
        private void loaddata(int idtoedit)
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM UNITOFMEASURE WHERE UNITID = " + idtoedit + ";", initd.scon);
            SQLiteDataReader srea1 = scom1.ExecuteReader();
            while (srea1.Read())
            {
                UofMtxtbox.Text = srea1["UNITDESC"].ToString();
                Abbreviatiotxtbox.Text = srea1["UNITABBREVIATION"].ToString();
            }
            srea1.Close();
            srea1 = null;
            scom1 = null;



        }
        private void UpdateDB()
        {
            this.Cursor = Cursors.WaitCursor;
            Console.WriteLine("EDIT");
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE UNITOFMEASURE SET UNITDESC = '"+ UofMtxtbox.Text.ToLower() + "',UNITABBREVIATION = '"+ Abbreviatiotxtbox.Text.ToLower() + "' WHERE UNITID = "+idtoedit+";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            //TO DO LATER
            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE UNIT OF MEASURE", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();

        }


        public void verify(int summonmode)
        {
            isverfied1 = true;
            isverfied2 = true;
            isverfied3 = true;
            TextBox[] textboxes = {UofMtxtbox,Abbreviatiotxtbox };
            PictureBox[] notificationimage = { UofM,Abreviation };
            Label[] textnoti = { UnitOfmeaurenot,Abreviationnot };
            //check pass and conf is =
            if ( UofMtxtbox.Text == "" || Abbreviatiotxtbox.Text == "")
            {
                for (int i = 0; i != 2; i++)
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
                for (int i = 0; i != 2; i++)
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
            if(summontype1 != 0) { 
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { UofMtxtbox.Text.ToLower(), Abbreviatiotxtbox.Text.ToLower() }, 4) == false)
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

                if (summontype1 == 1) {


                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD UNIT OF MEASURE", "ARE YOU SURE YOU WANT TO ADD THIS NEW UNIT OF MEASURE?", "ADD", 2);
                    msg1.Show();


                } else
                {

                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(UpdateDB, 0, "UPDATE UNIT OF MEASURE", "ARE YOU SURE YOU WANT TO UPDATE THIS UNIT OF MEASURE?", "UPDATE", 2);
                    msg1.Show();

                }
                
            }

        }
        public void hide()
        {
            PictureBox[] notificationimage = { UofM, Abreviation };
            Label[] textnoti = { UnitOfmeaurenot, Abreviationnot };
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
            //users id digit is only 5
            for (int i = 0; i != 6; i++)
            {
                unitid = string.Concat(unitid, rs1.Next(0, 9).ToString());
            }

            SQLiteCommand scom = new SQLiteCommand("INSERT INTO UNITOFMEASURE VALUES ("+Convert.ToInt32(unitid)+"," + initd.UserID + ",'" + UofMtxtbox.Text.ToLower() + "','" + Abbreviatiotxtbox.Text.ToLower()+"');", initd.scon);
            scom.ExecuteNonQuery();
            
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback,0,"ADD UNIT OF MEASUREMENT","ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?","OK",0);
            msg2.Show();
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            
            hide();
            verify(summontype1);
        }

        private void CANCELBTN_Click(object sender, EventArgs e)
        {
            //relode again
            goback();





        }
       
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.UnitOfMeasures unit1 = new ModulesMain.FILEMAINTENANCE.UnitOfMeasures();
            ResponsiveUI1.title = "UnitOfMeasures";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
    }
}
