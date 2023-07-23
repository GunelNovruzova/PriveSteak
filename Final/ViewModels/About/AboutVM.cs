using Final.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels.About
{
    public class AboutVM
    {
        public IEnumerable<AboutIntro> AboutIntros { get; set; }
        public Setting Setting { get; set; }
        public IEnumerable<Video>Videos { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}