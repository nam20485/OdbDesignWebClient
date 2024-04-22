using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Odb.Client.Lib.Model;

namespace Odb.Client.Lib.Services
{
    public class OdbDesignClientService : IOdbDesignClientService
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly OdbDesignHttpClient _odbDesignHttpClient;

        //public OdbDesignClientService(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public OdbDesignClientService(OdbDesignHttpClient odbDesignHttpClient)
        {
            _odbDesignHttpClient = odbDesignHttpClient;
        }

        public async Task<FileArchive> GetFileArchiveAsync(string name)
        {
            return await _odbDesignHttpClient.FetchFileArchiveAsync(name);
        }

        public async Task<FileArchiveListResponse> GetFileArchiveListAsync()
        {
            return await _odbDesignHttpClient.FetchFileArchiveListAsync();
        }

        public void AddAuthenticationData(string username, string password)
        {
            _odbDesignHttpClient.AddAuthenticationData(username, password);
        }
    }
}
