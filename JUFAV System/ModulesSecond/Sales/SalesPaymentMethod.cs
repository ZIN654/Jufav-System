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

namespace JUFAV_System.ModulesSecond.Sales
{
    public partial class SalesPaymentMethod : UserControl
    {
        TextBox texttouse;
        public SalesPaymentMethod()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            texttouse = Payment;
        }
        private void loaddata()
        {
            //must have a table for sales and if the sale was success fuly piurchased 
            //it will insert to sales table and it will clear the salesqueue


        }
        public void gcash(object sender,EventArgs e) { }
        public void COP(object sender,EventArgs e) { }
        public void COD(object sender,EventArgs e) { }
        private void textBox3_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Deliveryfee;
            //set text box to  edit 
        }
        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Discount;
        }
        private void textBox2_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Payment;
        }
        private void confirmorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("test 2 pressed");
        }
        private void one_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "1";
        }
        private void ttwo_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "2";
        }
        private void threee_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "3";
        }
        private void four_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "4";
        }
        private void five_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "5";
        }
        private void six_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "6";
        }
        private void seven_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "7";
        }
        private void eight_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "8";
        }
        private void nine_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "9";
        }
        private void dot_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + ".";
        }
        private void doublezero_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "00";
        }
        private void zero_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "0";
        }
        private void clear_Click(object sender, EventArgs e)
        {
            texttouse.Clear();
        }
        private void Backsoace_Click(object sender, EventArgs e)
        {
            if (texttouse.Text == "")
            {
                texttouse.Text = 0.ToString();
            }else
            {
                texttouse.Text = texttouse.Text.Remove(texttouse.Text.Length - 1);
            }
          
        }
        private void backtosales_Click(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.SALES.SALES cat1 = new ModulesMain.SALES.SALES();
            ResponsiveUI1.title = "SALES";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }
    }
}
