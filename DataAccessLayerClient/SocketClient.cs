using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RebirthStudios.DataAccessLayer;

public class SocketClient
{
    private ILogger _logger;
    public  Socket  _socket;
    public SocketClient(ILogger logger, IPAddress ipAddress, int port)
    {
        _logger = logger;
        _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    }

    public bool Connect(IPAddress ipAddress, int port, bool throwException = true)
    {
        _logger.Log($"SocketClient.Connect: {ipAddress}:{port}");
        try
        {
            _socket.Connect(ipAddress, port);
            return true;
        }
        catch (Exception e)
        {
            if(throwException) _logger.LogException(e);
            return false;
        }
    }
}