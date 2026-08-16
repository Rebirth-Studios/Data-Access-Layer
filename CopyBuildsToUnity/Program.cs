// See https://aka.ms/new-console-template for more information

using System.Reflection;

public class Program
{
    private static readonly string baseUnityPath = @"D:\Elysium";
    private static void CopyServerFiles()
    {
        var unitySocketServerPath = $@"{baseUnityPath}\DataAccessServer";
        var filePath = Assembly.GetEntryAssembly()!.Location;
        // Get the directory of the executable
        string currentDirectory = Path.GetDirectoryName(filePath)!;

        // Move up two levels
        string parentDirectory = Directory.GetParent(currentDirectory)!.Parent!.Parent!.Parent!.FullName;
        
        var files = Directory.GetFiles($@"{parentDirectory}\DataAccessServer\bin\Release\net8.0");
        foreach (var file in files)
        {
            var fileName = file.Split(@"\")[^1];
            if(File.Exists(unitySocketServerPath + "\\" + fileName)) File.Delete(unitySocketServerPath + "\\" + fileName);
            File.Copy(file, unitySocketServerPath     + "\\" + fileName);
    
        }
        
    }


    private static void CopyClientFiles()
    {
        var unitySocketClientPath = $@"{baseUnityPath}\Assets\Plugins\DataAccessClient";
        var filePath = Assembly.GetEntryAssembly()!.Location;
        // Get the directory of the executable
        string currentDirectory = Path.GetDirectoryName(filePath)!;

        // Move up two levels
        string parentDirectory = Directory.GetParent(currentDirectory)!.Parent!.Parent!.Parent!.FullName;
        var files = Directory.GetFiles(@$"{parentDirectory}\DataAccessLayerClient\bin\Release\netstandard2.1", "*.dll");
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


