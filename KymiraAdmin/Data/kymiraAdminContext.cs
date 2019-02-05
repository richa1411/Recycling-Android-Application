using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KymiraAdmin.Data
{
    public class KymiraAdminContext : DbContext
    {
        public KymiraAdminContext(DbContextOptions<KymiraAdminContext> options)
            : base(options)
        {
        }

        public DbSet<KymiraAdmin.Models.FAQ> FAQDBSet { get; set; }
    }
}