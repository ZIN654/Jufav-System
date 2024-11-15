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

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class Supplier : UserControl
    {
        public Supplier()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevents();
            LoadData();
        }
        public void addevents()
        {
            this.Leave += Onleave;
            addSupplierBTN.Click += AddSupBtn;
        }
        private void Onleave(object sender,EventArgs e)
        {
            Console.WriteLine("THIS CONTROLL IS REMOVED");
        }
        private void AddSupBtn(object sender,EventArgs e)
        {
           
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Supplier.Addsupplier supadd1 = new ModulesSecond.FileMaintenance.Supplier.Addsupplier(1,0);
            ResponsiveUI1.title = "AddSupplier";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(supadd1);

        }
        private void LoadData()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS;",initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Components.SUPDatabox item1 = new Components.SUPDatabox(sq1["SUPPLIERNAME"].ToString(),sq1["CONTACTPERSON"].ToString(),sq1["CONTACTNUMBER"].ToString(),sq1["COMPANYADDRESS"].ToString(),Convert.ToInt32(sq1["SUPPLIERID"]));
               
                ItemsBox.Controls.Add(item1);

            }
        }
        private void LoadDataFilter(String Filtertouse)
        {

            foreach (UserControl ctrl in ItemsBox.Controls)
            {
                ctrl.Dispose();
            }

            ItemsBox.Controls.Clear();//may natitirang isang container why?

            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS WHERE SUPPLIERNAME LIKE '%"+Filtertouse+ "%' OR COMPANYADDRESS LIKE '%"+Filtertouse+ "%' OR CONTACTPERSON LIKE '%"+Filtertouse+"%' ;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Components.SUPDatabox item1 = new Components.SUPDatabox(sq1["SUPPLIERNAME"].ToString(), sq1["CONTACTPERSON"].ToString(), sq1["CONTACTNUMBER"].ToString(), sq1["COMPANYADDRESS"].ToString(), Convert.ToInt32(sq1["SUPPLIERID"]));
              
                ItemsBox.Controls.Add(item1);

            }
        }

        public void realeaseLeak()
        {
           
            ItemsBox.Dispose();

        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            LoadDataFilter(txtboxSearchBox.Text);
        }

        private void Supplier_Leave(object sender, EventArgs e)
        {
            //each time user closes the panel this will emmit to release memory leaks
            Console.WriteLine("THIS CONTROLL IS REMOVED");
            realeaseLeak();
        }

        private void txtboxSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtboxSearchBox.Text = "";
        }
    }
}
