using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APOD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<APODItem>>> GetNasaData()
        {
            HttpResponseMessage response = await Client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=ErinR37q35EL8MkJOwu2h8XxH0htwDk6cYRDGJ84");
            if (response.IsSuccessStatusCode)
            {
                string itemString = await response.Content.ReadAsStringAsync();
                APODItem item = JsonConvert.DeserializeObject<APODItem>(itemString);
                _context.APODItems.Add(item);
                await _context.SaveChangesAsync();
            }
            
            return await _context.APODItems.ToListAsync();
        }
    }
}
