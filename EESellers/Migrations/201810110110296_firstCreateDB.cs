namespace EESellers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstCreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TBL_USUARIO",
                c => new
                    {
                        CD_USUARIO = c.Int(nullable: false, identity: true),
                        DS_USUARIO = c.String(maxLength: 20, unicode: false),
                        DS_LOGIN = c.String(maxLength: 30, unicode: false),
                        DS_SENHA = c.String(maxLength: 200, unicode: false),
                        DS_OBSERVACAO = c.String(maxLength: 100, unicode: false),
                        DT_CRIACAO = c.DateTime(),
                        CD_USUARIO_CRIACAO = c.Int(),
                        CD_USUARIO_ULTIMA_ALTERACAO = c.Int(),
                        DT_ULTIMA_ATUALIZACAO = c.DateTime(),
                    })
                .PrimaryKey(t => t.CD_USUARIO)
                .Index(t => t.DS_LOGIN, unique: true, name: "IX_TBL_USUARIO_LOGIN");
            
        }
        
        public override void Down()
        {
            DropIndex("TBL_USUARIO", "IX_TBL_USUARIO_LOGIN");
            DropTable("TBL_USUARIO");
        }
    }
}
