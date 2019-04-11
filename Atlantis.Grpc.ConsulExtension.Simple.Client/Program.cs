using System;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;

namespace Atlantis.Grpc.ConsulExtension.Simple.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var options=new ConsulOptions()
            {
                NamespaceName="Atlantis.Simple",
                ServiceName="AtlantisService",
                ScanAssemblies=new string[]
                {
                    typeof(IPersonServicer).Assembly.FullName
                },
                ServerName="Atlantis.Test",
                ConsulAddressUrl="http://192.168.0.251:8500",
            };
            
            var client=new GrpcClientAgent(options);
            var servicer=client.GetService<IPersonServicer>();
            var message=new HelloMessage(){Name="DotNet"};
            var result=servicer.HelloAsync(message).Result;
            
            
            // var channel = new Channel("127.0.0.1", 3002, ChannelCredentials.Insecure);

            // channel.ConnectAsync().Wait();

            // AtlantisServiceClient client=new AtlantisServiceClient(channel);
            // 
            // var result= client.Hello(message);

            // // var serailizer=new ProtobufBinarySerializer();
            // // var s=serailizer.Serialize(message);

            // // foreach(var b in s)
            // // {
            // //     Console.Write($" {b}");
            // }
            Console.WriteLine(result.Result);
        }
    }
}
