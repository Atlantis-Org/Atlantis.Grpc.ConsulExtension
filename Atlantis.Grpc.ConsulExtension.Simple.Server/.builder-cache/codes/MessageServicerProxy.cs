using System.Linq;
using System;
using System.Collections.Generic;
using Atlantis.Grpc.Utilies;
using System.Threading.Tasks;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;

namespace Atlantis.Grpc
{
    public class MessageServicerProxy:IMessageServicerProxy
    {
        public Func<TMessage,Task<TMessageResult>> GetHandleDelegate<TMessage,TMessageResult>(TMessage message)where TMessageResult: class where TMessage: BaseMessage
        {
            if(string.Equals(message.GetTypeFullName(),"Atlantis.Grpc.ConsulExtension.Simple.Protocol.HelloMessage"))
                               {
                                   return async (m)=>{return (await ObjectContainer.Resolve<IPersonServicer>().HelloAsync(message as Atlantis.Grpc.ConsulExtension.Simple.Protocol.HelloMessage)) as TMessageResult;} ;   
                               }
return null;
        }

        public Func<TMessage,Task> GetHandleDelegate<TMessage>(TMessage message)where TMessage: BaseMessage
        {
            return null;
        }

    }
}
