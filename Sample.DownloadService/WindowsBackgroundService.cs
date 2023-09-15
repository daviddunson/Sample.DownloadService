namespace Sample.DownloadService;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly JokeService _jokeService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(
        JokeService jokeService,
        ILogger<WindowsBackgroundService> logger) =>
        (this._jokeService, this._logger) = (jokeService, logger);

    // Example from: https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Sample", "DownloadService", "Runtime");
            var path = Path.Combine(directory, "download.log");
            string joke = this._jokeService.GetJoke();

            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllTextAsync(path, joke, stoppingToken);
                this._logger.LogWarning($"Successfully updated {path}");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Unable to write to {path}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
