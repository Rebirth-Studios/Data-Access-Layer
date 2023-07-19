// See https://aka.ms/new-console-template for more information

public class Program
{
    private static void CopyServerFiles()
    {
        var unitySocketServerPath = @"C:\Unity\Elysium.Shared.Game\DataAccessServer";
        var files = Directory.GetFiles(@"E:\Users\logan\RiderProjects\SocketServer\DataAccessServer\bin\Release\netcoreapp3.1");
        foreach (var file in files)
        {
            var fileName = file.Split(@"\")[^1];
            if(File.Exists(unitySocketServerPath + "\\" + fileName)) File.Delete(unitySocketServerPath + "\\" + fileName);
            File.Copy(file, unitySocketServerPath     + "\\" + fileName);
    
        }
        
    }


    private static void CopyClientFiles()
    {
        var unitySocketClientPath = @"C:\Unity\Elysium.Shared.Game\Assets\Plugins\DataAccessClient";
        var files = Directory.GetFiles(@"E:\Users\logan\RiderProjects\SocketServer\DataAccessLayerClient\bin\Release\netstandard2.1", "*.dll");
        foreach (var file in files)
        {
            var fileName = file.Split(@"\")[^1];
            if(File.Exists(unitySocketClientPath + "\\" + fileName)) File.Delete(unitySocketClientPath + "\\" + fileName);
            File.Copy(file, unitySocketClientPath     + "\\" + fileName);
    
        }
    }
    
    public static void Main(string[] args)
    {
        
        CopyServerFiles();
        CopyClientFiles();
        if (args.Length == 0)
        {
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}


