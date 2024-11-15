using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace JUFAV_System.dll
{
    class ResponsiveUI1
    {

        public static Label headingtitle;
        //this spl1 is the panel fromm the core 
        public static Panel spl1;
        public static String title = "";
        public static String title2 = "";
        //panel for login
        




      
        //0-FM,1-INV,2-SLS,3-RPRT,4-UTL
        public static void onenter1(CheckBox h1, Color cl1)
        {
            h1.BackColor = cl1;

        }
        public static void onleave(CheckBox h1, Color cl1)
        {
            h1.BackColor = cl1;


        }
        //++++++++++++++++++LIBRARY FOR RESPONSIVE USER INTERFACE AND EVENT HANDLERS FOR UI RESPONSIVENESS+++++++++++++++++++++
        //for mainbuttons contains /label/panel/2 picture box
      
        public static void EventhandlerMouseEnterExit(Panel Button,Label title,PictureBox icon,PictureBox Dropdownicon,KnownColor colorwhenhover,KnownColor coloronexit)
        {
            Button.MouseEnter += (sender,e) => { Button.BackColor = Color.FromKnownColor(colorwhenhover);};
            title.MouseEnter += (sender, e) => { Button.BackColor = Color.FromKnownColor(colorwhenhover); };
            icon.MouseEnter += (sender, e) => { Button.BackColor = Color.FromKnownColor(colorwhenhover); };
            Dropdownicon.MouseEnter += (sender, e) => { Button.BackColor = Color.FromKnownColor(colorwhenhover); };

            //on exit
            Button.MouseLeave += (sender, e) => { Button.BackColor = Color.FromKnownColor(coloronexit); };
            //use 5 panels for faster movement.
        }
        public static void EventhandlerMouseClick(Panel Button, Label title, PictureBox DropdownIcon, PictureBox Dropdown, Action method)
        {
            Dropdown.Click += (sender, e) => {method();};
            DropdownIcon.Click += (sender, e) => {method();};
            title.Click += (sender, e) => {method();};
            Button.Click += (sender, e) => {method();};
        }
      
        //for sub module buttons 
        public static void EventhandlerMouseEnterExit(Panel firstpan,Label secondpan,KnownColor colorwhenhover, KnownColor coloronexit)
        {
            firstpan.MouseEnter += (sender, e) => { firstpan.BackColor = Color.FromKnownColor(colorwhenhover); };
            secondpan.MouseEnter += (sender, e) => { firstpan.BackColor = Color.FromKnownColor(colorwhenhover); };

            //on exit
            firstpan.MouseLeave  += (sender, e) => { firstpan.BackColor = Color.FromKnownColor(coloronexit); };
        }
        public static void EventhandlerMouseClick(Panel Button, Label title, Action method)
        {

            //to invoke the action invoke it just like a method();
            //action vs delegate?
           
           
            title.Click += (sender, e) => { method(); };
            Button.Click += (sender, e) => { method(); };
        }

        //================================FOR MAIN BUTTONS==================================
        public static void OnhoverMainModule(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
        }
        public static void OnExithoverMainModule(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
        }
        public static void OnClickMainModule(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
        }
        public static void OnReleaseMainModule(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
        }
        public static void OnMoveMainModule(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
        }

        //===============================FOR SUB MODULE BUTTONS===================================
        public static void OnExithoverSubmodules(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
        }
        public static void OnEnterhoverSubmodules(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ButtonShadow);
        }
        public static void OnReleasedSubmodules(Panel pan1)
        {
            pan1.BackColor = Color.FromKnownColor(KnownColor.ButtonShadow);
        }
        //===============================FOR PICTURE BOX ENTER,CLICK,LEAVE==============================
        public static void OnenterUI(PictureBox ps1) {
           // ps1.BackColor = Color.LightGray;
            ps1.BackColor = Color.Red;
        }
        public static void OnLeave(PictureBox ps1) {
            ps1.BackColor = Color.WhiteSmoke;
        }
        









        //==================================FOR MAIN MODULES BUTTONS=========================================

        public static void FileMaintenanceClick(Panel Button, Label title, PictureBox DropdownIcon, PictureBox Dropdown, Action method)
        {
            Dropdown.Click += (sender, e) => { method(); };
            DropdownIcon.Click += (sender, e) => { method(); };
            title.Click += (sender, e) => { method(); };
            Button.Click += (sender, e) => { method(); };
        }
        public static void InventoryClick(Panel Button, Label title, PictureBox DropdownIcon, PictureBox Dropdown, Action method)
        {
            Dropdown.Click += (sender, e) => { method(); };
            DropdownIcon.Click += (sender, e) => { method(); };
            title.Click += (sender, e) => { method(); };
            Button.Click += (sender, e) => { method(); };
        }
        //===================================HEADINGS TITLE -=================================================
        public static void asigntext(String text)
        {
            headingtitle.Text = text;
            //assign text when a button clicks


 
        }
      
        






    }

}
