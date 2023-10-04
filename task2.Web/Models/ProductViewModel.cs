using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace task2.Web.Models
{
    public class ProductViewModel
    {
        
        public string Name { get; set; }

        
        public string Code { get; set; }

        
        public decimal Price { get; set; }

        
        public DateTime CreatedDate { get; set; }

        
        public string Picture { get; set; }
    }
}
