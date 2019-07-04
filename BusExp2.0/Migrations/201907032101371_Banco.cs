namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Telefone", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Telefone", c => c.String(maxLength: 10));
        }
    }
}
