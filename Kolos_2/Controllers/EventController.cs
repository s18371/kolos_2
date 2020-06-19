using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolos_2.Exceptions;
using Kolos_2.Models;
using Kolos_2.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kolos_2.Controllers
{
    
    [ApiController]
    public class EventController : ControllerBase
    {
        private IDbService _context;
        public EventController(IDbService context)
        {
            _context = context;
        }
        [Route("api/artists/{idArt}/events/{idevt}")]
        [HttpPut("{idArt},{idevt}")]
        public IActionResult UpdateEvt(int idArt, int idevt,Artist_Event art)
        {
            try
            {
                _context.EventChange(idArt, idevt, art);
                return Ok();
            }
            catch(Event404 exc)
            {
                return NotFound(exc);
            }catch(EventStertedExc exc)
            {
                return BadRequest(exc);
            }
            return Ok();
            
        }
    }
}
