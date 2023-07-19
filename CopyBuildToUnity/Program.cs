using CopyBuildToUnity;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<Worker>(); })
    .Build();

host.Run();

var unitySocketServerPath = @"D:\My project (3)\DataAccessServer";
var files = Directory.GetFiles(@"C:\Users\logan\RiderProjects\SocketServer\DataAccessServer\bin\Release\netcoreapp3.1");
foreach (var file in files)
{
    Console.WriteLine(file);

    var fileName = file.Split(@"\")[^1];
    File.Copy(file, unitySocketServerPath + "\\" + fileName);
    
}