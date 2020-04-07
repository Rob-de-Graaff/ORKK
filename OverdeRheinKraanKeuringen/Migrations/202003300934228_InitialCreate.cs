namespace OverdeRheinKraanKeuringen.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kabelchecklist",
                c => new
                {
                    KabelID = c.Int(nullable: false, identity: true),
                    Breuk6D = c.Int(nullable: false),
                    Breuk30D = c.Int(nullable: false),
                    BeschadigingBuitenzijde = c.Int(nullable: false),
                    BeschadigingRoestCorrosie = c.Int(nullable: false),
                    VerminderdeKabeldiameter = c.Int(nullable: false),
                    PositieMeetpunten = c.Int(nullable: false),
                    BeschadigingTotaal = c.Int(nullable: false),
                    TypeBeschadigingEnVervormingen = c.String(maxLength: 500),
                    Opdrachtnummer = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.KabelID)
                .ForeignKey("dbo.Opdracht", t => t.Opdrachtnummer, cascadeDelete: true)
                .Index(t => t.Opdrachtnummer);

            CreateTable(
                "dbo.Opdracht",
                c => new
                {
                    OpdrachtNummer = c.Int(nullable: false, identity: true),
                    WerkInstructie = c.String(maxLength: 500),
                    DatumUitvoering = c.DateTime(nullable: false),
                    KabelLeverancier = c.String(maxLength: 250),
                    Waarnemingen = c.String(maxLength: 500),
                    Image = c.Binary(),
                    Bedrijfsuren = c.Int(nullable: false),
                    AflegRedenen = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.OpdrachtNummer);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Kabelchecklist", "Opdrachtnummer", "dbo.Opdracht");
            DropIndex("dbo.Kabelchecklist", new[] { "Opdrachtnummer" });
            DropTable("dbo.Opdracht");
            DropTable("dbo.Kabelchecklist");
        }
    }
}