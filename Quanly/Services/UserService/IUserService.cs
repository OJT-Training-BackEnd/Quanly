using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quanly.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}