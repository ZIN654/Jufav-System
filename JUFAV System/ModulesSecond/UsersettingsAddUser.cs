using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.ModulesSecond
{
    public partial class UsersettingsAddUser : UserControl
    {
        public UsersettingsAddUser()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            onload();
        }
        public void onload()
        {
           
            ModulesSecond.Userssetaddditems.FileMaintenenance item1 = new Userssetaddditems.FileMaintenenance();
            ModulesSecond.Userssetaddditems.Inventory item2 = new Userssetaddditems.Inventory();
            ItemsBox.Controls.Add(item2);
            ItemsBox.Controls.Add(item1);


        }
    }
}
