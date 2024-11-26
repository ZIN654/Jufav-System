using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace JUFAV_System.dll
{
    class NetworkClass
    {
        static NetworkStream stream;
        static NetworkStream stream2;
        static Byte[] bytes = new Byte[256];
       static String data = null;
        static Byte[] bytes2 = new Byte[256];
        static String data2 = null;
        static TcpListener as1;
        public static RichTextBox rich1;
        static bool Stop = true;
        static TcpClient tcpc;
        public static void Start_Server(String address1,Int32 Port)
        {
            


                //creates a new server
                IPAddress address = IPAddress.Parse(address1);
                 as1  = new TcpListener(address, Port);
                as1.Start();

                listen();
         

        }
        public static async void CLient(Int32 Port,String IP)
        {
          //receives the connection string
            tcpc = new TcpClient();
            await tcpc.ConnectAsync(IP, Port);
            // data2 = ASCIIEncoding.GetEncoding().GetBytes(,);
            if (tcpc.Connected)
            {
                MessageBox.Show("SUCCESSFULLR CONNECTED TO SERVER!", "CONNECT TO DEVICE");

            }
            stream2 = tcpc.GetStream();
            int receivrd = await stream2.ReadAsync(bytes2,0,bytes2.Length);
            //the received connstring will be setted
            var message = ASCIIEncoding.GetEncoding(0).GetString(bytes2,0,receivrd);
            //set to 
            MessageBox.Show(message);

            initd.constringfromserver = message;
            initd.con1.ConnectionString = message;
            
            //uses the same connection /bakit ? un na kasi ung nakasalpak salahat
            //if selected ang connect to other change ng connstrng kunin sa kabila and USEES DHCP dynamic IP
            //else uses its own IP address at return sa STATIC IP

        }
      
        public static async void listen()
        {
            //listens for connectiong clienrts
        
            try
            {

               while (true)
                {
                  
                    var client = await as1.AcceptTcpClientAsync();//waits for incoming clients this not loop just waits
                    if (client.Connected)
                    {
                      //  MessageBox.Show("CLIENT CONNECTED!","CONNECT TO DEVICE");
                       // sendmessage(initd.con1.ConnectionString.ToString());
                        MessageBox.Show("THIS WAS FROM ADMIN SENDS ITS CONNSTRRING" + initd.con1.ConnectionString.ToString());
                    }
                  
                    data = null;
                    stream = client.GetStream();  //reads all incoming data from connected client 
                    int i;
                    while ((i = await stream.ReadAsync(bytes,0,bytes.Length)) != 0)//if i != 0
                    {
                        //receiiving
                        data = ASCIIEncoding.GetEncoding(0).GetString(bytes, 0, i);
                        // data = data.ToUpper();
                       
                    }
                   

                }
            }
            catch (SocketException e)
            {


                MessageBox.Show(e.ToString());

            }
            finally
            {

                as1.Stop();
            }
            // TcpListener as1 = new TcpListener(,);
        }
        public static void sendmessage(String msg1)
        {  //sending 
            Byte[] msg = ASCIIEncoding.GetEncoding(0).GetBytes(msg1);
            stream.WriteAsync(msg, 0, msg.Length);
          
        }
        public static void sendmessage2(String msg1, String name)
        {  //sending 

            Byte[] msg = ASCIIEncoding.GetEncoding(0).GetBytes(name + " :" + msg1);
            stream2.WriteAsync(msg, 0, msg.Length);
           
        }
        public static void StopServer()
        {
            Stop = true;
            tcpc.Close();
            as1.Stop();
       //     sendmessage("SERVER STOPPED!");
         
         

          

        }
    }
}
