using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Database.Data
{
    public class AbContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public string ConnectionString { get; set; }

        public AbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=Zsolt;Trusted_Connection=true");
        }
    }
}
