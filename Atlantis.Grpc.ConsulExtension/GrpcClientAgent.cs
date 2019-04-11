using System.Threading.Tasks;
using Atlantis.Consul;
using Grpc.Core;

namespace Atlantis.Grpc.ConsulExtension
{
    public class GrpcClientAgent : GrpcClient
    {
        private CallInvoker _invoker;
        private Channel _channel;
        private readonly ConsulManager _consulManager;
        private readonly ConsulOptions _options;

        public GrpcClientAgent(ConsulOptions options) : base(options)
        {
            _options = options;
            var consulSettintOptions=new ConsulSettingOptions()
            {
                ConsulAddressUrl=options.ConsulAddressUrl
            };
            _consulManager = new ConsulManager();
            _consulManager.Init(consulSettintOptions);
        }

        protected override async Task<CallInvoker> GetInvokerAsync()
        {
            if (_invoker == null ||
               _channel == null ||
               _channel.State != ChannelState.Ready)
            {
                _invoker = await UpdateInvokerAsync();
            }
            return _invoker;
        }

        private async Task<CallInvoker> UpdateInvokerAsync()
        {
            var service = await _consulManager.Service
                .GetService(_options.ServerName);
            if (_channel != null)
            {
                await _channel.ShutdownAsync();
            }
            _channel = new Channel(
                service.Address, service.Port, ChannelCredentials.Insecure);
            return new DefaultCallInvoker(_channel);
        }

    }
}
