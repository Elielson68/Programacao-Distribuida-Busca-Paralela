using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estudo.Threads
{
    public class SocketServerConnection
    {
        public static void Run()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12000); 
            Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);  
            listener.Listen(100); 
            Console.WriteLine("Aguardando conexão...");  
            Socket handler = listener.Accept();  
            String data = null;    
            while (true) {  
                var bytes = new byte[1024];  
                int bytesRec = handler.Receive(bytes);  
                data = Encoding.ASCII.GetString(bytes,0,bytesRec);  
                if (data.IndexOf("<EOF>") > -1) {  
                    break;  
                }
                var result = FindFiller.Busca(data.ToString().Split());
                FindFiller.ResetValues();
                Console.WriteLine( "Text received: {0}", data);  
                Console.WriteLine( "Text resultado: {0}", result);  
                byte[] msg = Encoding.ASCII.GetBytes(result);  
                handler.Send(msg);
            }  
            
            Console.WriteLine( "Text received : {0}", data);  
            
            byte[] msg2 = Encoding.ASCII.GetBytes(data);  
            handler.Send(msg2);  
            handler.Shutdown(SocketShutdown.Both);  
            handler.Close(); 
        }
    }
}