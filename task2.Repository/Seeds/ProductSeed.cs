using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.Core.Models;

namespace task2.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = 1,
                Code = "HP1",
                CreatedDate = DateTime.Now,
                Name = "HP",
                Picture = "/Images/laptop.jpg",
                Price = 590
            },
            new Product()
            {
                Id = 2,
                Code = "LEN1",
                CreatedDate = DateTime.Now,
                Name = "Lenovo",
                Picture = "/Images/laptop.jpg",
                Price = 640
            },
            new Product()
            {
                Id = 3,
                Code = "ASUS1",
                CreatedDate = DateTime.Now,
                Name = "Asus",
                Picture = "/Images/laptop.jpg",
                Price = 750
            });
        }
    }
}
