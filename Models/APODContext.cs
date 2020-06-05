using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APOD.Models
{
    public class APODContext :DbContext
    {
        public APODContext(DbContextOptions<APODContext> options)
            : base(options)
        {
        }

        public DbSet<APODItem> TodoItems { get; set; }
    }
}
