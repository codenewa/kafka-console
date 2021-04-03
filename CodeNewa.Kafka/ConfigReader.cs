using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNewa.Kafka
{
    public class ConfigReader : IReadConfig
    {
        private readonly ILogger<ConfigReader> _logger;

        public ConfigReader(ILogger<ConfigReader> logger)
        {
            _logger = logger;
        }
        public async Task<IDictionary<string, string>> ReadConfig(string fileName)
        {
            try
            {
                var config = (await File.ReadAllLinesAsync(fileName))
                    .Where(line => !line.StartsWith("#"))
                    .ToDictionary(
                    line => line.Substring(0, line.IndexOf('=')),
                    line => line.Substring(line.IndexOf('=') + 1)
                    );
                return config;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Could not read kafka configuration from: {fileName}");
                System.Environment.Exit(1);
                return null;
            }
        }
    }
}
