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

        //public DbSet<Attachment> Attachments { get; set; }

        public DbSet<AttachmentType> AttachmentTypes { get; set; }

        public DbSet<CardStatus> CardStatuses { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("AMEXCCDB");

            //Configure oracle data types.
            //modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 3));
            // modelBuilder.Properties<string>().Configure(p => p.IsMaxLength());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
