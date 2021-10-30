using BlazorConfigurationFromAPI.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorConfigurationFromAPI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            HttpClient httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();
            builder.Configuration.AddJsonStream(await httpClient.GetStreamAsync("api/configuration"));

            builder.Services.AddScoped(serviceProvider =>
            {
                Tenant currentTenant = new Tenant();
                builder.Configuration.Bind(currentTenant);
                return currentTenant;
            });

            await builder.Build().RunAsync();
        }
    }
}
