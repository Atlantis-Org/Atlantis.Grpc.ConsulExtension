using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;
using Atlantis.Grpc;

namespace Atlantis.Grpc.Client.Services
{
    public class PersonServicer:IPersonServicer
    {
        public async Task<HelloMessageResult> HelloAsync(HelloMessage hellomessage)
        {
            var client=GrpcClientExtension.ClientDic["a0cae64f-0aad-4ba4-a0fd-1778097e33c9"];
return await client.CallAsync<HelloMessage,HelloMessageResult>(hellomessage, "Hello");

        }

    }
}
