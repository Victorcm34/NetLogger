namespace NetLogger;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMyLogger _myLogger;

    public Worker(ILogger<Worker> logger, IMyLogger myLogger)
    {
        _logger = logger;
        _myLogger = myLogger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Creating directory");
        _myLogger.SetLogFolder();

        while (!stoppingToken.IsCancellationRequested)
        {
            _myLogger.LogError($"Worker running at: {DateTimeOffset.Now}", "NetLogger");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
