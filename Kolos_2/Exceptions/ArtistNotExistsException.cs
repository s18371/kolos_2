using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Exceptions
{
    
    public class ArtistNotExistsException : Exception
    {
        public ArtistNotExistsException(string message) : base(message)
        {
        }

        public ArtistNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ArtistNotExistsException()
        {
        }
    }
}
