using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace Consumer
{
    public class Application
    {
        private readonly ILogger<Application> _logger;

        public Application(ILogger<Application> logger)
        {
            _logger = logger;
        }

        public async Task Start(params string[] args)
        {
            _logger.LogInformation("Starting Consumer");
            await Task.CompletedTask;
        }
    }
}
