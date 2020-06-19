using Kolos_2.DTOs.Res;
using Kolos_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Services
{
    public interface IDbService
    {
        public ArtistEvents GetArtist(int id);

        public void EventChange(int idart, int idevt,Artist_Event art);

         
    }
}
