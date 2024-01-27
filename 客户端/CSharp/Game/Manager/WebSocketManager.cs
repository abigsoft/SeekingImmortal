using Game.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Manager
{
    public class WebSocketManager
    {
        private static readonly Lazy<WebSocketManager> _instance = new Lazy<WebSocketManager>(() => new WebSocketManager());
        private ClientWebSocket _webSocket;
        private Uri _serverUri;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public event Action<string> MessageReceived;
        public event Action<Exception> ErrorOccurred;
        public event Action Disconnected;

        // 获取WebSocketManager实例的静态属性
        public static WebSocketManager Instance => _instance.Value;

        private WebSocketManager()
        {
            _webSocket = new ClientWebSocket();
        }

        public async Task ConnectAsync(string uri)
        {
            try
            {
                this._serverUri = new Uri(uri);
                await _webSocket.ConnectAsync(_serverUri, _cancellationTokenSource.Token);
                StartListening();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }

        private async void StartListening()
        {
            var buffer = new byte[1024 * 4];
            while (!_cancellationTokenSource.IsCancellationRequested && _webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationTokenSource.Token);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        MessageReceived?.Invoke(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Disconnected?.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    ErrorOccurred?.Invoke(ex);
                }
            }

        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                if (_webSocket.State == WebSocketState.Open)
                {
                    var buffer = Encoding.UTF8.GetBytes(message);
                    await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, _cancellationTokenSource.Token);
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }

        public async Task DisconnectAsync()
        {
            _cancellationTokenSource.Cancel();
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None);
            }
            _webSocket.Dispose();
        }
    }
}
