using OverdeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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