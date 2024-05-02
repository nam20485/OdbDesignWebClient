using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.AspNetCore.Components.Forms;

using Odb.Client.Lib.Model;
using Odb.Client.Lib.Services;

namespace Odb.Client.Lib
{
    public class OdbDesignHttpClient : IOdbDesignHttpClient
    {
        public bool UseLocalCopy { get; } = false;

        private const string FILES_UPLOAD_ENDPOINT = "files/upload";
        private const string MULTIPART_FORM_PART_NAME = "file";
        private const string MULTIPART_FORM_BOUNDARY = "file";
        private const string CONTENT_TYPE_APPLICATION_OCTET_STREAM = "application/octet-stream";
        
        private const int OPEN_READSTREAM_MAX_FILE_SIZE = 200 * Constants.Numbers.BYTES_PER_MEGABYTE;        

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

        private TResponseObject FetchObject<TResponseObject>(string endpoint) where TResponseObject : class
        {
            return FetchObjectAsync<TResponseObject>(endpoint).GetAwaiter().GetResult();
        }

        private async Task<TResponseObject> FetchObjectAsync<TResponseObject>(string endpoint) where TResponseObject : class
        {
            TResponseObject respObj = null;

            Console.Write($"making request: '{endpoint}'... ");

            _httpClient.DefaultRequestHeaders.Authorization = await _authService.GetAuthenticationHeaderValueAsync();

            //using (var httpClient = _httpClientFactory.CreateClient())
            try
            {
                using var response = await _httpClient.GetAsync(endpoint);

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

                        Console.Write("reading content from response... ");
                        stream = await response.Content.ReadAsStreamAsync();
                        Console.WriteLine("complete");
                    }

                    Console.Write("deserializing response content... ");
                    respObj = await JsonSerializer.DeserializeAsync<TResponseObject>(stream, LibJsonSerializerOptions.Instance);
                    stream.Close();
                    stream.Dispose();
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

        public async Task<FileArchiveListResponse> UploadDesignFileAsync(DesignFileUploadInfo uploadFileInfo)
        {
            using var content = new ByteArrayContent(uploadFileInfo.Bytes);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(uploadFileInfo.ContentType);            

            var endpoint = $"{FILES_UPLOAD_ENDPOINT}/{uploadFileInfo.Filename}";
            return await PostContentAsync<FileArchiveListResponse>(content, endpoint);
        }

        public async Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<DesignFileUploadInfo> uploadFileInfos)
        {
            using var content = new MultipartFormDataContent(MULTIPART_FORM_BOUNDARY);
            foreach (var fileInfo in uploadFileInfos)
            {
                var fileContent = new ByteArrayContent(fileInfo.Bytes);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(fileInfo.ContentType);
                content.Add(fileContent, MULTIPART_FORM_PART_NAME, fileInfo.Filename);
            }

            return await PostContentAsync<FileArchiveListResponse>(content, FILES_UPLOAD_ENDPOINT);          
        }        

        public async Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<IBrowserFile> browserFiles)
        {
            using var content = new MultipartFormDataContent(MULTIPART_FORM_BOUNDARY);
            foreach (var browserFile in browserFiles)
            {
                var fileContent = new StreamContent(browserFile.OpenReadStream(OPEN_READSTREAM_MAX_FILE_SIZE));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(browserFile.ContentType);
                content.Add(fileContent, MULTIPART_FORM_PART_NAME, browserFile.Name);
            }

            return await PostContentAsync<FileArchiveListResponse>(content, FILES_UPLOAD_ENDPOINT);
        }

        private async Task<TReturn> PostContentAsync<TReturn>(HttpContent content, string endpoint)
        {
            using var response = await _httpClient.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var respObj = await JsonSerializer.DeserializeAsync<TReturn>(stream, LibJsonSerializerOptions.Instance);
                return respObj;
            }

            return default;
        }

    }
}
