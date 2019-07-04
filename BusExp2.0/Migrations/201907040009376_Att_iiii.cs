namespace BusExp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att_iiii : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credito", "FormaPag_FormaPagId", "dbo.FormaPagamento");
            DropIndex("dbo.Credito", new[] { "FormaPag_FormaPagId" });
            AlterColumn("dbo.Credito", "FormaPag_FormaPagId", c => c.Int(nullable: false));
            CreateIndex("dbo.Credito", "FormaPag_FormaPagId");
            AddForeignKey("dbo.Credito", "FormaPag_FormaPagId", "dbo.FormaPagamento", "FormaPagId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credito", "FormaPag_FormaPagId", "dbo.FormaPagamento");
            DropIndex("dbo.Credito", new[] { "FormaPag_FormaPagId" });
            AlterColumn("dbo.Credito", "FormaPag_FormaPagId", c => c.Int());
            CreateIndex("dbo.Credito", "FormaPag_FormaPagId");
            AddForeignKey("dbo.Credito", "FormaPag_FormaPagId", "dbo.FormaPagamento", "FormaPagId");
        }
    }
}
