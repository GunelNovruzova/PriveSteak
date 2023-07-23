﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class AboutIntro:BaseEntity
    {
        public string Feature { get; set; }
        public string FeatureAZ { get; set; }
        public string FeatureRU { get; set; }
        public string Description { get; set; }
        public string DescriptionAZ { get; set; }
        public string DescriptionRU { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
