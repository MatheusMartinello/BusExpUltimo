namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ranking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ranking", "ValorAtribuido", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ranking", "ValorAtribuido", c => c.String(nullable: false));
        }
    }
}
