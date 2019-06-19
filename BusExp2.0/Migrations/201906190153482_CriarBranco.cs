namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBranco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Sessao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Sessao");
        }
    }
}
