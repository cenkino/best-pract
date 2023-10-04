using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.Core.DTO;
using task2.Core.Models;

namespace task2.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
