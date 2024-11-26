using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace JUFAV_System.Messageboxes
{
    public partial class GCASHREF : Form
    {
        Label toset;
        int textcountindexspace = 0;
        public GCASHREF(Label toset1)
        {
            InitializeComponent();
            toset = toset1;
        }
        private void verify()
        {
            if (Regex.IsMatch(refnum.Text,@"[^\d\-]"))
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "GCASH REF NUMBER", "INVALID NUMBER INPUT", "YES", 2);
                msg2.Show();
            }
            else
            {

                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(back, 0, "GCASH REF NUMBER", "ARE YOU SURE YOU INPUTTED THE RIGHT NUMBERS?", "YES", 2);
                msg2.Show();

            }


        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            verify();
        }
        private void back()
        {
            toset.Text = refnum.Text;
            this.Dispose();
        }
        private void refnum_TextChanged(object sender, EventArgs e)
        {   
            if (refnum.Text.Length == 4 || refnum.Text.Length == 9)
            {
                refnum.Text = refnum.Text + "-";
                refnum.SelectionStart = refnum.Text.Length;
                refnum.SelectionLength = refnum.Text.Length;
                refnum.Focus();
            }
        }

        private void refnum_Click(object sender, EventArgs e)
        {
            refnum.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
