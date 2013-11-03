using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestServer
{
    public class MessageServer
    {
        public bool Run { set; get; }

        private TcpListener _listener;
        private Thread _listenThread;

        private int _port = 37015;

        int _threadCounter = 0;

        public MessageServer()
        {
            Init();
        }

        private void Init()
        {
            Run = true;
            _listener = new TcpListener(IPAddress.Any, _port);
            _listenThread = new Thread(new ThreadStart(ListenForClients));
            _listenThread.Start();
        }

        private void ListenForClients()
        {
            _listener.Start();

            while (Run)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected!");

                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientCommunication));
                clientThread.Start(client);
                ++_threadCounter;
            }
        }

        private void ClientCommunication(object client)
        {
            using (TcpClient tcpClient = (TcpClient)client)
            {
                using (NetworkStream clientStream = tcpClient.GetStream())
                {
                    while (Run)
                    {
                        try
                        {
                            //if(tcpClient.Available == 0)
                               // return;

                            StreamReader sr = new StreamReader(clientStream);
                            string getvar = sr.ReadLine();

                            while (string.IsNullOrEmpty(getvar))
                            {
                                Thread.Sleep(100);
                                getvar = sr.ReadLine();
                            }

                            Console.WriteLine("Msg received: " + getvar);

                            /*
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                Console.WriteLine(line);
                                if (string.IsNullOrEmpty(line)) 
                                    break;
                            }*/

                            //StreamWriter sw = new StreamWriter(clientStream);
                            //sw.WriteLine("Message from server!");
                            //sw.Flush();

                            //Console.WriteLine("Sent message to Client.");

                            sr.Close();
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
