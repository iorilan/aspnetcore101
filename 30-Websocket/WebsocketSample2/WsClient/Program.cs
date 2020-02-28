using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsLib;

namespace WsClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
             WsClient.Open();
            while (true)
            {
                Console.WriteLine("type whatever to send. press q+Enter to stop");
                var read = Console.ReadLine();
                if (read == "q")
                {
                    break;
                }

                WsClient.Send(read);
            }

            WsClient.Close();
        }
    }
}
