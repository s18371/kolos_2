using Kolos_2.DTOs.Res;
using Kolos_2.Exceptions;
using Kolos_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Services
{
    public class EfDbService : IDbService
    {
        private EfDbContext _context { get; set; }
        public EfDbService(EfDbContext context)
        {
            _context = context;
        }

        public ArtistEvents GetArtist(int id)
        {
            var artistGet = _context.Artists.SingleOrDefault(m => m.IdArtist == id);

            List<Event> eventy = new List<Event>();

            if (artistGet == null)
            {
                throw new ArtistNotExistsException($"Artist with an id={id} does not exists");
            }
            List<Artist_Event> eventsGet = _context.Artist_Events.Where(m => m.IdArtist == artistGet.IdArtist).ToList();

            foreach(Artist_Event e in eventsGet)
            {
                var evt = _context.Events.Where(m => m.IdEvent == e.IdEvent).SingleOrDefault();

                eventy.Add(evt);
            }






            return new ArtistEvents { Artist = artistGet, Eventy = eventy };
        }

        public void EventChange(int idart, int idevt,Artist_Event art)
        {
            var dt = DateTime.Now;


            var evt = _context.Events.Where(p => p.IdEvent == idevt).SingleOrDefault();
            if (evt == null)
            {
                throw new Event404($"event with id ={idevt} not exists");
            }
            if (evt.StartDate.CompareTo(dt)<0)
            {
                throw new EventStertedExc($"event started already");
            }
            _context.Attach(art);
            _context.Entry(art).State = EntityState.Modified;
            _context.SaveChanges();


        }
    }
}
