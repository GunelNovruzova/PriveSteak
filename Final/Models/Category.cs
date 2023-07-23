﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string NameAZ { get; set; }
        public string NameRU { get; set; }
        public string Image { get; set; }
        public IEnumerable<Product> Products { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
