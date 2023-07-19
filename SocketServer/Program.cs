// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

public class Program
{

    public static void Main(string[] args)
    {
        ServerClassBuilder.BuildRPCMethod();
        ClientClassBuilder.BuildRPCMethod();
        
        var p = new Process();
        p.StartInfo = new ProcessStartInfo(@"E:\Users\logan\RiderProjects\SocketServer\CopyBuildsToUnity\bin\Release\net7.0\CopyBuildsToUnity.exe");
        p.StartInfo.ArgumentList.Add("Test");
        p.Start();
        
        while (!p.HasExited)
        {
    
        }

        Console.WriteLine("Restart?: yes or no");
        var restart = Console.ReadLine();
        if(restart == "yes" || restart == "y")
        {
            Main(args);
        }
    }   
}

// Console.WriteLine("Hello, World!");
// Int32     port      = 13000;
// IPAddress localAddr = IPAddress.Parse("127.0.0.1");
//
//
// //var    requestData = await client.RequestData("B");
//
// Server       server = new Server(localAddr, port);
// SocketClient client = new SocketClient(localAddr, port);
// client.Connect(localAddr, port);
//Client_DataTableStoredProcs._socket = client._socket;
//var    characterId = await Client_DataTableStoredProcs.GlobalObjects_GetList();

//MyNamespace.Program.Main(null);
//Console.ReadLine();


//File.Copy();

// var currentDirectory = Directory.GetCurrentDirectory();
// var ending           = string.Join(@"\", currentDirectory.Split(@"\")[^4..]);

//var serverProjectPath = currentDirectory.Replace(ending, @"DataAccessServer\DataAccessServer.csproj");
//BuildProject(serverProjectPath);

//
// var p = new Process();
// p.StartInfo = new ProcessStartInfo(@"C:\Users\logan\RiderProjects\SocketServer\CopyBuildsToUnity\bin\Release\net7.0\CopyBuildsToUnity.exe");
// p.StartInfo.ArgumentList.Add("");
// p.StartInfo.ArgumentList.Add("Yeet");
// p.Start();


// var clientProjectPath                  = currentDirectory.Replace($"{ending}", @"DataAccessLayerClient\DataAccessLayerClient.csproj");
// BuildProject(clientProjectPath);

