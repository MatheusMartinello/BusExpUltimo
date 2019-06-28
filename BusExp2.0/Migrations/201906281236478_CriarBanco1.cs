namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LiberaCatraca", "onibus_OnibusId", "dbo.Onibus");
            DropIndex("dbo.LiberaCatraca", new[] { "onibus_OnibusId" });
            AddColumn("dbo.LiberaCatraca", "RuaInicial", c => c.String());
            AddColumn("dbo.LiberaCatraca", "RuaFinal", c => c.String());
            DropColumn("dbo.LiberaCatraca", "onibus_OnibusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LiberaCatraca", "onibus_OnibusId", c => c.Int());
            DropColumn("dbo.LiberaCatraca", "RuaFinal");
            DropColumn("dbo.LiberaCatraca", "RuaInicial");
            CreateIndex("dbo.LiberaCatraca", "onibus_OnibusId");
            AddForeignKey("dbo.LiberaCatraca", "onibus_OnibusId", "dbo.Onibus", "OnibusId");
        }
    }
}
