namespace Services.Contract;

public interface ILoggerService
{
    void LogInfo(string messageInfo);
    void LogWarn(string messageWarn);
    void LogError(string messageError);
    void LogDebug(string messageDebug);
}