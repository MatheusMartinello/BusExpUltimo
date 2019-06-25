namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Nome", c => c.String());
            AddColumn("dbo.Usuario", "SobreNome", c => c.String(nullable: false));
            AddColumn("dbo.Onibus", "LatRuaInicial", c => c.String());
            AddColumn("dbo.Onibus", "LonRuaInicial", c => c.String());
            AddColumn("dbo.Onibus", "LatRuaFinal", c => c.String());
            AddColumn("dbo.Onibus", "LonRuaFinal", c => c.String());
            AlterColumn("dbo.Usuario", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Rua", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            DropColumn("dbo.Usuario", "NomeCompleto");
            DropColumn("dbo.Usuario", "Sessao");
            DropColumn("dbo.Onibus", "RuaInicial");
            DropColumn("dbo.Onibus", "RuaFinal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Onibus", "RuaFinal", c => c.String());
            AddColumn("dbo.Onibus", "RuaInicial", c => c.String());
            AddColumn("dbo.Usuario", "Sessao", c => c.String());
            AddColumn("dbo.Usuario", "NomeCompleto", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "Rua", c => c.String());
            AlterColumn("dbo.Usuario", "Email", c => c.String());
            AlterColumn("dbo.Usuario", "Cpf", c => c.String());
            DropColumn("dbo.Onibus", "LonRuaFinal");
            DropColumn("dbo.Onibus", "LatRuaFinal");
            DropColumn("dbo.Onibus", "LonRuaInicial");
            DropColumn("dbo.Onibus", "LatRuaInicial");
            DropColumn("dbo.Usuario", "SobreNome");
            DropColumn("dbo.Usuario", "Nome");
        }
    }
}
