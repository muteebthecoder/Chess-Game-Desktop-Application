using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient p1sock;
                TcpClient p2sock;
                NetworkStream p1ns;
                NetworkStream p2ns;
                TcpListener serversock;
                string pmsg;
                BinaryFormatter bf;
                serversock = new TcpListener(11001);
                serversock.Start();
                Console.WriteLine("Server Started");
                p1sock = serversock.AcceptTcpClient();
                Console.WriteLine("Player 1 Connected.");
                p2sock = serversock.AcceptTcpClient();
                Console.WriteLine("Player 2 Connected.");
                bf = new BinaryFormatter();
                p1ns = p1sock.GetStream();
                p2ns = p2sock.GetStream();
                bf.Serialize(p1ns, "White");
                bf.Serialize(p2ns, "Black");
                for (int i = 1; i < 1000; i++)
                {
                    if (i % 2 == 1)
                    {
                        pmsg = (string)bf.Deserialize(p1ns);
                        bf.Serialize(p2ns, pmsg);
                    }
                    else
                    {
                        pmsg = (string)bf.Deserialize(p2ns);
                        bf.Serialize(p1ns, pmsg);
                    }
                }
                Console.WriteLine("Game End");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
