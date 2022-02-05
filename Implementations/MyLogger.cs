namespace NetLogger;

public class MyLogger : IMyLogger
{
    private readonly IConfiguration _config;

    public MyLogger(IConfiguration config)
    {
        _config = config;
    }
    public void LogError(string message, string source)
    {
        var path = SetLogFile(source);
        WriteMessage(message, path, "Error");

        if (Convert.ToBoolean(_config["Settings:NotifyError"]))
        {
            SendNotification(source, message);
        }
    }

    public void LogInformation(string message, string source)
    {
        var path = SetLogFile(source);
        WriteMessage(message, path, "Information");
    }

    public void LogWarning(string message, string source)
    {
        var path = SetLogFile(source);
        WriteMessage(message, path, "Warning");
    }

    public void SetLogFolder()
    {
        if (!Directory.Exists(_config["Settings:RootFolder"]))
        {
            Directory.CreateDirectory(_config["Settings:RootFolder"]);
        }
    }

    private string SetLogFile(string name)
    {
        var path = $"{_config["Settings:RootFolder"]}/{name}.log";
        if (!File.Exists(path))
        {
            var file = File.Create(path);
            file.Close();
        }
        return path;
    }

    private void WriteMessage(string message, string path, string status)
    {
        try
        {
            // using StreamWriter sw = new(path, append: true);
            // await sw.WriteLineAsync($"{DateTime.Now} - {status} - {message}");
            // sw.Close();
            File.AppendAllLines(path, new string[]{$"{DateTime.Now} - {status} - {message}"});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void SendNotification(string source, string message)
    {
        Console.WriteLine(message);
    }
}
