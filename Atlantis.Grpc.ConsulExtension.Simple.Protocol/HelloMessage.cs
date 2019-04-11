using Atlantis.Grpc.Utilies;
using ProtoBuf;

namespace Atlantis.Grpc.ConsulExtension.Simple.Protocol
{
    [ProtoContract(ImplicitFields=ImplicitFields.AllPublic)]
    public class HelloMessage:BaseMessage
    {
        public string Name{get;set;}
    }

    [ProtoContract(ImplicitFields=ImplicitFields.AllPublic)]
    public class HelloMessageResult:GrpcMessageResult
    {
        public string Result{get;set;}
    }
}
