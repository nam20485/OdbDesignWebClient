using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Forms;

using Odb.Client.Lib.Model;

namespace Odb.Client.Lib
{
    public interface IOdbDesignHttpClient
    {
        Design FetchDesign(string name);
        Task<Design> FetchDesignAsync(string name);
        FileArchive FetchFileArchive(string name);
        Task<FileArchive> FetchFileArchiveAsync(string name);
        FileArchiveListResponse FetchFileArchiveList();
        Task<FileArchiveListResponse> FetchFileArchiveListAsync();
        Task<FileArchiveListResponse> UploadDesignFileAsync(DesignFileUploadInfo uploadFileInfo);
        Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<DesignFileUploadInfo> uploadFileInfos);
        Task<FileArchiveListResponse> UploadDesignFilesAsync(IEnumerable<IBrowserFile> browserFiles);
    }
}
