using BuildBase.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModularPipelines.Extensions;
using ModularPipelines.Host;

namespace BuildApi
{
    internal class Program
    {
        static async Task DoAsync()
        {
            await PipelineHostBuilder.Create().AddModule<MainModule>().ExecutePipelineAsync();
        }

        static void Main(string[] args)
        {
            DoAsync().Wait();
        }
    }
}
