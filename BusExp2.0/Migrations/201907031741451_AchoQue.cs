namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AchoQue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricoAdicaoCredito",
                c => new
                    {
                        HistoricoAdicaoCreditoId = c.Int(nullable: false, identity: true),
                        Creditos_CreditoId = c.Int(),
                    })
                .PrimaryKey(t => t.HistoricoAdicaoCreditoId)
                .ForeignKey("dbo.Credito", t => t.Creditos_CreditoId)
                .Index(t => t.Creditos_CreditoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoricoAdicaoCredito", "Creditos_CreditoId", "dbo.Credito");
            DropIndex("dbo.HistoricoAdicaoCredito", new[] { "Creditos_CreditoId" });
            DropTable("dbo.HistoricoAdicaoCredito");
        }
    }
}
