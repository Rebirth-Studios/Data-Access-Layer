using System.Collections;
using System.Reflection;
using RebirthStudios.DataAccessLayer;
using RebirthStudios.DataAccessLayer.Models;

internal class ServerClassReader
{
    private string _filePath;

    public ServerClassReader(string filePath)
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
        List<(string returnType, string methodName, string[] parameters, string[] lines)> methods =
            new List<(string returnType, string methodName, string[] parameters, string[] lines)>();
        lines = RemoveHeader(lines)[3..];
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

            if (timesStuck > 1)
            {
                Console.WriteLine("STUCK");
            }

            if ((line.Contains("public ")  ||
                 line.Contains("private ") ||
                 line.Contains("internal "))
                && !line.Contains("class") &&
                line.Contains("(")         && line.Contains(")"))
            {
                //Console.WriteLine("HEADER: " + line);
                //Console.WriteLine($"Startline: {startLine}");
                if (startLine != -1)
                {
                    string lastLine = lines[i - 1];
                    if (lastLine.TrimStart() == "")
                    {
                        lastLineIndex = i - 1;
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
                    newLine = newLine.Replace("static ", "").Replace("virtual ", "").Replace("override ", "")
                        .Replace("abstract ", "");
                    if (newLine.Contains("async "))
                    {
                        newLine = newLine.Replace("async ", "");
                        newLine = newLine.Replace("Task<", "");
                        async   = true;
                    }

                    ;
                    newLine = newLine.TrimStart();

                    var split = newLine.Split("(")[0].Split(" ");
                    // Dictionary<byte, Dictionary<byte, List<CharacterCreationOption>>> Test 
                    //methodName = split[^1];
                    if (newLine.Split(" ").Contains("<"))
                        methodName  = newLine.Split(", ")[^1].Split(" ")[1].Split(")")[0];
                    else methodName = split[^1];
                    returnType = string.Join(" ", split[..^1]).Replace("}", "");
                    if (async) returnType = returnType[..^1];
                    header = line;

                    parameters = newLine.Split("(")[1].Split(")")[0].Split(", ");

                    //Console.WriteLine($"MethodName: {methodName}");
                    if (i != 0 && lines[i - 1].Contains("["))
                    {
                        var attribute = lines[i - 1];
                        //Console.WriteLine(attribute.TrimStart());
                        startLine = i - 1;
                    }
                    else startLine = i;
                }
                //Console.WriteLine($"Startline: {startLine}");
            }



            if (i == lines.Length - 1)
            {
                lastLineIndex = i + 1;
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
        //Console.WriteLine($"WriteMethod: {methodName}");
        //File.ReadAllLines()
        var        parameterString = string.Join(", ", parameters);
        MethodInfo foundMethod = null;
        foreach (var method in typeof(DataTableStoredProcs).GetMethods(BindingFlags.Public | BindingFlags.Static))
        {
            if (method.Name == methodName)
            {
                foundMethod = method;
                break;
            }
        }

        var parameterTypes = foundMethod!.GetParameters();

        string paramString = "";
        for (int j = 0; j < parameterTypes.Length; j++)
        {
            var paramType = parameterTypes[j].ParameterType;
            if (paramType == typeof(byte))
            {
                if (j != parameterTypes.Length - 1) paramString += $"byte.Parse(data[{j}]), ";
                else paramString                                += $"byte.Parse(data[{j}])";
            }
            else if (paramType == typeof(bool))
            {
                if (j != parameterTypes.Length - 1) paramString += $"bool.Parse(data[{j}]), ";
                else paramString                                += $"bool.Parse(data[{j}])";
            }
            else if (paramType == typeof(short))
            {
                if (j != parameterTypes.Length - 1) paramString += $"short.Parse(data[{j}]), ";
                else paramString                                += $"short.Parse(data[{j}])";
            }
            else if (paramType == typeof(long))
            {
                if (j != parameterTypes.Length - 1) paramString += $"long.Parse(data[{j}]), ";
                else paramString                                += $"long.Parse(data[{j}])";
            }
            else if (paramType == typeof(ushort))
            {
                if (j != parameterTypes.Length - 1) paramString += $"ushort.Parse(data[{j}]), ";
                else paramString                                += $"ushort.Parse(data[{j}])";
            }
            else if (paramType == typeof(uint))
            {
                if (j != parameterTypes.Length - 1) paramString += $"uint.Parse(data[{j}]), ";
                else paramString                                += $"uint.Parse(data[{j}])";
            }
            else if (paramType == typeof(ulong))
            {
                if (j != parameterTypes.Length - 1) paramString += $"ulong.Parse(data[{j}]), ";
                else paramString                                += $"ulong.Parse(data[{j}])";
            }
            else if (paramType == typeof(int))
            {
                if (j != parameterTypes.Length - 1) paramString += $"int.Parse(data[{j}]), ";
                else paramString                                += $"int.Parse(data[{j}])";
            }
            else if (paramType == typeof(float))
            {
                if (j != parameterTypes.Length - 1) paramString += $"float.Parse(data[{j}]), ";
                else paramString                                += $"float.Parse(data[{j}])";
            }
            else if (paramType == typeof(double))
            {
                if (j != parameterTypes.Length - 1) paramString += $"double.Parse(data[{j}]), ";
                else paramString                                += $"double.Parse(data[{j}])";
            }
            else if (paramType == typeof(decimal))
            {
                if (j != parameterTypes.Length - 1) paramString += $"decimal.Parse(data[{j}]), ";
                else paramString                                += $"decimal.Parse(data[{j}])";
            }
            else if (paramType == typeof(string))
            {
                if (j != parameterTypes.Length - 1) paramString += $"data[{j}], ";
                else paramString                                += $"data[{j}]";
            }
            else if (paramType.Name == "Guid&")
            {
                if (j != parameterTypes.Length - 1) paramString += $"Guid.Parse(data[{j}]), ";
                else paramString                                += $"Guid.Parse(data[{j}])";
            }
            else if (paramType.Name == "Guid")
            {
                if (j != parameterTypes.Length - 1) paramString += $"Guid.Parse(data[{j}]), ";
                else paramString                                += $"Guid.Parse(data[{j}])";
            }
            // else if (paramType.Name == "DateTime")
            // {
            //     if (j != parameterTypes.Length - 1) paramString += $"DateTime.Parse(data[{j}]), ";
            //     else paramString                                += $"DateTime.Parse(data[{j}])";
            // }
            else if (paramType == typeof(byte[]))
            {
                if (j != parameterTypes.Length - 1) paramString += $"JsonConvert.DeserializeObject<byte[]>(data[{j}]), ";
                else paramString                                += $"JsonConvert.DeserializeObject<byte[]>(data[{j}])";
            }
            else if (paramType.IsGenericType)
            {
                if (j != parameterTypes.Length - 1) paramString += $"JsonConvert.DeserializeObject<{GenerateTypeString(paramType)}>(data[{j}]), ";
                else paramString                                += $"JsonConvert.DeserializeObject<{GenerateTypeString(paramType)}>(data[{j}])";            }
            else
            {
                throw new NotImplementedException($"Param Type {paramType} is not supported for {methodName}");
            }
        }

        var logMesssage =  "_logger.LogProfiling(" + '$' + '"' + "ServerSocket.logMethod took {stopwatch.ElapsedTicks/10000f}ms" + '"' + ");";
       logMesssage = logMesssage.Replace("logMethod", methodName);
       
       var basicSocketSetup = $@"
            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            ";
        if (foundMethod.ReturnType.Name != "Void")
        {
            basicSocketSetup += "var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(";
        }
        basicSocketSetup += $" DataTableStoredProcs.{methodName}("                  + paramString + ")";

        if (foundMethod.ReturnType.Name != "Void")
        {
            basicSocketSetup += "))";
        }
        basicSocketSetup += ";";

        basicSocketSetup += $@"
            if(SOCKET_PROFILING_ENABLED) {logMesssage}
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          
            
            return bytes;";
        
        if (foundMethod.ReturnType.Name == "Void")
        {
            basicSocketSetup = basicSocketSetup.Replace("return bytes;", "");
            basicSocketSetup += @"
            return null;";
        }

        List<string> newMethodData = new List<string>
            {
                methodLines[0],
                methodLines[1],
                methodLines[2]
            };
//var methodInfo = typeof(Client_DataTableStoredProcs)!.GetMethod($"{methodName}", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
//var parameters = methodInfo.GetParameters();
            var    trueReturnType   = returnType.Contains("Task") ? returnType.Replace("Task<", "")[..^1] : returnType;
            string conversionMethod = $"<" + trueReturnType + ">";

            var sendData = '$' + ('"' + $"{methodName}|");
            for (int j = 0; j < parameters.Length; j++)
            {
                var split = parameters[j].Split(" ");
                if (split.Length <= 1) continue;
                if (j == parameters.Length - 1) sendData += "{" + $"{split[1]}" + "}";
                else sendData                            += "{" + $"{split[1]}" + "}" + "|";
            }

            sendData         += '"';
            basicSocketSetup =  basicSocketSetup.Replace("methodName", sendData);
            if (returnType.Contains("voi"))
            {
                //Console.WriteLine(returnType);
                basicSocketSetup = basicSocketSetup.Replace(
                    @"
        int bytesReceived = await _socket.ReceiveAsync(_buffer, SocketFlags.None);
        return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    @"");
            }
            else if (returnType == "bool")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToBool();");
            }
            else if (returnType == "int")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToInt32();");
            }
            else if (returnType == "string")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return Encoding.UTF8.GetString(_buffer[0..bytesReceived]);");
            }
            else if (returnType == "byte[]")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived];");
            }
            else if (returnType == "byte")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0];");
            }
            else if (returnType == "float")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToFloat();");
            }
            else if (returnType == "double")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToDouble();");
            }
            else if (returnType == "long")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToInt64();");
            }
            else if (returnType == "short")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToInt16();");
            }
            else if (returnType == "ushort")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToUInt16();");
            }
            else if (returnType == "uint")
            {
                basicSocketSetup = basicSocketSetup.Replace(
                    "return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(_buffer[0..bytesReceived]))!;",
                    "return _buffer[0..bytesReceived].ToUInt32();");
            }
            else basicSocketSetup = basicSocketSetup.Replace(@"<T>", conversionMethod);

            foreach (var line in ("\t" + "\t" + basicSocketSetup).Split("\n"))
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
                    if (line.Trim().Equals(newLine.Trim(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        allData[i] = newLine;
                        //Console.WriteLine($"Found match at line {i}");
                    }
                }

                i++;
            }

            var contains = string.Join("\n", allData).Contains(string.Join("\n", methodLines));
//if(methodName.Contains("SpawnerLocations")) Console.WriteLine($"{methodName} == {contains}");
            if (contains)
                File.WriteAllText(_filePath, string.Join("\n", allData).Replace(string.Join("\n", methodLines), data));
// Attribute
// Header
// {
// DATA
// } 

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
        else if (type.Name == "Single")
        {
            returnType += "float";
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
     
        if (!returnType.EndsWith("<")) returnType += ", ";
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