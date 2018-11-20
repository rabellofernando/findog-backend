namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Movimentacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacao", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Movimentacao", new[] { "UsuarioId" });
            DropTable("dbo.Movimentacao");
        }
    }
}
