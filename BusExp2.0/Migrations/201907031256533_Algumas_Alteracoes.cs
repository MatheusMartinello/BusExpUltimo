namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Algumas_Alteracoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Cep", c => c.String(maxLength: 8));
            AlterColumn("dbo.Usuario", "Telefone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Ranking", "Comentario", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ranking", "Comentario", c => c.String());
            AlterColumn("dbo.Usuario", "Telefone", c => c.String());
            AlterColumn("dbo.Usuario", "Cep", c => c.String());
        }
    }
}
