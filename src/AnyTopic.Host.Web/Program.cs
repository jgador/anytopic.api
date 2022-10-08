// using AnyTopic.Api.Hosting;

namespace AnyTopic.Host.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "AnyTopic Web Host";

            // await AnyTopicApiHost.RunAsync<AspNetCoreApplicationHost>(args).ConfigureAwait(false);
        }
    }
}