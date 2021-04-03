using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace Producer
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IConfiguration _configuration;

        public Application(ILogger<Application> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task Start(params string[] args)
        {
            _logger.LogInformation("Starting Producer");
            await Task.CompletedTask;
        }
    }
}
