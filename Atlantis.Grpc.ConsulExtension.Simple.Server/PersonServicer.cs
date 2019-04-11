using System.Threading.Tasks;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;

namespace Atlantis.Grpc.ConsulExtension.Simple.Server
{
    public class PersonServicer : IPersonServicer
    {
        public Task<HelloMessageResult> HelloAsync(HelloMessage message)
        {
            return Task.FromResult(new HelloMessageResult(){Result=$"Hello {message.Name}"});
        }
    }
}
