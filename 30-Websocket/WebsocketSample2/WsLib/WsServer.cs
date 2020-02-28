using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WsLib
{
    public class WsServer
    {
        public static void Start()
        {
            var wssv = new WebSocketServer($"ws://{WsConfig.Ip}:{WsConfig.Port}");
            wssv.AddWebSocketService<PingTest>("/PingTest");
            wssv.Start();
        }
    }

    public class PingTest : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"From client :{e.Data}");

            var msg = $"Server recieved {e.Data} at {DateTime.Now}";

            Send(msg);
        }
    }
}
