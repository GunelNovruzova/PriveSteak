using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Reserve : BaseEntity
    {
        public int? Number { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImagePositionTOP { get; set; }
        public string ImagePositionLEFT { get; set; }
        //public string ImageWidth { get; set; }
        //public string ImageHeigth { get; set; }
        public ICollection<Table> Tables { get; set; }
        public int? TableCategoryId { get; set; } 
        public TableCategory TableCategory { get; set; }    }
}
