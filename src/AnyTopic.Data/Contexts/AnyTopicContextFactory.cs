using AnyTopic.Data.Configuration;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AnyTopic.Data.Contexts
{
    public class AnyTopicContextFactory : IDbContextFactory<AnyTopicContext>
    {
        private readonly AnyTopicContextOptions _options;

        public AnyTopicContextFactory(IOptionsMonitor<AnyTopicContextOptions> options)
        {
            EnsureArg.IsNotNull(options, nameof(options));
            EnsureArg.IsNotNull(options.CurrentValue, nameof(options));

            _options = options!.CurrentValue;
        }

        public AnyTopicContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnyTopicContext>();
            optionsBuilder.UseSqlServer(_options.ConnectionString!);

            return new(optionsBuilder.Options);
        }
    }
}
