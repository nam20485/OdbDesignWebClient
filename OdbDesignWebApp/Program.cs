using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

using Odb.Client.Lib;
using Odb.Client.Lib.Services;

namespace OdbDesignWebApp
{
    public class Program
    {
        private static string _apiUrl;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            if (builder.Configuration["ApiUrl"] is string apiUrl &&
                Uri.IsWellFormedUriString(apiUrl, UriKind.Absolute))
            {
                _apiUrl = apiUrl;
            }
            else
            {
                throw new Exception("Invalid API URL (ensure \"ApiUrl\" is set in appsettings");
            }

            builder.Services.AddHttpClient<OdbDesignHttpClient>(client => client.BaseAddress = new Uri(_apiUrl));
            builder.Services.AddSingleton<IOdbDesignClientService, OdbDesignClientService>();

            // JS Interop
            builder.Services.AddSingleton(sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());

            await builder.Build().RunAsync();
        }
    }
}
