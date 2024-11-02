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
using System.Text.RegularExpressions;
using JUFAV_System.dll;

namespace JUFAV_System.ModulesSecond.FileMaintenance.Supplier
{
    public partial class Addsupplier : UserControl
    {
        int summonmode = 0;
        int idtoedit1;
        public Addsupplier(int summontype,int idtoedit)
        {
            InitializeComponent();
            summonmode = summontype;
            this.Dock = DockStyle.Fill;
            if (summontype == 0)
            {
                //Edit mode
                loaddata(idtoedit);
                idtoedit1 = idtoedit;
                AddSupplierBTn.Text = "UPDATE SUPPLIER";

            }
          
        }
        public bool isverfied1 = true;
        public bool isverfied2 = true;
        public bool isverified3 = true;
        //core
        private void loaddata(int id)
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERID = " + id + ";", initd.scon);
            SQLiteDataReader srea1 = scom1.ExecuteReader();
            while (srea1.Read())
            {
                ComapnynametxtBX.Text = srea1["SUPPLIERNAME"].ToString();
                ContactPersontxtbox.Text = srea1["CONTACTPERSON"].ToString();
                ContactNotxtbox.Text = srea1["CONTACTNUMBER"].ToString();
                Addresstxtbox.Text = srea1["COMPANYADDRESS"].ToString();
            }
            srea1.Close();
            srea1 = null;
            scom1 = null;


        }
        private void UpdateDb()
        {
            this.Cursor = Cursors.WaitCursor;
            //SQLIETE using idtoedit  (SUPPLIERID INT NOT NULL PRIMARY KEY,USERID INT,SUPPLIERNAME VARCHAR(50),CONTACTPERSON VARCHAR(50),CONTACTNUMBER VARCHAR(50),COMPANYADDRESS VARCHAR(100)
            SQLiteCommand sq1 = new SQLiteCommand("UPDATE SUPPLIERS SET SUPPLIERNAME = '"+ ComapnynametxtBX.Text.ToLower() + "',CONTACTPERSON= '"+ ContactPersontxtbox.Text.ToLower() + "',CONTACTNUMBER = '"+ ContactNotxtbox.Text.ToLower() + "' ,COMPANYADDRESS = '"+Addresstxtbox.Text.ToLower() + "' WHERE SUPPLIERID = "+idtoedit1+";", initd.scon);
            sq1.ExecuteNonQuery();
            sq1 = null;

            this.Cursor = Cursors.Default;

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "UPDATE SUPPLIER", "ITEM SUCCESSFULLY UPDATED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();

        }
        public void verify(int summonmode)
        {
            isverfied1 = true;
            isverfied2 = true;
            isverified3 = true;
            TextBox[] textboxes = {ComapnynametxtBX,ContactPersontxtbox,ContactNotxtbox,Addresstxtbox};
            PictureBox[] notificationimage = { CompanynameIMG,ContactPersonIMG,ContactNoIMG,addressIMG };
            Label[] textnoti = {CmpanynameNot,Contactpernot,COntactNoNot,AddressNot };
            //check pass and conf is =
            if (ComapnynametxtBX.Text == ""|| ContactPersontxtbox.Text == ""||ContactNotxtbox.Text == "" || Addresstxtbox.Text == "")
            {
                for (int i = 0; i != 4; i++)
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
            if (summonmode != 0) {//ad for updating bug
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { ComapnynametxtBX.Text.ToLower(), ContactPersontxtbox.Text.ToLower(), ContactNotxtbox.Text.ToLower(), Addresstxtbox.Text.ToLower() }, 0) == false)
                {
                    isverified3 = false;
                }
            }
            else
            {

                isverified3 = true;

            }
            ///
            if (isverfied2 == true && isverfied1 == true && isverified3 == true)
            {
                //are you sure 
                if (summonmode == 1)
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(Insertdata, 0, "ADD NEW SUPPLIER", "ARE YOU SURE YOU WANT TO ADD THIS NEW SUPPLIER?", "ADD", 2);
                    msg1.Show();



                }
                else
                {
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(UpdateDb, 0, "UPDATE SUPPLIER", "ARE YOU SURE YOU WANT TO UPDATE THIS NEW SUPPLIER?", "UPDATE", 2);
                    msg1.Show();




                }
              
            }

        }
        public void hide()
        {
            PictureBox[] notificationimage = { CompanynameIMG, ContactPersonIMG, ContactNoIMG, addressIMG };
            Label[] textnoti = { CmpanynameNot, Contactpernot, COntactNoNot, AddressNot };
            for (int i = 0; i != 4; i++)
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
            for (int i = 0; i != 4; i++)
            {
                unitid = string.Concat(unitid, rs1.Next(0, 9).ToString());
            }

           SQLiteCommand scom = new SQLiteCommand("INSERT INTO SUPPLIERS VALUES(" + Convert.ToInt32(unitid) + "," + initd.UserID + ",'" +ComapnynametxtBX.Text.ToLower() + "','"+ ContactPersontxtbox.Text.ToLower() + "','" + ContactNotxtbox.Text.ToLower() + "','" + Addresstxtbox.Text.ToLower() + "');", initd.scon);
           scom.ExecuteNonQuery();
           
            this.Cursor = Cursors.Default;


            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "ADD UNIT OF MEASUREMENT", "ITEM SUCCESSFULLY ADDED! \n WOULD YOU LIKE TO GO BACK AT THE FRONT PAGE?", "OK", 0);
            msg2.Show();
        }
        private void goback()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Supplier unit1 = new ModulesMain.FILEMAINTENANCE.Supplier();
            ResponsiveUI1.title = "Supplier";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }

        private void AddSupplierBTn_Click(object sender, EventArgs e)
        {
            hide();
            verify(summonmode); 
        }

        private void CanceleSupplierBTN_Click(object sender, EventArgs e)
        {
            goback();
        }
    }
}
