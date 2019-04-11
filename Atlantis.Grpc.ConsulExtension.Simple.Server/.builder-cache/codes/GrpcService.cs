using System.Linq;
using System;
using System.Collections.Generic;
using Grpc.Core;
using System.Threading.Tasks;
using Atlantis.Grpc.Utilies;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;

namespace Atlantis.Grpc
{
    public class GrpcService:IGrpcServices
    {
         IBinarySerializer _binarySerializer;
         GrpcMessageServicer _messageServicer;
        public GrpcService()
        {
            _binarySerializer=ObjectContainer.Resolve<IBinarySerializer>();
_messageServicer=new GrpcMessageServicer();
        }

        public async Task<HelloMessageResult> Hello(HelloMessage request,ServerCallContext context)
        {
            request.SetTypeFullName("Atlantis.Grpc.ConsulExtension.Simple.Protocol.HelloMessage");
                            return await _messageServicer.ProcessAsync<HelloMessage,HelloMessageResult>(request,context);

        }

        public ServerServiceDefinition BindServices()
        {
            return ServerServiceDefinition.CreateBuilder()
.AddMethod(new Method<HelloMessage,HelloMessageResult>(
                                            MethodType.Unary,
                                            "Atlantis.Simple.AtlantisService",
                                            "Hello",
                                            new Marshaller<HelloMessage>(
                                                _binarySerializer.Serialize,
                                                _binarySerializer.Deserialize<HelloMessage>
                                            ),
                                            new Marshaller<HelloMessageResult>(
                                                _binarySerializer.Serialize,
                                                _binarySerializer.Deserialize<HelloMessageResult>)
                                            ),
                                        Hello)
.Build();

        }

    }
}
