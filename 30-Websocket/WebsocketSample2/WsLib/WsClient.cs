using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace WsLib
{
    public class WsClient
    {
        private static WebSocket __ws;

        public static void Open()
        {
            __ws = new WebSocket($"ws://{WsConfig.Ip}:{WsConfig.Port}/PingTest");
            __ws.OnOpen += (sender, args) => { Console.WriteLine("Ws opened"); };
            __ws.OnClose += (sender, args) => { Console.WriteLine("Ws Closed"); };
            __ws.OnError += (sender, args) => { Console.WriteLine($"Error :{args.Message}"); };
            __ws.OnMessage += (sender, e) =>
            {
                Console.WriteLine("[From Server]: " + e.Data);
            };
            __ws.Connect();
        }
        public static void Send(string msg)
        {
            if (__ws.ReadyState == WebSocketState.Closed)
            {
                __ws.Connect();
            }

            __ws.Send(msg);
        }

        public static void Close()
        {
            __ws.Close();
        }
    }
}
