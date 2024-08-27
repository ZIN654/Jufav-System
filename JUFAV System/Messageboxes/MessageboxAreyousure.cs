using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.Properties;

namespace JUFAV_System.Messageboxes
{
    public partial class MessageboxConfirmation : Form
    {
        private static Action toexe;
        
        public MessageboxConfirmation(Action toexecute,int msgboxeventtype,String title,String msg,String BTNconfirmTitle,int icontype)
        {
            InitializeComponent();
            toexe = toexecute;
            setmsgboxtype(msgboxeventtype,BTNconfirmTitle,title,msg);
            seticon(icontype);
            addevents(msgboxeventtype);
            
        }


        public void addevents(int type)
        {
            switch (type)
            {
                case 0://for 2 buttons such as 2 buttons\1 buttons
                    btnconfirm.Click += btnconfirm_Click;
                    btnclose.Click += btnclose_Click;
                    break;
                case 1:
                    btnclose.Click += btnclose_Click;
                    break;
            }
           
        }
        public void setmsgboxtype(int type,String btntext,String title,String msg)
        {
            switch (type)
            {
                case 0://no hide just set items 2 btn
                    lblmsg.Text = msg;
                    lbltitle.Text = title;
                    btnconfirm.Text = btntext;

                    break;
                case 1://hide btn   
                    lblmsg.Text = msg;
                    lbltitle.Text = title;
                    btnconfirm.Visible = false;
                    btnconfirm.Text = btntext;
                    break;
            }
        }
        public void seticon(int type)
        {
            switch (type) {
                case 0://check
                    icon.Image = JUFAV_System.Properties.Resources.chkbox;

                    break;
                case 1://garbage
                    icon.Image = JUFAV_System.Properties.Resources.dlt;
                    break;
                case 2://error
                    icon.Image = JUFAV_System.Properties.Resources.error;
                    break;
            }
            
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            toexe();
            realease();
            this.Hide();
            this.Dispose();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            realease();
            this.Hide();
            this.Dispose();
        }
        public void realease()
        {

            btnconfirm.Click -= btnconfirm_Click;
            btnclose.Click -= btnclose_Click;

        }

      
    }
}
