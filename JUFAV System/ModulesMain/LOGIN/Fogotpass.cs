using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using JUFAV_System.dll;
using System.Data.SQLite;
using System.Collections;
namespace JUFAV_System.ModulesMain.LOGIN
{
    public partial class Fogotpass : UserControl
    {
        Dictionary<String, string> acccounts;
        Dictionary<String, string> acccountEmails;
        String message1;
        String email;
        public Fogotpass(String username)
        {
            InitializeComponent();
         
            this.Dock = DockStyle.Fill;
            acccounts = new Dictionary<String, string>();
            acccountEmails = new Dictionary<String, string>();
            load();
            textBox1.Text = username;
        }
        private void load()
        {
            acccounts.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT USERNAME,EMAIL,PASSWORDS FROM USER_INFO;", initd.scon);
            SQLiteDataReader sread = scom1.ExecuteReader();
            while (sread.Read())
            {
                acccounts.Add(sread["USERNAME"].ToString(), sread["PASSWORDS"].ToString());
                acccountEmails.Add(sread["USERNAME"].ToString(), sread["EMAIL"].ToString());

            }


        }
      
        private void sendemail()
        {
            //email sending test study
            this.Cursor = Cursors.WaitCursor;
            string fromMail = "zr2436901@gmail.com";
            string frompassword = "nsnjjlxpsbcmqltd";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "JUFAV SYSTEM ACCOUNT PASSWORD RECOVERY";
            message.To.Add(new MailAddress(acccountEmails[textBox1.Text]));
            message.Body = message1.ToString();//fetches the database frist
            message.IsBodyHtml = true;

            this.Cursor = Cursors.WaitCursor;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                //another way to setup the properties of a class.librariy
                         
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(fromMail, frompassword),
                EnableSsl = true
                
                

            };
            //sends the message
            smtpClient.Send(message);
            this.Cursor = Cursors.Default;
            //message box that would take the user into the main login panel
            if (MessageBox.Show(this, "Email Has Sent!,Please check your email to see your password.", "Password Recovery", MessageBoxButtons.OK) == DialogResult.OK)
            {
                ResponsiveUI1.spl2.Controls.Find(ResponsiveUI1.title3, false)[0].Dispose();
                ModulesMain.LOGIN.LoginPanel login = new ModulesMain.LOGIN.LoginPanel();//perhaps us the name of the username txtbx
                ResponsiveUI1.title = "LoginPanel";
                ResponsiveUI1.spl2.Controls.Add(login);

            }

        }
        private void verify()
        {
            if (acccounts.ContainsKey(textBox1.Text) == true)
            {
                message1 ="JUFAV SYSTEM ACCOUNT PASSWORD RECOVERY \n Username : " + textBox1.Text + " \n Password : " + acccounts[textBox1.Text];
                sendemail();
            }
            else
            {
                MessageBox.Show(this, "Username Does not exist.", "Password Recovery", MessageBoxButtons.OK);
            }
        }
        private void rcvrbtn_Click(object sender, EventArgs e)
        {
            //check if existing sa database if eexisting then fetch email then send
            verify(); 
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"Are you sure you want to Cancel the password recovery?","Password Recovery",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ResponsiveUI1.spl2.Controls.Find(ResponsiveUI1.title3,true)[0].Dispose();
                ModulesMain.LOGIN.LoginPanel login = new ModulesMain.LOGIN.LoginPanel();//perhaps us the name of the username txtbx
                ResponsiveUI1.title3 = "LoginPanel";
                ResponsiveUI1.spl2.Controls.Add(login);


            }
        }
    }
}
