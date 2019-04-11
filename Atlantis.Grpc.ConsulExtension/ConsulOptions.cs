using Atlantis.Consul;

namespace Atlantis.Grpc.ConsulExtension
{
    public class ConsulOptions:GrpcOptions
    {
        public string ServerName{get;set;}

        public string ConsulAddressUrl{get;set;}
    }
}
