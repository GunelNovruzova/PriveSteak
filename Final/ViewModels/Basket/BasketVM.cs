using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels.Basket
{
    public class BasketVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string NameAZ { get; set; }
        public string NameRU { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
     
        public string Image { get; set; }
        

    }
}
