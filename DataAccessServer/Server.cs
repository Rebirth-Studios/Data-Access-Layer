using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RebirthStudios.DataAccessLayer;

public class StateObject
{
    public static int BUFFER_SIZE = 100000;
    public Socket Socket;
    public byte[] Buffer = new byte[BUFFER_SIZE];
    public StringBuilder StringBuilder = new StringBuilder();

    public StateObject(Socket socket)
    {
        this.Socket = socket;
    }
}
public class Server : IDisposable
{
    public  bool        isRunning;
    private Socket _server;

    private DataTableStoredProcs                     _dataTableStoredProcs;
    private Dictionary<string, Func<string[], byte[]?>> _methods = new Dictionary<string, Func<string[], byte[]?>>();
    
    private bool            isConnected         = true;

    private void OnClientConnected(IAsyncResult result)
    {
        var clientSocket = _server.EndAccept(result);
        Console.WriteLine("Received connection request from: " + clientSocket.RemoteEndPoint.ToString());
        var stateObject = new StateObject(clientSocket!);
        clientSocket!.BeginReceive(stateObject.Buffer, 0, StateObject.BUFFER_SIZE,0, OnDataReceived, stateObject);
        WaitForClients();
    }

    private void WaitForClients()
    {
        _server.BeginAccept(OnClientConnected, null);
    }

    public Server(IPAddress ipAddress, 
        int                 port, 
        byte                copperValue,
        byte                silverValue,
        int                 goldValue,
        byte                maxBags, 
        byte                maxPlayerBuybacks,
        byte                maxCharacters,
        bool                socketProfiling,
        bool                sqlProfiling)
    {
        Console.WriteLine("Starting server... - Socket Profiling: " + socketProfiling + " - SQL Profiling: " + sqlProfiling);
        
        _dataTableStoredProcs = new DataTableStoredProcs(new Logger()
        {
            LogMethod          = Console.WriteLine,
            LogDebugMethod     = LogDebug,
            LogProfilingMethod = LogProfiling,
            LogWarningMethod   = LogWarning,
            LogErrorMethod     = LogError,
            LogExceptionMethod = LogException,
        }, copperValue, silverValue, goldValue, maxBags ,maxPlayerBuybacks, maxCharacters, sqlProfiling);
        _dataTableStoredProcs.Init();

        Server_DataTableStoredProcs.SOCKET_PROFILING_ENABLED = socketProfiling;
        Server_DataTableStoredProcs._logger = new Logger()
        {
            LogMethod          = Console.WriteLine,
            LogDebugMethod     = LogDebug,
            LogProfilingMethod = LogProfiling,
            LogWarningMethod   = LogWarning,
            LogErrorMethod     = LogError,
            LogExceptionMethod = LogException,
        };
        
        foreach (var method in typeof(Server_DataTableStoredProcs).GetMethods(BindingFlags.Public | BindingFlags.Static))
        {
            _methods!.Add(method.Name.ToLower(), (string[] data) =>
            {
                return (byte[]?) method.Invoke(null, new []{data});
            });
        }
        isRunning = true;
        
        _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        _server.Bind(endPoint);
        _server.Listen(5);
        _server.Blocking = true; 
        WaitForClients();


        
        
        // _processingThread = new Thread(Start);
        // _processingThread.Start();

        while (isRunning)
        {
            // _memoryStream.SetLength(0);
            //
            // for (var index = 0; index < connections.Count; index++)
            // {
            //     var socketConn = connections[index];
            //     try
            //     {
            //         //Listen(socketConn);
            //         //Console.WriteLine($"End - Listen: {socketConn?.RemoteEndPoint}");
            //     }
            //     // catch (NullReferenceException)
            //     // {
            //     //     // no op
            //     // }
            //
            //     catch (AggregateException e)
            //     {
            //         Console.ForegroundColor = ConsoleColor.Red;
            //         Console.WriteLine(e);
            //         Console.ForegroundColor = ConsoleColor.White;
            //         //connectionsToRemove.Add(socketConn);
            //     }
            //     catch (SocketException e)
            //     {
            //         Console.ForegroundColor = ConsoleColor.Red;
            //         Console.WriteLine(e);
            //         Console.ForegroundColor = ConsoleColor.White;
            //         //connectionsToRemove.Add(socketConn);
            //     }
            // }
            //
            Thread.Sleep(1);
        }

        //Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        // // A Socket must be associated with an endpoint using the Bind method
        // listener.Bind(new IPEndPoint(ipAddress, port));
        // // Specify how many requests a Socket can listen before it gives Server busy response.
        // // We will listen 10 requests at a time
        // listener.Listen(2);
        //
 
        
        // _listeningThread = new Thread(() =>
        // {
        //     while (isRunning)
        //     {
        //         try
        //         {
        //             var nextTime = DateTime.Now;
        //             // Enter the listening loop.
        //             Console.WriteLine("Waiting for a connection... ");
        //
        //             var handler = _server.AcceptAsync();
        //             isConnected = true;
        //             Console.WriteLine($"Accepted connection from {handler..RemoteEndPoint}");
        //             while (isConnected && isRunning)
        //             {
        //                 // Perform a blocking call to accept requests.
        //                 // You could also use server.AcceptSocket() here.
        //                 Listen(handler.Client);
        //                 if (nextTime < DateTime.Now)
        //                 {
        //                     nextTime = DateTime.Now.AddSeconds(60);
        //                 }
        //
        //                 if (!isConnected)
        //                 {
        //                     handler.Client.Disconnect(true);
        //                     Console.WriteLine("Client disconnected");
        //                 }
        //             }
        //         }
        //         catch (Exception e)
        //         {
        //             LogException(e);
        //         }   
        //     }
        // });
        // _listeningThread.Start();
    }

