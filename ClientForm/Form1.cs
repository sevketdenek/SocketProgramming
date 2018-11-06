using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        
        NetworkStream serverStream = null;        
        string readData = null;
        


        public Form1()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Getting messages from server 
        /// </summary>
        private void getMessage()
        {
            while (true)
            {
                //serverStream = clientSocket.GetStream();
                //int buffSize = 0;
                //byte[] inStream = new byte[8192];
                //buffSize = clientSocket.ReceiveBufferSize;
                //serverStream.Read(inStream, 0, buffSize);
                //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                //readData = "" + returndata;
                //msg();
            }
        }
        /// <summary>
        /// Getting messages with invoking method
        /// </summary>
        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                rTBoxChat.Text =  " >> " + readData;
        }

        /// <summary>
        /// Send userName to the server 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bConnect_Click(object sender, EventArgs e)
        {
            readData = "Conected to Chat Server ...";
            msg();
            clientSocket.Connect("127.0.0.1", 1234);            
            serverStream = clientSocket.GetStream();
                        
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(tName.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }

        private void bSendMessage_Click(object sender, EventArgs e)
        {

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(rTBoxSendMessage.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            //Thread.Sleep(100);            
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            //Thread.Sleep(100);            
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            
            

        }
       
    }
}
