using System.Reflection;
using Newtonsoft.Json;
using RebirthStudios.DataAccessLayer;
using RebirthStudios.DataAccessLayer.Models;

internal class ClientClassReader
{
    private string _filePath;
   
    public ClientClassReader(string filePath)
    {
        _filePath = filePath;
    }
    public string[] ReadFile(string path)
    {
        var lines = File.ReadAllLines(path).ToList();
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Replace("\n", "");
        }
        //lines = RemoveHeader(lines);

        return lines.ToArray();
    }

    public string[] RemoveHeader(string[] lines)
    {
        int i = 0;
        foreach (var line in lines)
        {
            if (line.Contains("class"))
            {
                return lines[i..^1];
            }
            i++;
        }
        return lines[2..^1];
    }
    
    public List<(string returnType, string methodName, string[] parameters, string[] lines)> GetMethods(string[] lines)
    {
        List<(string returnType, string methodName, string[] parameters, string[] lines)> methods = new List<(string returnType, string methodName, string[] parameters, string[] lines)>();
        lines = RemoveHeader(lines)[5..];
        int      startLine      = -1;
        int      lastLineIndex  = -1;
        string   methodName     = "";
        string   returnType     = "";
        int      timesStuck     = 0;
        var      stuckLastIndex = 0;
        string   header         = "";
        string[] parameters     = null;
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            //Console.WriteLine($"{i}, {line}");
           
            if(timesStuck > 1)
            {
                Console.WriteLine("STUCK");
            }
            
            if((line.Contains("public ") ||
                line.Contains("private ") || 
                line.Contains("internal ")) 
               && !line.Contains("class") && 
               line.Contains("(") && line.Contains(")"))
            {
                //Console.WriteLine("HEADER: " + line);
                //Console.WriteLine($"Startline: {startLine}");
                if (startLine != -1)
                {
                    string lastLine = lines[i - 1];
                    if (lastLine.TrimStart() == "")
                    {
                        lastLineIndex  = i - 1;
                        i--;
                        if (stuckLastIndex == i)
                        {
                            timesStuck++;
                        }
                        stuckLastIndex = i;
                    }
                    else
                    {
                        lastLineIndex = i - 1;
                        i--;
                        if (stuckLastIndex == i)
                        {
                            timesStuck++;
                        }
                        stuckLastIndex = i;
                    }

                    var last = lines[lastLineIndex];
                    //Console.WriteLine($"FOUND LAST LINE: {last}");
                }
                else
                {

                    bool async = false;
                    //Console.WriteLine(line);
                    var newLine = line.Replace("public ", "").Replace("private ", "").Replace("internal ", "");
                    newLine = newLine.Replace("static ", "").Replace("virtual ", "").Replace("override ", "").Replace("abstract ", "");
                    if(newLine.Contains("async "))
                    {
                        newLine = newLine.Replace("async ", "");
                        newLine = newLine.Replace("Task<", "");
                        async   = true;
                    };
                    newLine = newLine.TrimStart();
                    
                    var split      = newLine.Split("(")[0].Split(" ");
                    // Dictionary<byte, Dictionary<byte, List<CharacterCreationOption>>> Test 
                    //methodName = split[^1];
                    if(newLine.Split(" ").Contains("<")) methodName = newLine.Split(", ")[^1].Split(" ")[1].Split(")")[0];
                    else methodName = split[^1];
                    returnType = string.Join(" ", split[..^1]).Replace("}", "");
                    if (async) returnType = returnType[..^1];
                    header     = line;
               
                    parameters = newLine.Split("(")[1].Split(")")[0].Split(", ");
                    
                    //Console.WriteLine($"MethodName: {methodName}");
                    if(i != 0 && lines[i - 1].Contains("["))
                    {
                        var attribute = lines[i - 1];
                        //Console.WriteLine(attribute.TrimStart());
                        startLine = i - 1;
                    }
                    else startLine = i;
                }
                //Console.WriteLine($"Startline: {startLine}");
            }

          

            if(i == lines.Length - 1)
            {
                lastLineIndex = i+1;
            }
            
            if (lastLineIndex != -1 && methodName != "")
            {
                //Console.WriteLine(lastLineIndex);
                var data = (returnType, methodName, parameters, lines[startLine..lastLineIndex]);
                //Console.WriteLine(lines[lastLineIndex-1]);
                startLine     = -1;
                lastLineIndex = -1; 
                methods.Add(data);
            }
            
            
            
        }

        //throw new NotImplementedException();
        return methods;
    }
    
    public void WriteMethod(string returnType, string methodName, string[] parameters, string[] methodLines)
    {
        var logProfilingMesssage =  "_logger.LogProfiling(" + '$' + '"' + "logMethod took {stopwatch.ElapsedTicks/10000f}ms" + '"' + ");";
        var logDebugMesssage =  "_logger.LogDebug(" + '$' + '"' + "ClientSocket.logMethod({bytesReceived}): {stringValue}" + '"' + ");";
        var bufferToSmallMessage =  "_logger.LogError(" + '$' + '"' + $"ClientSocket.{methodName}: Buffer too small. {{bytesReceived}} bytes received." + '"' + ");";
        //Console.WriteLine($"WriteMethod: {methodName}");

        var endMessage = "|EOL|";
    var basicSocketSetup = @"
            try
                {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
                
                var requestBytes = Encoding.ASCII.GetBytes(methodName + " + '"' + endMessage + '"' + @");
                
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
                    {
                    " + bufferToSmallMessage + @"
                    }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) " + logDebugMesssage + @"  
                var json = JsonConvert.DeserializeObject<T>(stringValue)!;
                
                if(SOCKET_PROFILING_ENABLED) " + logProfilingMesssage + @"
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 
                
                return json;
            }
            catch(SocketException e)
            {
                _logger.LogException(e);
                return default!;
            }
