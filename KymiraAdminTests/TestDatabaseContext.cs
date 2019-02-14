using KymiraAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KymiraAdminTests
{
    public class TestDatabaseContext : IDisposable
    {
        private DbContextOptionsBuilder<KymiraAdminContext> config = new DbContextOptionsBuilder<KymiraAdminContext>();

        public KymiraAdminContext context { get; private set; }

        
        /* This constructor takes in the name of the database to connect to,
         * for example: KymiraDatabase30 */
        public TestDatabaseContext(String dbName)
        {
            //sets up the context for the database.
            config.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=" + dbName + ";Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new KymiraAdminContext(config.Options);

            context.Database.EnsureCreated();
        }

        /* This method will remove all items from the database */
        public void Dispose()
        {
        }
    }
}
