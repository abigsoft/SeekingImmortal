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
        public static WebSocketManager Instance => _instance.Value;

        private ClientWebSocket _webSocket;
        private CancellationTokenSource _cts;
        private Uri _serverUri;
        public event Action<string> OnMessageReceived;
        public event Action<Exception> OnError;

        private WebSocketManager()
        {
            _webSocket = new ClientWebSocket();
            _cts = new CancellationTokenSource();
            //_serverUri = new Uri("ws://your-websocket-server-uri"); // 替换为你的WebSocket服务端地址
        }

        public async Task ConnectAsync(Uri serverUri)
        {
            _serverUri = serverUri;
            while (true)
            {
                try
                {
                    if (_webSocket.State == WebSocketState.Open)
                    {
                        // 如果WebSocket已经是打开状态，不需要重新连接
                        break;
                    }
                    else
                    {
                        if (_webSocket.State != WebSocketState.Connecting)
                        {
                            _webSocket.Dispose();
                            _webSocket = new ClientWebSocket();
                            await _webSocket.ConnectAsync(_serverUri, _cts.Token);
                            StartHeartbeat();
                            StartReceiving();
                        }
                    }
                }
                catch (WebSocketException ex)
                {
                    OnError?.Invoke(ex);
                    // 等待一段时间再尝试重连
                    await Task.Delay(TimeSpan.FromSeconds(10), _cts.Token);
                }
            }
        }

        private void StartReceiving()
        {
            Task.Run(async () =>
            {
                var buffer = new byte[4096];

                try
                {
                    while (!_webSocket.CloseStatus.HasValue)
                    {
                        var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cts.Token);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            // 如果服务器关闭了WebSocket连接，尝试重新连接
                            await ConnectAsync(_serverUri);
                        }
                        else
                        {
                            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            OnMessageReceived?.Invoke(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //OnError?.Invoke(ex);
                    // 如果发生异常（可能是因为服务器重启），尝试重新连接
                    await ConnectAsync(_serverUri);
                }
            }, _cts.Token);
        }

        private void StartHeartbeat()
        {
            Task.Run(async () =>
            {
                while (!_webSocket.CloseStatus.HasValue)
                {
                    try
                    {
                        await SendAsync("{\"type\":\"ping\"}");
                    }
                    catch (Exception ex)
                    {
                        //OnError?.Invoke(ex);
                    }

                    await Task.Delay(TimeSpan.FromSeconds(20), _cts.Token);
                }
            });
        }

        public async Task SendAsync(string message)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, _cts.Token);
            }
        }

        public async Task DisconnectAsync()
        {
            _cts.Cancel();
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, _cts.Token);
            }
            _webSocket.Dispose();
        }
    }
}
