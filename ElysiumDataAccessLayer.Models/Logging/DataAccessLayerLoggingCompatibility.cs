namespace RebirthStudios.DataAccessLayer
{
    // Preserve the original public API while callers migrate to RebirthStudios.Logging.
    public interface ILogger : RebirthStudios.Logging.ILogger
    {
    }

    public class Logger : RebirthStudios.Logging.Logger, ILogger
    {
    }
}
