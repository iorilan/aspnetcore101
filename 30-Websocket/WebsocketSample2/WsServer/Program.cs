using System;
using WsLib;


namespace WsServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           WsServer.Start();

            Console.WriteLine("Listening...");
            Console.ReadLine();
        }
    }
}
