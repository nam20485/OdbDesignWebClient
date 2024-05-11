using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Forms;

using Odb.Client.Lib.Model;

namespace Odb.Client.Lib.Services
{
    public interface IOdbDesignClientService
    {
        Task<FileArchive> GetFileArchiveAsync(string name);
        Task<FileArchiveListResponse> GetFileArchiveListAsync();
        
        Task<Design> GetDesignAsync(string name);

        Task<FileArchiveListResponse> UploadDesignFileAsync(DesignFileUploadInfo uploadFileInfo);
        Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<DesignFileUploadInfo> uploadFileInfos);
        Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<IBrowserFile> browserFiles);
    }
}
