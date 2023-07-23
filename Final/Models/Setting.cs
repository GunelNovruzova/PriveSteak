using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Setting:BaseEntity
    {
        public string Logo { get; set; }
        public string Email { get; set; }
        [StringLength(255), Required]
        public string Phone { get; set; }
        [StringLength(255), Required]
        public string Phone2 { get; set; }
        [StringLength(255), Required]

        public string Address { get; set; }
        public string AddressAZ { get; set; }
        public string AddressRU { get; set; }
        public string WorkHours { get; set; }
        public string ContactUsTitle { get; set; }
        public string ContactUsTitleAZ { get; set; }
        public string ContactUsTitleRU { get; set; }
        public string ContactUsDescription { get; set; }
        public string ContactUsDescriptionAZ { get; set; }
        public string ContactUsDescriptionRU { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Map { get; set; }
        [NotMapped]
        public IFormFile LogoImage { get; set; }
    }
}
