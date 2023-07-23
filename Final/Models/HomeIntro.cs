using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class HomeIntro:BaseEntity
    {
        public string Intro { get; set; }
        public string IntroAZ { get; set; }
        public string IntroRU { get; set; }
        public string Title { get; set; }
        public string TitleAZ { get; set; }
        public string TitleRU { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionAZ { get; set; }
        public string DescriptionRU { get; set; }

    }
}
