using Odb.Client.Lib;
using Odb.Client.Lib.Services;

using Utils;
using Utils.Logging;

namespace OdbDesignConsoleClient
{
    internal class Program
    {
        private static readonly int _requestTimeoutInMinutes = 20;

        private static readonly IAuthenticationService _authService = new EnvironmentAuthService();

        private const int SECONDS_PER_MINUTE = 60;       

        public static int Main(string[] args)
        {
            ExitCode exitCode = ExitCode.UnknownError;

            try
            {

                Logger.Start(LoggerBase.Level.Info);

                Logger.Info("OdbDesign Client");

                if (args.Length > 1)
                {
                    if (!string.IsNullOrWhiteSpace(args[0]) &&
                        !string.IsNullOrWhiteSpace(args[1]))
                    {
                        var apiUri = new Uri(args[0]);
                        var designName = args[1];

                        using var handler = new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        };

                        using var httpClient = new HttpClient(handler)
                        {
                            BaseAddress = apiUri,
                            Timeout = TimeSpan.FromSeconds(_requestTimeoutInMinutes * SECONDS_PER_MINUTE)
                        };

                        Logger.Info($"Server: '{httpClient.BaseAddress}' (Timeout: {httpClient.Timeout})");

                        var odbDesignClient = new OdbDesignHttpClient(httpClient, _authService);

                        var fileArchiveList = odbDesignClient.FetchFileArchiveList();
                        foreach (var fileArchive in fileArchiveList.FileArchives)
                        {
                            Logger.Info($"FileArchive: \"{fileArchive.Name},\" loaded={fileArchive.Loaded}");
                        }

                        //var fileArchive = odbDesignClient.FetchFileArchive(designName);                
                        var design = odbDesignClient.FetchDesign(designName);

                        exitCode = ExitCode.Success;
                    }
                    else
                    {
                        exitCode = ExitCode.InvalidArguments;
                    }
                }
                else
                {
                    exitCode = ExitCode.InvalidArguments;
                }              
            }
            catch (Exception e)
            {
                Logger.Exception(e);
            }

            Logger.Stop();

            if (exitCode == ExitCode.InvalidArguments)
            {
                PrintUsage();
            }

            return (int) exitCode;
        }       

        private static void PrintUsage()
        {
            Console.WriteLine("Invalid arguments...");
            Console.WriteLine();
            Console.WriteLine("Usage: OdbDesignClient <api-uri> <design-name>");
        }
    }
}
