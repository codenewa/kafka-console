using CodeNewa.Kafka;

using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace Producer
{
    public class Producer : IProducer
    {
        private readonly ILogger<Producer> _logger;
        private readonly IReadConfig _configReader;

        public Producer(ILogger<Producer> logger, IReadConfig configReader)
        {
            _logger = logger;
            _configReader = configReader;
        }

        public Task StartProducing()
        {
            var config =_configReader.ReadConfig()

            throw new NotImplementedException();
        }
    }
}
