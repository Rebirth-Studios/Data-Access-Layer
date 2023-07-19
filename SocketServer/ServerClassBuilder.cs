using System.Reflection;
using RebirthStudios.DataAccessLayer;

internal class ServerClassBuilder
{
    public static void BuildRPCMethod()
    {
        var filePath    = @"E:\Users\logan\RiderProjects\SocketServer\DataAccessServer\Server_DataTableStoredProcs.cs";
//File.WriteAllLines(filePath, File.ReadAllLines(templateFilePath));
        var templateData = @"#define SQL_PROFILING 
    using System.Net.Sockets;   
    using System.Text;
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Diagnostics;
    using RebirthStudios.DataAccessLayer;
    using RebirthStudios.DataAccessLayer.Models;
    using RebirthStudios.Enums;
    using RebirthStudios.Enums.Items;

    public class Server_DataTableStoredProcs
    {
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        public static ILogger   _logger;
        public static bool   SOCKET_PROFILING_ENABLED = false;

    ";

        File.WriteAllText(filePath, templateData);
        foreach (var method in typeof(DataTableStoredProcs).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic))
        {
            var accessModifier                  = method.IsPublic ? "public" : method.IsAssembly ? "internal" : "private";
            if(method.IsAssembly || method.IsPrivate) continue;
            if(method.Name.StartsWith("set_")) continue;
            if(method.Name.StartsWith("get_")) continue;
            if (method.IsStatic) accessModifier += " static";

            //var returnType = GenerateTypeString(method.ReturnType);
            var returnType = "byte[]?";
            //returnType = $"Task<" + returnType  + ">";
            returnType = returnType.Contains("void1") ?$"Task<" + returnType  + ">" : returnType;

            var methodHeader = $"{accessModifier} {returnType} {method.Name}(";
            
            // List<string> parameters = new List<string>();
            // foreach (var parameterInfo in method.GetParameters())
            // {
            //     var param     = "";
            //     var paramName = GenerateTypeString(parameterInfo.ParameterType);
            //     param += $"{paramName} {parameterInfo.Name}";
            //     if(parameterInfo.IsOut) param = "out " + param.Replace("&", "");
            //     if(parameterInfo.IsIn) param  = param.Replace("&", "");
            //
            //     parameters.Add(param);
            // }

            methodHeader += "string[] data";
            //methodHeader += string.Join(", ", parameters);
            methodHeader += ")";
            var methodString = "\t" + methodHeader + @"
        {



        }
" + "\t";
            
            File.AppendAllText(filePath, methodString);
        }


        var classReader = new ServerClassReader(filePath);
        var lines       = classReader.ReadFile(filePath);
        var methods     = classReader.GetMethods(lines);
        foreach (var (returnType, methodName, parameters, methodLines) in methods)
        {
            classReader.WriteMethod(returnType, methodName, parameters, methodLines);
        }


        File.AppendAllText(filePath, @"

        }");
        
        File.AppendAllText(filePath, @"

        }");


    } 

}