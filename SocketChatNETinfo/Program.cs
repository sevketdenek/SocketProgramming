using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();
        public static string globalName = null;

        static void Main(string[] args)
        {
            
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
            TcpClient clientSocket =null;
            serverSocket.Start();
            Console.WriteLine("Chat Server Started ...");
            
            while (true)
            {                
                clientSocket = serverSocket.AcceptTcpClient();
                byte[] bytesFrom = new byte[8192];
                string dataFromClient = null;                
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);  
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);                
                dataFromClient =dataFromClient.Substring(0, dataFromClient.IndexOf("$"));               
                clientsList.Add(dataFromClient, clientSocket);                
                globalName = dataFromClient;
                Broadcast(dataFromClient + " joined ", dataFromClient, false);
                Console.WriteLine(dataFromClient + " joined to room ");                
                handleClinet client = new handleClinet();
                client.StartClient(clientSocket, dataFromClient, clientsList);                                
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }
        
       
        public static void Broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                
                 /* Bir istemci cikis yaptıgında tekrar bir istemci baglandiginda hata mesajı burada alındı ve
                 Try catch icerisine alınarak eger istemci cikis yaparsa Hashtable cakismasi olmamasi icin
                 break konuldu */
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;

                try
                {
                    NetworkStream broadcastStream = broadcastSocket.GetStream();               
                    Byte[] broadcastBytes = null;

                    if (flag == true)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(uName + "  : " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                }
                catch
                {
                    break;
                }
            }
        }
    }


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        Thread[] threads = new Thread[3];
        Semaphore sem = new Semaphore(1, 1);
        List<string> messagesList = new List<string>();
        
        public void StartClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(DoChat);
            ctThread.Start();
            
        }

        private void DoChat()
        {
            byte[] bytesFrom = new byte[8192];
            string dataFromClient = null;
            string singleMessage = null;
            int singleMessageLength = 0;
            long messageCount =0;                  

            while (true)
            {
                
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);                   
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    messageCount= dataFromClient.Length - dataFromClient.Replace("$", "").Length;
                    
                    //for(int i = 0; i < messageCount; i++)
                    //{
                    //    singleMessage=dataFromClient.Substring(singleMessageLength, dataFromClient.IndexOf("$"));
                    //    singleMessageLength = singleMessage.Length+1;
                    //    messagesList.Add(singleMessage);
                    //    for (int j = 0; j < 3; j++)
                    //    {
                    //        threads[j] = new Thread(AddComma);
                    //        threads[j].Name = "thread_" + j;
                    //        threads[j].Start();
                    //    }

                    //}
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    messagesList.Add(dataFromClient);
                    for (int j = 0; j < 3; j++)
                    {
                        threads[j] = new Thread(AddComma);
                        threads[j].Name = "thread_" + j;
                        threads[j].Start();
                    }

                    //Console.WriteLine("İstemci - " + clNo + " : " + dataFromClient);
                    Program.Broadcast(dataFromClient, clNo, true);
                    
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("İstemci cikis yapti");
                    Console.WriteLine(ex.ToString());
                    clientSocket.Close();
                    break;
                }
            }
            
        }
        public  void AddComma()
        {

            sem.WaitOne();

            if (messagesList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Thread.CurrentThread.Name + "Entering to Critical section");
                int averageIndex = messagesList[0].ToString().Length / 2;
                string msg = messagesList[0].ToString().Substring(0, averageIndex) + "," + messagesList[0].ToString().Substring(averageIndex);
                Console.WriteLine(msg);
                int a=messagesList.Count;
                messagesList.RemoveAt(0);
                Console.WriteLine(Thread.CurrentThread.Name + "Exiting from Critical Section");
                int b  = messagesList.Count;
            }

            sem.Release();

        }

    } 
}