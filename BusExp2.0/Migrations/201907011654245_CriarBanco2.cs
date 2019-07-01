namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ranking", "Onibus_OnibusId", "dbo.Onibus");
            DropIndex("dbo.Ranking", new[] { "Onibus_OnibusId" });
            DropColumn("dbo.Ranking", "Onibus_OnibusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ranking", "Onibus_OnibusId", c => c.Int());
            CreateIndex("dbo.Ranking", "Onibus_OnibusId");
            AddForeignKey("dbo.Ranking", "Onibus_OnibusId", "dbo.Onibus", "OnibusId");
        }
    }
}
