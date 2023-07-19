using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RebirthStudios.DataAccessLayer.Models;

public class Program
{
    
    public static void Main(string[] args)
    {
        try
        {
            
            DataAccessServerSettings settings;

            if (args.Length > 0)
            {
                Console.WriteLine($"Starting server: {args[0]}");
                settings = JsonConvert.DeserializeObject<DataAccessServerSettings>(args[0])!;
            }
            else settings = new DataAccessServerSettings();
            
            Server server = new Server(
                ipAddress: IPAddress.Parse(settings.ipAddress),
                port: settings.port, 
                copperValue: settings.copperValue,
                silverValue: settings.silverValue,
                goldValue: settings.goldValue,
                maxBags: settings.maxBags,
                maxPlayerBuybacks: settings.maxPlayerBuybacks,
                maxCharacters: settings.maxCharacters,
                socketProfiling: settings.socketProfiling,
                sqlProfiling: settings.sqlProfiling);
        
            Console.WriteLine("Press key to exit");
            while (true)
            {
                var input = Console.ReadLine();
                if(input == "exit") break;
                if (input == "clear")
                {
                    Console.Clear();
                }
            }
            
            server.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            //throw;
        }
       

    }

}