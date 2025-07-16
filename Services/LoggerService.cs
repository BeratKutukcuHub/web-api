using NLog;
using Services.Contract;

namespace Services;

public class LoggerService : ILoggerService
{
    private static ILogger _logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string messageDebug) => _logger.Debug(messageDebug);
    public void LogError(string messageError) => _logger.Error(messageError);
    public void LogInfo(string messageInfo) => _logger.Info(messageInfo);
    public void LogWarn(string messageWarn) => _logger.Warn(messageWarn);
   
}
