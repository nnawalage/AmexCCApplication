using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Amex.CCA.DataAccess.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Amex.CCA.DataAccess
{
    public class AmexDbContext : DbContext
    {
        public AmexDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("AMEXCCDB");
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
