using Kolos_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.DTOs.Res
{
    public class ArtistEvents
    {
        public Artist Artist { get; set; }
        public List<Event> Eventy { get; set; }
    }
}
