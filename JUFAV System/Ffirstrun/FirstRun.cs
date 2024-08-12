using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.Ffirstrun
{
    public partial class FirstRun : Form
    {
        //just pass the value from herre to next form to hold the info then if the  databas is created insert it into the database
        //then if the settup is complete change into the log in partt
        public FirstRun()
        {
            InitializeComponent();
            addevent();
        }
        public void addevent()
        {
            AddBTN.Click += (sender,e) => { addaccounts(); };
            clearBTN.Click += (sender, e) => { clear(); };
            doneBTN.Click += (sender, e) => { Done(); };

        }



        public void clear()
        {
            txtbxName.Text = "";
            txtbxConPas.Text = "";
            txtbxUsername.Text = "";
            txtbxPass.Text = "";
        }
        public void addaccounts()
        {
            //check pass and conf is =
            if(txtbxPass.Text =="" || txtbxUsername.Text == "" || txtbxName.Text == "" || txtbxConPas.Text == "")
            { MessageBox.Show("error please input"); }
           
            if (txtbxPass.Text == txtbxConPas.Text)
            {
                //last to check
            }
            else
            {
                //MessageBox.Show("Please reconfirm your password ");



            }






        }
        public void Done()
        {
          
        }
    }
}
