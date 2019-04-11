using System.Threading.Tasks;
using Atlantis.Grpc.Utilies;

namespace Atlantis.Grpc.ConsulExtension.Simple.Protocol
{
    public interface IPersonServicer:IMessagingServicer
    {
        Task<HelloMessageResult> HelloAsync(HelloMessage message);
    }
}
