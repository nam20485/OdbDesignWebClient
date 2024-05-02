using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Odb.Client.Lib.Model;

using static Odb.Client.Lib.OdbDesignHttpClient;

namespace Odb.Client.Lib.Services
{
    public interface IOdbDesignClientService
    {
        Task<FileArchive> GetFileArchiveAsync(string name);
        Task<FileArchiveListResponse> GetFileArchiveListAsync();

        Task<FileUploadResponse> UploadDesignFileAsync(DesignFileUploadInfo uploadFileInfo);
        Task<FileUploadResponse> UploadDesignFilesAsync(DesignFileUploadInfo[] uploadFileInfos);
    }
}
