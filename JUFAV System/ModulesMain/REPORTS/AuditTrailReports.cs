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

namespace JUFAV_System.ModulesMain.REPORTS
{
    public partial class AuditTrailReports : UserControl
    {
        public AuditTrailReports()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loadData();
        }
        private void loadData()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT a.*,u.ROLES FROM AUDITTRAIL a,USER_INFO u WHERE a.USERID = u.USERIDS ORDER BY TIMEIN1 ASC;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.AuditTrailComponent as1 = new Components.AuditTrailComponent(Convert.ToInt32(sread1["AUDITID"].ToString()), Convert.ToInt32(sread1["USERID"].ToString()), sread1["USERNAME"].ToString(), DetermineRole(Convert.ToInt32(sread1["ROLES"])), sread1["LOGGEDINDATE"].ToString(),sread1["TIMEIN1"].ToString(), sread1["TOTALACTIONS"].ToString(),sread1["TIMEIN1"].ToString(), sread1["TIMEOUT1"].ToString());
                ItemsBox.Controls.Add(as1);

            }
            initd.con1.Close();
        }
        private String DetermineRole(int roleno)
        {
            String role = "";
            switch (roleno){
                case 1:
                    role = "ADMINISTRATOR";
                    break;
                case 2:
                    role = "SALES CLERK";
                    break;
                case 3:
                    role = "INVENTORY CLERK";
                    break;

            }

            return role;

        }
    }
}
