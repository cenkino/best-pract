using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.Core.Models;

namespace task2.Core.Services
{
    public interface IUserService:IService<User>
    {
        Task<User> LoginAsync(string email, string password);
    }
}
