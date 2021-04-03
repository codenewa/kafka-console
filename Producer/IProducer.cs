using System.Threading.Tasks;

namespace Producer
{
    public interface IProducer
    {
        Task StartProducing();
    }
}
