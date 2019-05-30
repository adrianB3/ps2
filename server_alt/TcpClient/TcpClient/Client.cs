using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpClient
{
    class Client : IDisposable
    {
        private readonly System.Net.Sockets.TcpClient _tcpClient;
        private readonly string _ipAddress;
        private readonly int _port;
        private NetworkStream _stream;
       

        public Client(string ipAddress, int port)
        {
            _tcpClient = new System.Net.Sockets.TcpClient();
            _ipAddress = ipAddress;
            _port = port;
        }
        public async Task ConnectAsync()
        {
            await _tcpClient.ConnectAsync(_ipAddress, _port);
            _stream = _tcpClient.GetStream();
        }

        public Task SendAsync(byte[] data)
        {
            return _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<byte[]> ReceiveAsync(int count) 
        {
            byte[] data = new byte[count];
            var i = 0;
            while ((i += await _stream.ReadAsync(data, i, count - i)) < count) ; 
            return data;
        }

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }
            if (_tcpClient != null)
            {
                _tcpClient.Dispose();
            }
        }
    }
}