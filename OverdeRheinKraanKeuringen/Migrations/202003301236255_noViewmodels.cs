namespace OverdeRheinKraanKeuringen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noViewmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opdracht", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Opdracht", "Discriminator");
        }
    }
}
