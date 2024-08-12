using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JUFAV_System.ModulesMain.UTILITIES
{
    public partial class BCKRS : UserControl
    {
        public BCKRS()
        {
            InitializeComponent();
            addevents();
            this.Dock = DockStyle.Fill;

            Pane.Dock = DockStyle.Fill;

            /*
            //passensya na ma kung ganun ako. masyado lang ako di ko
            kung ganun ang naging trato ko sayo kahapon.

            masyado lang mataas ang pride at ego ko kaya ako naging ganun.
            salamat sa pag paparealize sa akin nun. pasensya na kung naging walang kwentang anak ako

            
             
             */
        }
        public void addevents()
        {
            //fix database setup first before going here
            bxkBTN.Click += (sender, e) =>
            {
                backupBTN();
            };
            rstrBTN.Click += (sender, e) =>
            {
                RestoreBTN();
            };
            saveFileDialog1.FileOk += (sender,e) =>
            {
                databaseBack();
            };
            openFileDialog1.FileOk += (sender, e) =>
            {
                databaserest();
            };
        }





        public void backupBTN()
        {
           
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            saveFileDialog1.ShowDialog();

        }

        public void RestoreBTN()
        {
            //folderBrowserDialog1.Dispose();
            openFileDialog1.ShowDialog();
            //.ShowDialog();
        }








        public void databaseBack()
        {
            //first replace the name of the db 
          //filename for directpry
            Console.WriteLine(saveFileDialog1.FileName);

        }
        public void databaserest()
        {
           //directory 
            Console.WriteLine(openFileDialog1.FileName);
        }
    }
}
