using System;

namespace RebirthStudios.DataAccessLayer;

public interface ILogger
{
    public void Log(string message);
    public void LogProfiling(string message);
    public void LogDebug(string message);
    public void LogWarning(string message);
    public void LogError(string message);
    public void LogException(Exception e);
}