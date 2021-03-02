using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace joshuaford_project1.Database
{
    public class DataAccess_Library
    {
        /// <summary>
        /// Creates a context to be passed to classes for the database connection
        /// </summary>
        /// <returns></returns>
        public static DbContextOptions<joshfordproject0Context> DatabaseConnectionString()
        {
            string connectionString = File.ReadAllText("/Users/Josh/Revature/ConnectionString.txt");
            DbContextOptions<joshfordproject0Context> contextOptions = new DbContextOptionsBuilder<joshfordproject0Context>()
                .UseSqlServer(connectionString)
                .Options;
            return contextOptions;
        }
    }
}
