using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_DB.Models
{
    
    public class DbModel : DbContext
    {
        public DbSet<Worker> example { get; set; }

        public DbModel()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=H3ll0W@rld;database=entity;",
                new MySqlServerVersion(new Version(8, 0, 11)),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
