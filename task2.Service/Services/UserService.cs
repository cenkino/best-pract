using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using task2.API.Security;
using task2.Core.Models;
using task2.Core.Repositories;
using task2.Core.Services;
using task2.Core.UnitOfWorks;
using task2.Repository.Repositories;

namespace task2.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        public readonly IGenericRepository<User> _repository;
        
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }


        public async Task<User> LoginAsync(string email, string password)
        {
            
            var user = await _repository.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                
                return null;
            }

           
            bool isPasswordValid = await _repository.VerifyPassword(x=>x.Password==password).ConfigureAwait(false);

            if (!isPasswordValid)
            {
                return null;
            }

            
            
            return user;

        }
    }
}
