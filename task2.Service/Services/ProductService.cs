using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.Core.Models;
using task2.Core.Repositories;
using task2.Core.Services;
using task2.Core.UnitOfWorks;

namespace task2.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
