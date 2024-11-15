using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.Messageboxes
{
    public partial class ShowChanges : Form
    {
        Action toexe1;
        public ShowChanges(double changes,Action toexe)
        {
            InitializeComponent();
            label2.Text = changes.ToString();
            toexe1 = toexe;
        }

        private void CONFRIMBTN_Click(object sender, EventArgs e)
        {
            toexe1();
            this.Dispose();
        }
    }
}
