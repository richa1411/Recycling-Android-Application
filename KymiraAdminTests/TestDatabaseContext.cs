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
        //takes in the name of the databse. for example KymiraDatabase29
        /**
         * params: String dbName - name of the db
         * */
        public TestDatabaseContext(String dbName)
        {
            //sets up the context for the database.
            config.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=" + dbName + ";Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new KymiraAdminContext(config.Options);

            context.Database.EnsureCreated();

        }

        public void Dispose()
        {
            //remove all the data from db
        }
    

    }
}
