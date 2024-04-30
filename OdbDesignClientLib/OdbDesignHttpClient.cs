using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Odb.Client.Lib.Model;
using Odb.Client.Lib.Services;

namespace Odb.Client.Lib
{
    public class OdbDesignHttpClient
    {
        public bool UseLocalCopy { get; } = false;

        private readonly HttpClient _httpClient;
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthenticationService _authService;

        public OdbDesignHttpClient(HttpClient httpClient, IAuthenticationService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        //public OdbDesignHttpClient(IHttpClientFactory httpClientClientFactory)
        //{
        //    _httpClientFactory = httpClientClientFactory;
        //}

        public void AddAuthenticationData(string username, string password)
        {
            //var authHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public TResponseObject FetchObject<TResponseObject>(string endpoint) where TResponseObject : class
        {
            return FetchObjectAsync<TResponseObject>(endpoint).GetAwaiter().GetResult();
        }

        public async Task<TResponseObject> FetchObjectAsync<TResponseObject>(string endpoint) where TResponseObject : class
        {
            TResponseObject respObj = null;

            Console.Write($"making request: '{endpoint}'... ");

            _httpClient.DefaultRequestHeaders.Authorization = _authService.GetAuthenticationHeaderValue();

            //using (var httpClient = _httpClientFactory.CreateClient())
            try
            {
                var response = await _httpClient.GetAsync(endpoint);

                Console.WriteLine($"complete ({response.StatusCode})");

                if (response.IsSuccessStatusCode)
                {
                    //var t = typeof(TResponseObject);
                    var name = endpoint.Replace("/", "-");
                    var path = $"{name}.json";

                    Stream stream;
                    if (UseLocalCopy)
                    {
                        stream = new FileStream(path, FileMode.Open);
                    }
                    else
                    {
                        Console.Write("writing response content to file... ");
                        File.WriteAllText(path, await response.Content.ReadAsStringAsync());
                        Console.WriteLine("complete");

                        Console.WriteLine("reading content from response... ");
                        stream = await response.Content.ReadAsStreamAsync();
                        Console.WriteLine("complete");
                    }

                    Console.Write("deserializing response content... ");
                    respObj = await JsonSerializer.DeserializeAsync<TResponseObject>(stream, LibJsonSerializerOptions.Instance);
                    Console.WriteLine("complete");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return respObj;
        }

        public async Task<FileArchive> FetchFileArchiveAsync(string name)
        {
            var endpoint = $"filemodel/{name}";
            var fileArchive = await FetchObjectAsync<FileArchive>(endpoint);
            return fileArchive;
        }

        public FileArchive FetchFileArchive(string name)
        {
            return FetchFileArchiveAsync(name).GetAwaiter().GetResult();
        }

        public async Task<Design> FetchDesignAsync(string name)
        {
            Console.WriteLine($"Fetching design: {name}...");

            var endpoint = $"designs/{name}";
            var design = await FetchObjectAsync<Design>(endpoint);

            Console.WriteLine("Fetching design complete");

            return design;
        }

        public Design FetchDesign(string name) => FetchDesignAsync(name).GetAwaiter().GetResult();

        public async Task<FileArchiveListResponse> FetchFileArchiveListAsync()
        {
            var endpoint = "filemodels";
            var fileArchiveListResponse = await FetchObjectAsync<FileArchiveListResponse>(endpoint);
            return fileArchiveListResponse;
        }

        public FileArchiveListResponse FetchFileArchiveList() => FetchFileArchiveListAsync().GetAwaiter().GetResult();
    }
}
