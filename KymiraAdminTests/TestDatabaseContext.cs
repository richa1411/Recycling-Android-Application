using Microsoft.EntityFrameworkCore;
using System.Linq;
using KymiraAdmin.Models;
using System;

namespace KymiraAdminTests
{
    class TestDatabaseContext : IDisposable
    {
        private DbContextOptionsBuilder<KymiraAdminContext> config = new DbContextOptionsBuilder<KymiraAdminContext>();
        public KymiraAdminContext context { get; private set; }

        public TestDatabaseContext()
        {
            config.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=kymiraAPIDatabase29;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new KymiraAdminContext(config.Options);

            context.Database.EnsureCreated();

        }

        public void Dispose()
        {
            //remove all the data from db
        }
    

    }
}
