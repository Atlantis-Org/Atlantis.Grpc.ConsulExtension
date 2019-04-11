using System;
using Atlantis.Consul;
using Atlantis.Grpc.ConsulExtension.Simple.Protocol;
using Atlantis.Grpc.Utilies;

namespace Atlantis.Grpc.ConsulExtension.Simple.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            var options=new GrpcServerOptions()
            {
                Host="127.0.0.1",
                Port=3002,
                NamespaceName="Atlantis.Simple",
                PackageName="Atlantis.Simple",
                ServiceName="AtlantisService",
                ScanAssemblies=new string[]
                {
                    typeof(IPersonServicer).Assembly.FullName
                }
            };

            var consulSetting=new ConsulSettingOptions()
            {
                ConsulAddressUrl="http://192.168.0.251:8500"
            };
            var serviceOptions=new ConsulServiceOptions()
            {
                ServiceName="Atlantis.Test",
                Address="127.0.0.1",
                Port=3002,
                TTL=1000
            };
            
            var consulManager=new ConsulManager()
                .Init(consulSetting)
                .WithServiceOptions(serviceOptions);

            consulManager.Service.RegisteAsync().Wait();
            
            //GrpcConfiguration.LoggerFactory=new Loggerfac();

            var server=new GrpcServer(options);
            ObjectContainer.Register<IPersonServicer,PersonServicer>(LifeScope.Single);
            server.Start();

            Console.WriteLine("Server is running...");
            Console.ReadLine();

        }
    }
}
