using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolos_2.Exceptions;
using Kolos_2.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kolos_2.Controllers
{   
    [ApiController]
    [Route("/api/artists")]
    public class ArtistController : ControllerBase
    {

        private IDbService _context;
        public ArtistController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetArtist(int id)
        {
            try {
                var odpowiedz = _context.GetArtist(id);
                return Ok(odpowiedz);
            }
            catch (ArtistNotExistsException exe)
            {
                return NotFound(exe);
            }
            
            
        }
    }
}
