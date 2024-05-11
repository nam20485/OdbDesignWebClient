using Odb.Client.Lib;
using Odb.Client.Lib.Services;

namespace OdbDesignConsoleClient
{
    internal class Program
    {
        private static readonly int _requestTimeoutInMinutes = 20;

        private static readonly IAuthenticationService _authService = new EnvironmentAuthService();

        private const int SECONDS_PER_MINUTE = 60;       

        public static int Main(string[] args)
        {
            Console.Write("OdbDesign Client");

            if (args.Length > 1)
            {
                if (!string.IsNullOrWhiteSpace(args[0]) &&
                    !string.IsNullOrWhiteSpace(args[1]))
                {
                    var apiUri = new Uri(args[0]);
                    var designName = args[1];

                    using var httpClient = new HttpClient()
                    {
                        BaseAddress = apiUri,
                        Timeout = TimeSpan.FromSeconds(_requestTimeoutInMinutes * SECONDS_PER_MINUTE)
                    };

                    Console.WriteLine($" - [Server: '{httpClient.BaseAddress}' (Timeout: {httpClient.Timeout})]");
                    Console.WriteLine();

                    var odbDesignClient = new OdbDesignHttpClient(httpClient, _authService);
                    
                    //var fileArchive = odbDesignClient.FetchFileArchive(designName);                
                    var design = odbDesignClient.FetchDesign(designName);

                    return 0;
                }
            }

            PrintUsage();
            return 1;
        }

       

        private static void PrintUsage()
        {
            Console.WriteLine("Invalid arguments...");
            Console.WriteLine();
            Console.WriteLine("Usage: OdbDesignClient <api-uri> <design-name>");
        }
    }
}
