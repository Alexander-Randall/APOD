using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APOD.Models
{
    public class APODItem
    {
        public long Id { get; set; }
        public string Copyright { get; set; }
        public string Date { get; set; }
        public string Explanation { get; set; }
        public string Hdurl { get; set; }
        public string Media_type { get; set; }
        public string Service_version { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

    }
} 
