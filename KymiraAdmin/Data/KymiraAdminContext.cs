using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KymiraAdmin.Models
{
    public class KymiraAdminContext : DbContext
    {
        public KymiraAdminContext (DbContextOptions<KymiraAdminContext> options)
            : base(options)
        {
        }

        public DbSet<KymiraAdmin.Models.BinStatus> BinStatus { get; set; }
    }
}
