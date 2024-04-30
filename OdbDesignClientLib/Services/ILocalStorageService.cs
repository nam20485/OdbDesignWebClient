using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Services
{
    public interface ILocalStorageService
    {
        Task<string> GetUsernameAsync();
        Task<string> GetPasswordAsync();
        Task SetPasswordAsync(string password);
        Task SetUsernameAsync(string username);
        Task RemoveAuthDataAsync();
    }
}
