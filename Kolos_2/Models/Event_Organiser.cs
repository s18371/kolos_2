using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Models
{
    public class Event_Organiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }
        public Organiser Organiser { get; set; }

        public Event Event { get; set; }
    }
}
