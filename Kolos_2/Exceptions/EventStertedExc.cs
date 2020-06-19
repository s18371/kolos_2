using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Exceptions
{
    public class EventStertedExc:Exception
    {
        public EventStertedExc(string message) : base(message)
        {
        }

        public EventStertedExc(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EventStertedExc()
        {
        }
    }
}
