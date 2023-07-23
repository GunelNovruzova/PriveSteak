using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels.Products
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        
    }
}
