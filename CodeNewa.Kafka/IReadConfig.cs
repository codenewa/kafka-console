using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeNewa.Kafka
{
    public interface IReadConfig
    {
        Task<IDictionary<string, string>> ReadConfig(string fileName);
    }
}
