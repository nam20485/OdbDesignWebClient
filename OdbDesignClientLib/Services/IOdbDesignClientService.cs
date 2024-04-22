using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Odb.Client.Lib.Model;

namespace Odb.Client.Lib.Services
{
    public interface IOdbDesignClientService
    {
        Task<FileArchive> GetFileArchiveAsync(string name);
        Task<FileArchiveListResponse> GetFileArchiveListAsync();
        void AddAuthenticationData(string username, string password);
    }
}
