using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels.Table
{
    public class TableVM
    {
        //public Final.Models.Table Tables { get; set; }
        public Setting Setting { get; set; }
        public Final.Models.Table Table { get; set; }
        public IEnumerable<TableCategory> TableCategories { get; set; }
        //public IEnumerable<Reserve> Reserves { get; set; }
        public Reserve Reserve { get; set; }
        public List<Reserve> Reserves { get; set; }
      
        public TableCategory TableCategory { get; set; }
        public List<Final.Models.Table> Tables { get; set; }
    }
}
