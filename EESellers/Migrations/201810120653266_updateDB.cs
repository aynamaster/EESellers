namespace EESellers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "TBL_USUARIO", newSchema: "dbo");
            DropIndex("dbo.TBL_USUARIO", "IX_TBL_USUARIO_LOGIN");
            CreateTable(
                "dbo.TBL_PRODUTO",
                c => new
                    {
                        CD_PRODUTO = c.Long(nullable: false, identity: true),
                        DS_PRODUTO = c.String(maxLength: 200),
                        VLR_UNITARIO = c.Long(nullable: false),
                        QTD_ESTOQUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FL_FISICO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CD_PRODUTO);
            
            CreateTable(
                "dbo.TBL_VENDAS",
                c => new
                    {
                        CD_VENDA = c.Int(nullable: false, identity: true),
                        CD_VENDEDOR = c.Int(nullable: false),
                        CD_PRODUTO = c.Int(nullable: false),
                        DT_CRIACAO = c.DateTime(),
                        DT_ULTIMA_ATUALIZACAO = c.DateTime(),
                        VLR_COMISSAO = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CD_VENDA);
            
            CreateTable(
                "dbo.TBL_VENDEDOR_PESSOA",
                c => new
                    {
                        CD_VENDEDOR = c.Int(nullable: false, identity: true),
                        DS_VENDEDOR = c.String(maxLength: 20),
                        VLR_SALDO = c.String(),
                        DT_CRIACAO = c.DateTime(),
                        DT_ULTIMA_ATUALIZACAO = c.DateTime(),
                    })
                .PrimaryKey(t => t.CD_VENDEDOR);
            
            AlterColumn("dbo.TBL_USUARIO", "DS_USUARIO", c => c.String(maxLength: 20));
            AlterColumn("dbo.TBL_USUARIO", "DS_LOGIN", c => c.String(maxLength: 30));
            AlterColumn("dbo.TBL_USUARIO", "DS_SENHA", c => c.String(maxLength: 200));
            AlterColumn("dbo.TBL_USUARIO", "DS_OBSERVACAO", c => c.String(maxLength: 100));
            CreateIndex("dbo.TBL_USUARIO", "DS_LOGIN", unique: true, name: "IX_TBL_USUARIO_LOGIN");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TBL_USUARIO", "IX_TBL_USUARIO_LOGIN");
            AlterColumn("dbo.TBL_USUARIO", "DS_OBSERVACAO", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.TBL_USUARIO", "DS_SENHA", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.TBL_USUARIO", "DS_LOGIN", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.TBL_USUARIO", "DS_USUARIO", c => c.String(maxLength: 20, unicode: false));
            DropTable("dbo.TBL_VENDEDOR_PESSOA");
            DropTable("dbo.TBL_VENDAS");
            DropTable("dbo.TBL_PRODUTO");
            CreateIndex("dbo.TBL_USUARIO", "DS_LOGIN", unique: true, name: "IX_TBL_USUARIO_LOGIN");
            MoveTable(name: "dbo.TBL_USUARIO", newSchema: null);
        }
    }
}
