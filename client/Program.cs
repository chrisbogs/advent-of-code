using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AdventOfCodeShared.Logic;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Configure services
            ConfigureServices(builder.Services, builder.Configuration);

            // Build and run
            var host = builder.Build();

            // Configure HTTP client base address
            var httpClient = host.Services.GetRequiredService<HttpClient>();
            var config = host.Services.GetRequiredService<IConfiguration>();
            var serverUrl = config["ServerUrl"] ?? "http://localhost:8885";
            httpClient.BaseAddress = new Uri(serverUrl);

            await host.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // HTTP Client
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(configuration["ServerUrl"] ?? "http://localhost:8885")
            });

            // Application services
            services.AddScoped<ApiService>();

            // Logging
            services.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Information);
#if DEBUG
                logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);
#endif
            });
        }
    }
}
