using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpClient
{
    public class Client: IDisposable
    {
        private readonly System.Net.Sockets.TcpClient _tcpClient;
        private readonly string _ipAddress;
        private readonly int _port;
        private NetworkStream _stream;

        public Client(System.Net.Sockets.TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
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