";


List<string> newMethodData = new List<string>
{
    methodLines[0],
    methodLines[1],
    methodLines[2]
};
//var methodInfo = typeof(Client_DataTableStoredProcs)!.GetMethod($"{methodName}", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
//var parameters = methodInfo.GetParameters();
var trueReturnType   = returnType.Contains("Task") ? returnType.Replace("Task<", "")[..^1] : returnType;
string      conversionMethod = $"<" + trueReturnType  + ">";

var sendData = '$' + ('"' + $"{methodName}|");
for (int j = 0; j < parameters.Length; j++)
{
    var split                                = parameters[j].Split(" ");
    if(split.Length <= 1) continue;
    if(methodName.Contains("Overwrite")) Console.WriteLine(split[0]);
    if (split[0].Contains("ValueCollection") || split[0].Contains("Dictionary") || split[0].Contains("List") || split[0].Contains("byte[]", StringComparison.OrdinalIgnoreCase))
    {
        if (j == parameters.Length - 1) sendData += "{" + $"JsonConvert.SerializeObject({split[1]})" + "}";
        else sendData                            += "{" + $"JsonConvert.SerializeObject({split[1]})" + "}" + "|";  
    }
    else
    {
        if (j == parameters.Length - 1) sendData += "{" + $"{split[1]}" + "}";
        else sendData                            += "{" + $"{split[1]}" + "}" + "|";
    }
}
sendData += '"';
basicSocketSetup = basicSocketSetup.Replace("methodName", sendData);
basicSocketSetup = basicSocketSetup.Replace("logMethod", methodName);
if (returnType.Contains("voi"))
{
    Console.WriteLine(returnType);
    basicSocketSetup = basicSocketSetup.Replace(
        @$"int bytesReceived = 0;
            bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
            if (bytesReceived >= _buffer.Length)
                    {
                    " + bufferToSmallMessage + @"
                    }
            var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);", "");
    basicSocketSetup = basicSocketSetup.Replace(@$"if(SOCKET_DEBUGGING_ENABLED)", "");
    basicSocketSetup = basicSocketSetup.Replace(logDebugMesssage.Replace("logMethod", methodName), "");
    basicSocketSetup = basicSocketSetup.Replace(@"var json = JsonConvert.DeserializeObject<T>(stringValue)!;", "");
    basicSocketSetup = basicSocketSetup.Replace(@"            stopwatch.Stop();   ", "");
    basicSocketSetup = basicSocketSetup.Replace(@"            return json;", "");
    basicSocketSetup = basicSocketSetup.Replace(@"            return default!;", "");
}
else if (false)
    basicSocketSetup = returnType switch
    {
        "bool" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToBool();"),
        "int" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToInt32();"),
        "string" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return Encoding.UTF8.GetString(_buffer[0..bytesReceived]);"),
        "byte[]" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived];"),
        "byte" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0];"),
        "float" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToFloat();"),
        "double" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToDouble();"),
        "long" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToInt64();"),
        "short" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToInt16();"),
        "ushort" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToUInt16();"),
        "uint" => basicSocketSetup.Replace(
            "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
            "return _buffer[0..bytesReceived].ToUInt32();"),
        _ => basicSocketSetup.Replace(@"<T>", conversionMethod)
    };
else basicSocketSetup = basicSocketSetup.Replace(@"<T>", conversionMethod);


foreach(var line in ("\t" + "\t" + basicSocketSetup).Split("\n"))
{
    newMethodData.Add(line);
}

newMethodData.Add(methodLines[2].Replace("{", "}"));

//Console.WriteLine(string.Join("\n", methodLines));

var data = string.Join("\n", newMethodData);
//Console.WriteLine(basicSocketSetup.Split("\n").Length);
//var fileStream = File.Open(filePath, FileMode.Append);
//fileStream.Write(Encoding.ASCII.GetBytes(data));
var allData = File.ReadAllLines(_filePath);
//Console.WriteLine(allData);

//Console.WriteLine(string.Join("\n", methodLines));
int i = 0;
foreach (var line in allData)
{
    foreach (var newLine in methodLines)
    {
        if(line.Trim().Equals(newLine.Trim(), StringComparison.InvariantCultureIgnoreCase))
        {
            allData[i] = newLine;
            //Console.WriteLine($"Found match at line {i}");
        }
    }

    i++;
}

var contains = string.Join("\n", allData).Contains(string.Join("\n", methodLines));
//if(methodName.Contains("SpawnerLocations")) Console.WriteLine($"{methodName} == {contains}");
if(contains) File.WriteAllText(_filePath,string.Join("\n", allData).Replace(string.Join("\n", methodLines), data));
// Attribute
// Header
// {
// DATA
// } 

}

}