using Game.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Game.Manager
{
    public class WebSocketManager
    {
        private static readonly Lazy<WebSocketManager> _instance =
            new Lazy<WebSocketManager>(() => new WebSocketManager());

        public static WebSocketManager Instance => _instance.Value;

        private ClientWebSocket _webSocket;

        private WebSocketManager()
        {
            _webSocket = new ClientWebSocket();
        }

        public event Action<string> OnMessageReceived;

        public async Task ConnectAsync(string uri)
        {
            await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            StartListening();
        }

        private async void StartListening()
        {
            var buffer = new byte[1024 * 4];

            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    //JToken json = JsonHelper.ExtractAll(message);
                    OnMessageReceived?.Invoke(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
            }
        }

        public async Task SendMessageAsync(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task DisconnectAsync()
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None);
        }
    }
}
