using EnsureThat;
using Microsoft.Extensions.Logging;

namespace AnyTopic.Api.Logging
{
    public static class AnyTopicLoggerFactory
    {
        private static ILoggerFactory? _loggerFactory = null;

        internal static void Initialize(ILoggerFactory loggerFactory)
        {
            EnsureArg.IsNotNull(loggerFactory, nameof(loggerFactory));

            _loggerFactory = loggerFactory;
        }

        public static ILogger<T> CreateLogger<T>() => _loggerFactory!.CreateLogger<T>();

        public static ILogger CreateLogger(string categoryName) => _loggerFactory!.CreateLogger(categoryName);
    }
}
