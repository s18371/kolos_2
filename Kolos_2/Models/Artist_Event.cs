using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Models
{
    public class Artist_Event
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public DateTime PerformanceDate { get; set; }

        public Artist Artist { get; set; }
        public Event Event{ get; set; }
    }
}
