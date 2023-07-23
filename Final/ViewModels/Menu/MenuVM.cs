using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels.Menu
{
    public class MenuVM
    {
        public IEnumerable<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
