namespace NetLogger;

public interface IMyLogger
{
    public void LogInformation(string message, string source);
    public void LogWarning(string message, string source);
    public void LogError(string message, string source);
    public void SetLogFolder();
}