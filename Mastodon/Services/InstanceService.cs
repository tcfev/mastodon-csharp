using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Service.Services
{
    public class InstnaceService : Instance.InstanceBase
    {
        private readonly MastodonClient _mastodon;
        private readonly ILogger<InstnaceService> _logger;
        public InstnaceService(ILogger<InstnaceService> logger, MastodonClient mastodon)
        {
            _logger = logger;
            _mastodon = mastodon;
        }

        public override async Task<Grpc.InstanceData> GetInstnace(Empty request, ServerCallContext context)
        {
            var instance = (await _mastodon.Instance.GetInstanceAsync())!;

            return new Grpc.InstanceData
            {
                Description = instance.Description,
            };
        }
    }
}