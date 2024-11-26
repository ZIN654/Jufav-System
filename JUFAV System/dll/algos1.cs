using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Text.RegularExpressions;


namespace JUFAV_System.dll
{
    class algos1
    {
        //BUGS TO FIX
        //duplication
        //admin editing his ownw access rights
        //lowercase 
        static MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("",initd.con1);
        static MySql.Data.MySqlClient.MySqlDataReader sread1;//care full make sure its only used by one fucntion
       
        public static bool DetectInputifDupplicate(String [] data,int summontype)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            bool test1 = true;
            String[] querytype = { "SELECT SUPPLIERNAME,CONTACTPERSON,CONTACTNUMBER,COMPANYADDRESS FROM SUPPLIERS;", "SELECT NAME,USERNAME FROM USER_INFO;", "SELECT CATEGORYDESC FROM CATEGORY;","SELECT SUBCATEGORYDESC FROM SUBCATEGORY", "SELECT UNITDESC,UNITABBREVIATION FROM UNITOFMEASURE", "SELECT PRODUCTNAME FROM PRODUCTS"};
            //make lower case each insert
            //supplier /user/category/sub category/unit/products/
            //make sure the database is open when using this other wise execption will occure
            
            scom1.CommandText = querytype[summontype];
            sread1 = scom1.ExecuteReader();
            
            switch (summontype)
            {

                case 0:
                    while (sread1.Read())
                    {
                      
                       if(determinewhichpart(new String[] {sread1["SUPPLIERNAME"].ToString(), sread1["CONTACTPERSON"].ToString(), sread1["CONTACTNUMBER"].ToString(), sread1["COMPANYADDRESS"].ToString() },data, 3) == false)
                        {
                            test1 = false;
                            break;
                        }

                    }
                    sread1.Close();
                    break;
                case 1:
                    while (sread1.Read())
                    {
                        if (determinewhichpart(new String[] { sread1["NAME"].ToString(), sread1["USERNAME"].ToString()}, data, 2) == false)
                        {
                            test1 = false;
                            break;
                        }
                    }
                    sread1.Close();
                    break;
                case 2:
                    while (sread1.Read())
                    {
                        if (determinewhichpart(new String[] { sread1["CATEGORYDESC"].ToString()}, data, 0) == false)
                        {
                            test1 = false;
                            break;
                        }
                    }
                    sread1.Close();
                    break;
                case 3:
                    while (sread1.Read())
                    {
                        if (determinewhichpart(new String[] { sread1["SUBCATEGORYDESC"].ToString() }, data, 0) == false)
                        {
                            test1 = false;
                            break;
                        }
                    }
                    sread1.Close();
                    break;
                case 4:
                    while (sread1.Read())
                    {
                        if (determinewhichpart(new String[] { sread1["UNITDESC"].ToString(), sread1["UNITABBREVIATION"].ToString() }, data, 1) == false)
                        {
                            test1 = false;
                            break;
                        }
                    }
                    sread1.Close();
                    break;
                case 5:
                    while (sread1.Read())
                    {
                        if (determinewhichpart(new String[] { sread1["PRODUCTNAME"].ToString() }, data, 0) == false)
                        {
                            test1 = false;
                            break;
                        }
                    }
                    sread1.Close();
                    break;
                default:
                    break;


            }
            initd.con1.Close();
            return test1;
           
        }
        public static bool determinewhichpart(String [] data,String [] loaded,int datacount)
        {
            bool test1 = true;
           // bool test2 = true;
            for (int i = 0;i <= datacount;i++)
            {
                if (data[i].ToString() == loaded[i].ToString())
                {
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "DUPLICATION", "Data Entry at : '" + data[i].ToString() +"' IS ALREADY EXISTING AT DATABASE PLEASE TRY AGAIN!.", "RETRY", 2);
                    ms.Show();
                    test1 = false;
             //       test2 = false;
                    break;
                }
                /*
                if (determineifidentical(data[i].ToString(),loaded[i].ToString()) == true && test2 == true)
                {
                    //determins if identical
                    Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "DUPLICATION", "Data Entry at : '" + data[i].ToString() + "' IS IDENTICAL TO AN EXISTING DATA IN DATABASE PLEASE TRY AGAIN!.", "RETRY", 2);
                    ms.Show();
                    test1 = false;
                    break;
                }
                */
            }
            GC.Collect();
            return test1;
        }
        public static bool determineifidentical(String textinput,String pattern)
        {
            return Regex.IsMatch(textinput,pattern);
        }
      

    }
}