    // private void Start()
    // {
    //     while (isRunning)
    //     {
    //         try
    //         {
    //             if (connectionsToRemove.Any())
    //             {
    //                 var finalList              = connections.ToList();
    //                 var connectionsToRemoveInt = new List<Socket>();
    //                 for (var i = connectionsToRemove.Count - 1; i > -1; i--)
    //                 {
    //                     var connection = connectionsToRemove.ElementAt(i);
    //                     Console.WriteLine("Removing connection at index: " + i);
    //
    //                     var itemToRemove =
    //                         finalList.FirstOrDefault(z => Equals(z.RemoteEndPoint!.Serialize(),
    //                             connection.RemoteEndPoint!.Serialize()));
    //
    //                     if (itemToRemove == null)
    //                     {
    //                         LogDebug("Item to remove is null. " + connection.RemoteEndPoint!.Serialize());
    //                         connectionsToRemoveInt.Add(connection);
    //
    //                         continue;
    //                     }
    //
    //                     LogDebug($"Removing {itemToRemove}");
    //                     finalList.Remove(itemToRemove);
    //                     connectionsToRemoveInt.Add(connection);
    //                     connection.Dispose();
    //                 }
    //
    //                 foreach (var toRemove in connectionsToRemoveInt)
    //                 {
    //                     connectionsToRemove.Remove(toRemove);
    //                 }
    //
    //                 connections = finalList;
    //             }
    //
    //             // _server.Blocking = false;
    //             // var newSocket = _server.AcceptAsync();
    //             // H
    //             // if (newSocket.RemoteEndPoint != null)
    //             // {
    //             //     connections.Add(newSocket);
    //             //     Console.WriteLine($"({connections.Count}) Connection from " + newSocket.RemoteEndPoint.Serialize());
    //             // }
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine(e.Message + '\n' + e.StackTrace);
    //         }
    //
    //         Thread.Sleep(50);
    //     }
    // }

    private void OnDataReceived(IAsyncResult result)
    {
        var stateObject    = (StateObject)result.AsyncState!;
        stateObject.StringBuilder.Clear();

        try
        {
            var readBytes = stateObject.Socket.EndReceive(result);
            if (readBytes > 0)
            {
                stateObject.StringBuilder.Append(Encoding.ASCII.GetString(stateObject.Buffer, 0, readBytes));
                stateObject.Socket.BeginReceive(stateObject.Buffer, 0, StateObject.BUFFER_SIZE, 0,
                    OnDataReceived, stateObject);
                
                Console.WriteLine($"Received {readBytes} bytes");

                var readData = stateObject.StringBuilder.ToString();
                Console.WriteLine($"Received: {readData}");
                if (readData.Contains("|EOL|"))
                {
                    var splitData = readData.Split("|EOL|");
                    Console.WriteLine($"{splitData.Length - 1} msgs received.");
                    foreach (var individualMessage in splitData)
                    {
                        if (string.IsNullOrEmpty(individualMessage)) continue; 
                        byte[]? msg = Process(individualMessage, out bool write);

                        if(write) _dataTableStoredProcs.ProcessSqlUpdates();
    
                        // Send back a response.
                        if(msg != null) stateObject.Socket.Send(msg, SocketFlags.None);
                        Console.WriteLine("Sending: {0} bytes", msg?.Length);
                    }
                }
            }
            else{
                if (stateObject.StringBuilder.Length > 1) {
                    //All of the data has been read, so displays it to the console
                    string strContent;
                    strContent = stateObject.StringBuilder.ToString();
                    Console.WriteLine($"Read {strContent.Length} byte from socket" + $"data = {strContent} ");
                }
                stateObject.Socket.Close();
            }
        }
        catch (Exception e)
        {
            LogException(e);
            LogDebug(stateObject.Socket.RemoteEndPoint + " disconnected");
        }
       
    }

    private byte[]? Process(string data, out bool write)
    {
        Console.WriteLine($"Processing {data}");
        try
        {
            if (!data.EndsWith("|") && data == "_DISCONNECT_")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                isConnected             = false;
                Console.WriteLine("Disconnecting");
                Console.ForegroundColor = ConsoleColor.White;
                write                   = false;
                return null;
            }
            var split = data.Split("|");
            write = split.Length > 1;
            var bytes = _methods[split[0].ToLower()](split[1..]); 
            Console.WriteLine($"Processed {split[0]} with {bytes?.Length ??0} bytes");
            return bytes;
        }
        catch (Exception e)
        {
            throw;
        }

        write = false;
        return Array.Empty<byte>();
    }

    private void LogDebug(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Debug: " + message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private void LogProfiling(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("PROFILING: " + message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private void LogWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("WARNING: " + message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR: " + message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private void LogException(Exception e)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("EXCEPTION: " + e);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Dispose()
    {
        isRunning = false;
        _dataTableStoredProcs.ProcessSqlUpdates();
        //_listeningThread?.Abort();
        _server?.Dispose();
        _methods.Clear();
    }
}