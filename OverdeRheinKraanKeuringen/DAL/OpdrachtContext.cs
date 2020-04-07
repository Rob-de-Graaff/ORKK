using OverdeRheinKraanKeuringen.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OverdeRheinKraanKeuringen.DAL
{
    public class OpdrachtContext : DbContext
    {
        public OpdrachtContext() : base("OpdrachtContext")
        {
        }

        public DbSet<Opdracht> Opdrachten { get; set; }
        public DbSet<Kabelchecklist> Kabelchecklists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}