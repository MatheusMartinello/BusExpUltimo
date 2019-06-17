namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credito",
                c => new
                    {
                        CreditoId = c.Int(nullable: false, identity: true),
                        ValorCredito = c.String(),
                        FormaPag_FormaPagId = c.Int(),
                        usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.CreditoId)
                .ForeignKey("dbo.FormaPagamento", t => t.FormaPag_FormaPagId)
                .ForeignKey("dbo.Usuario", t => t.usuario_UsuarioId)
                .Index(t => t.FormaPag_FormaPagId)
                .Index(t => t.usuario_UsuarioId);
            
            CreateTable(
                "dbo.FormaPagamento",
                c => new
                    {
                        FormaPagId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.FormaPagId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeCompleto = c.String(),
                        Cpf = c.String(),
                        Email = c.String(),
                        Rua = c.String(),
                        Cep = c.String(),
                        Telefone = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.HistoricoGasto",
                c => new
                    {
                        HistoricoPagamentosId = c.Int(nullable: false, identity: true),
                        LiberaCatraca_LiberaCatracaId = c.Int(),
                    })
                .PrimaryKey(t => t.HistoricoPagamentosId)
                .ForeignKey("dbo.LiberaCatraca", t => t.LiberaCatraca_LiberaCatracaId)
                .Index(t => t.LiberaCatraca_LiberaCatracaId);
            
            CreateTable(
                "dbo.LiberaCatraca",
                c => new
                    {
                        LiberaCatracaId = c.Int(nullable: false, identity: true),
                        DataPagamento = c.DateTime(nullable: false),
                        ValorPago = c.String(),
                        credito_CreditoId = c.Int(),
                        onibus_OnibusId = c.Int(),
                        usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.LiberaCatracaId)
                .ForeignKey("dbo.Credito", t => t.credito_CreditoId)
                .ForeignKey("dbo.Onibus", t => t.onibus_OnibusId)
                .ForeignKey("dbo.Usuario", t => t.usuario_UsuarioId)
                .Index(t => t.credito_CreditoId)
                .Index(t => t.onibus_OnibusId)
                .Index(t => t.usuario_UsuarioId);
            
            CreateTable(
                "dbo.Onibus",
                c => new
                    {
                        OnibusId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        RuaInicial = c.String(),
                        RuaFinal = c.String(),
                    })
                .PrimaryKey(t => t.OnibusId);
            
            CreateTable(
                "dbo.Motorista",
                c => new
                    {
                        MotoristaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.MotoristaId);
            
            CreateTable(
                "dbo.Ranking",
                c => new
                    {
                        RankingId = c.Int(nullable: false, identity: true),
                        ValorAtribuido = c.String(),
                        Comentario = c.String(),
                        Motorista_MotoristaId = c.Int(),
                        Onibus_OnibusId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.RankingId)
                .ForeignKey("dbo.Motorista", t => t.Motorista_MotoristaId)
                .ForeignKey("dbo.Onibus", t => t.Onibus_OnibusId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Motorista_MotoristaId)
                .Index(t => t.Onibus_OnibusId)
                .Index(t => t.Usuario_UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ranking", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Ranking", "Onibus_OnibusId", "dbo.Onibus");
            DropForeignKey("dbo.Ranking", "Motorista_MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.HistoricoGasto", "LiberaCatraca_LiberaCatracaId", "dbo.LiberaCatraca");
            DropForeignKey("dbo.LiberaCatraca", "usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.LiberaCatraca", "onibus_OnibusId", "dbo.Onibus");
            DropForeignKey("dbo.LiberaCatraca", "credito_CreditoId", "dbo.Credito");
            DropForeignKey("dbo.Credito", "usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Credito", "FormaPag_FormaPagId", "dbo.FormaPagamento");
            DropIndex("dbo.Ranking", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Ranking", new[] { "Onibus_OnibusId" });
            DropIndex("dbo.Ranking", new[] { "Motorista_MotoristaId" });
            DropIndex("dbo.LiberaCatraca", new[] { "usuario_UsuarioId" });
            DropIndex("dbo.LiberaCatraca", new[] { "onibus_OnibusId" });
            DropIndex("dbo.LiberaCatraca", new[] { "credito_CreditoId" });
            DropIndex("dbo.HistoricoGasto", new[] { "LiberaCatraca_LiberaCatracaId" });
            DropIndex("dbo.Credito", new[] { "usuario_UsuarioId" });
            DropIndex("dbo.Credito", new[] { "FormaPag_FormaPagId" });
            DropTable("dbo.Ranking");
            DropTable("dbo.Motorista");
            DropTable("dbo.Onibus");
            DropTable("dbo.LiberaCatraca");
            DropTable("dbo.HistoricoGasto");
            DropTable("dbo.Usuario");
            DropTable("dbo.FormaPagamento");
            DropTable("dbo.Credito");
        }
    }
}
