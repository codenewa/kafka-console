using Confluent.Kafka;

using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace CodeNewa.Kafka
{
    public interface IProducerFactory<TKey, TEvent>
    {
        Task<IProducer<TKey, TEvent>> Build(string configFilePath);
    }

    public class ProducerFactory<TKey, TEvent> : IProducerFactory<TKey, TEvent>
    {
        private readonly ILogger<ProducerBuilder<TKey, TEvent>> _logger;
        private readonly IReadConfig _configReader;

        public ProducerFactory(ILogger<ProducerBuilder<TKey, TEvent>> logger, IReadConfig configReader)
        {
            _logger = logger;
            _configReader = configReader;
        }

        public async Task<IProducer<TKey, TEvent>> Build(string configFilePath)
        {
            var config = await _configReader.ReadConfig(configFilePath);

            return new ProducerBuilder<TKey, TEvent>(config).Build();
        }
    }

}
