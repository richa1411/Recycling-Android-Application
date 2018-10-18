using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kymiraAPI.Models
{
    public class kymiraAPIContext : DbContext
    {
        public kymiraAPIContext (DbContextOptions<kymiraAPIContext> options)
            : base(options)
        {
        }

        public DbSet<kymiraAPI.Models.Resident> ResidentDBSet { get; set; }
    }
}
