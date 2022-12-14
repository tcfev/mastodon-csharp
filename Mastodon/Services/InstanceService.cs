using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services
{
    public class MastodonService : Mastodon.Grpc.Mastodon.MastodonBase
    {
        private readonly MastodonClient _mastodon;
        private readonly ILogger<MastodonService> _logger;
        public MastodonService(ILogger<MastodonService> logger, MastodonClient mastodon)
        {
            _logger = logger;
            _mastodon = mastodon;
        }

        public override async Task<Grpc.Instance> GetInstance(Empty request, ServerCallContext context)
        {
            var instance = (await _mastodon.Instance.GetInstanceAsync())!;

            instance.Domain = context.GetHttpContext().Request.Host.Value;

            return instance.ToGrpc();
        }

        public override async Task<Rules> GetRules(Empty request, ServerCallContext context)
        {
            var result = (await _mastodon.Instance.GetRulesAsync());

            var rules = new Rules();

            if (result != null)
            {
                foreach (var rule in result)
                {
                    var r = new Rule
                    {
                        Id = rule.Id,
                        Text = rule.Text,
                    };

                    rules.Data.Add(r);
                }
            }


            return rules;
        }

        public override async Task<Grpc.Statuses> GetPublicTimeline(Empty request, ServerCallContext context)
        {
            var result = (await _mastodon.Timeline.GetPublicAsync());

            var statuses = new Grpc.Statuses();

            if (result != null)
            {
                foreach (var r in result)
                {
                    statuses.Data.Add(r.ToGrpc());
                }
            }


            return statuses;
        }
    }
}