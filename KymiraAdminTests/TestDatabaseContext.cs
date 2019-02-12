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
        public TestDatabaseContext(String dbName)
        {

            string dbString = dbName; 

            config.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=" + dbString + ";Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new KymiraAdminContext(config.Options);

            context.Database.EnsureCreated();

        }

        public void Dispose()
        {
            //remove all the data from db
        }
    

    }
}
