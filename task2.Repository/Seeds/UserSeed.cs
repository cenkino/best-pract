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
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                Email = "cenk@cenk.com",
                Password = "12345"
            });
        }
    }
}
