namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_db2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Pedidos", new[] { "UsuarioId" });
            DropTable("dbo.Pedidos");
        }
    }
}
