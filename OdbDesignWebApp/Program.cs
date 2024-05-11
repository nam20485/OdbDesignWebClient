using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

using Odb.Client.Lib;
using Odb.Client.Lib.Services;

using Utils.Interop;

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
                throw new Exception("Invalid API URL (is \"ApiUrl\" set in appsettings?");
            }

            builder.Services.AddHttpClient<OdbDesignHttpClient>(client => client.BaseAddress = new Uri(_apiUrl));
            builder.Services.AddSingleton(sp => sp.GetRequiredService<IJSRuntime>() as IJSInProcessRuntime);  // JS Interop
            builder.Services.AddSingleton<IJsInteropProvider, JsInteropProvider>();
            builder.Services.AddSingleton<ILocalStorageProvider, JsLocalStorageProvider>();
            builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();   
            builder.Services.AddSingleton<IAuthenticationService, LocalStorageAuthService>();                     
            builder.Services.AddSingleton<IOdbDesignClientService, OdbDesignClientService>();            

            await builder.Build().RunAsync();
        }
    }
}
