using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class TableCategory:BaseEntity
    {
        public string Title { get; set; }
        public string TitleAZ { get; set; }
        public string TitleRU { get; set; }
        public ICollection<Reserve> Reserves { get; set; }
    }
}
