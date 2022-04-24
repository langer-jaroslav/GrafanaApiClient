namespace GrafanaApiClient.Example
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IGrafanaControlService _grafanaControlService;

        public Worker(ILogger<Worker> logger, 
            IGrafanaControlService grafanaControlService)
        {
            _logger = logger;
            _grafanaControlService = grafanaControlService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var folders = await _grafanaControlService.FolderGetListAsync(null);

                Console.WriteLine($"Folders found ({folders.Count}):");
                foreach (var folder in folders)
                {
                    Console.WriteLine(folder.Title);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}