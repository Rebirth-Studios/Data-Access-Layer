using System;

namespace RebirthStudios.DataAccessLayer;

public class Logger : ILogger
{
    public Action<string> LogMethod { get; set; }
    public Action<string> LogProfilingMethod { get; set; }
    public Action<string> LogDebugMethod { get; set; }
    public Action<string> LogWarningMethod { get; set; }
    public Action<string> LogErrorMethod { get; set; }
    public Action<Exception> LogExceptionMethod { get; set; }
        
    public void Log(string message)
    {
        LogMethod.Invoke(message);
    }
    public void LogProfiling(string message)
    {
        LogProfilingMethod.Invoke(message);
    } 
    public void LogDebug(string message)
    {
        LogDebugMethod.Invoke(message);
    }

    public void LogWarning(string      message)
    {
        LogWarningMethod.Invoke(message);
    }

    public void LogError(string        message)
    {
        LogErrorMethod.Invoke(message);
    }

    public void LogException(Exception e)
    {
        LogExceptionMethod.Invoke(e);
    }
}