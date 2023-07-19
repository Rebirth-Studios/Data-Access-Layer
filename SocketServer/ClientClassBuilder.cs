using System.Reflection;
using RebirthStudios.DataAccessLayer;

internal class ClientClassBuilder
{
    internal static void BuildRPCMethod()
    {
        var filePath    = @"E:\Users\logan\RiderProjects\SocketServer\DataAccessLayerClient\Client_DataTableStoredProcs.cs";
//File.WriteAllLines(filePath, File.ReadAllLines(templateFilePath));
        var templateData = @"using System.Net.Sockets;
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Threading;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using RebirthStudios.DataAccessLayer;
    using RebirthStudios.DataAccessLayer.Models;
    using RebirthStudios.Enums;
    using RebirthStudios.Enums.Items;

    public class Client_DataTableStoredProcs
    {
        public static Socket _socket;
        public static byte[] _buffer;
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        public static ILogger   _logger;
        public static bool   SOCKET_PROFILING_ENABLED = false;
        public static bool   SOCKET_DEBUGGING_ENABLED = false;
    ";

        File.WriteAllText(filePath, templateData);
        foreach (var method in typeof(DataTableStoredProcs).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic))
        {
            var accessModifier                  = method.IsPublic ? "public" : method.IsAssembly ? "internal" : "private";
            if(method.IsAssembly) continue;
            if(method.Name.StartsWith("set_")) continue;
            if(method.Name.StartsWith("get_")) continue;
            if (method.IsStatic) accessModifier += " static";

            var returnType = GenerateTypeString(method.ReturnType);
            //returnType = $"Task<" + returnType  + ">";
            //returnType = !returnType.Contains("void") ?$"Task<" + returnType  + ">" : returnType;

            var methodHeader = $"{accessModifier} {returnType} {method.Name}(";
            
            List<string> parameters = new List<string>();
            foreach (var parameterInfo in method.GetParameters())
            {
                var param     = "";
                var paramName = GenerateTypeString(parameterInfo.ParameterType);
                param += $"{paramName} {parameterInfo.Name}";
                if(parameterInfo.IsOut) param = "out " + param.Replace("&", "");
                if(parameterInfo.IsIn) param  = param.Replace("&", "");

                parameters.Add(param);
            }

            methodHeader += string.Join(", ", parameters);
            methodHeader += ")";
            var methodString = "\t" + methodHeader + @"
        {



        }
" + "\t";
            
            File.AppendAllText(filePath, methodString);
        }


        var classReader = new ClientClassReader(filePath);
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
    private static string GenerateTypeString(Type type)
{
    var returnType                      = "";
    var endReturnType                   = "";
    if (type.Name.Contains("List"))
    {
        returnType    += "List<";
        endReturnType += ">";
    }
    else if (type.Name.Contains("Dictionary"))
    {
        returnType    += "Dictionary<";
        endReturnType += ">";
    }
    else if (type.Name.Contains("Tuple"))
    {
        returnType    += "Tuple<";
        endReturnType += ">";
    }
    else if (type.Name.Contains("ValueTuple"))
    {
        returnType    += "ValueTuple<";
        endReturnType += ">";
    }
    else
    {
        if (type.Name == "Boolean")
        {
            returnType += "bool";
        }
        else if (type.Name == "Void")
        {
            returnType += "void";
        }
        else if (type.Name == "Byte")
        {
            returnType += "byte";
        }
        else if (type.Name == "String")
        {
            returnType += "string";
        }
        else if (type.Name == "Int64")
        {
            returnType += "long";
        }
        else if (type.Name == "Int32")
        {
            returnType += "int";
        }
        else if (type.Name == "Int16")
        {
            returnType += "short";
        } 
        else if (type.Name == "UInt64")
        {
            returnType += "ulong";
        }
        else if (type.Name == "UInt32")
        {
            returnType += "uint";
        }
        else if (type.Name == "UInt16")
        {
            returnType += "ushort";
        }
        else if (type.Name == "Single")
        {
            returnType += "float";
        }
        else if (type.Name == "Byte[]")
        {
            returnType += "byte[]";
        }
        else if (type.ToString().Contains("ValueCollection"))
        {
            returnType += "ValueCollection";
        }
        else returnType += type.Name;
    }

    for (int i = 0; i < type.GenericTypeArguments.Length; i++)
    {
        var t                                    = GenerateTypeString(type.GenericTypeArguments[i]);
     
        if (!returnType.EndsWith("<")) returnType += ",";
        returnType += t;
    }
    if (returnType.Contains("ValueCollection"))
    {
        var b = returnType.Split("ValueCollection, ")[1].Split(", ")[1];
        returnType = returnType.Replace("ValueCollection, ", "Dictionary<");
        returnType = returnType.Replace(b, $"{b}>.ValueCollection");
    }
    
    returnType += endReturnType;
    return returnType;
}

}