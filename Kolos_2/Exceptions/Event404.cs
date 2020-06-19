using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Exceptions
{
    public class Event404 : Exception
    {
        public Event404(string message) : base(message)
        {
        }

        public Event404(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Event404()
        {
        }
    }
}