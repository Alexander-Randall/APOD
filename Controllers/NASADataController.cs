using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APOD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APOD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NASADataController : ControllerBase
    {
        static HttpClient Client = new HttpClient();
        private readonly APODContext _context;

        public NASADataController(APODContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APODItem>>> GetAPODItems()
        {
            HttpResponseMessage response = Client.GetAsync(https://api.nasa.gov/planetary/apod);
            return await _context.APODItems.ToListAsync();
        }
    }
}
