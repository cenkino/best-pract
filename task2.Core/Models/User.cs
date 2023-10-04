using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.API.Security;

namespace task2.Core.Models
{
    
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public Token Token { get; set; }

    }
}
