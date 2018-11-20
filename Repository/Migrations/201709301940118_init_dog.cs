namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_dog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movimentacao", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Pedidos", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Movimentacao", new[] { "UsuarioId" });
            DropIndex("dbo.Pedidos", new[] { "UsuarioId" });
            CreateTable(
                "dbo.Cachorro",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Dt_nasc = c.String(nullable: false, maxLength: 14, unicode: false),
                        Raca = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Coordenada",
                c => new
                    {
                        CachorroId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Coord = c.String(nullable: false, maxLength: 200, unicode: false),
                        Raio = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cachorro", t => t.CachorroId)
                .Index(t => t.CachorroId);
            
            CreateTable(
                "dbo.Localizacao",
                c => new
                    {
                        CachorroId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.String(nullable: false, maxLength: 200, unicode: false),
                        Longitude = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cachorro", t => t.CachorroId)
                .Index(t => t.CachorroId);
            
            CreateTable(
                "dbo.Vacina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(nullable: false, maxLength: 200, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 15, unicode: false),
                        Reforco = c.String(nullable: false, maxLength: 200, unicode: false),
                        CachorroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cachorro", t => t.CachorroId)
                .Index(t => t.CachorroId);
            
            AddColumn("dbo.Usuario", "Endereco", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropTable("dbo.Movimentacao");
            DropTable("dbo.Pedidos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Vacina", "CachorroId", "dbo.Cachorro");
            DropForeignKey("dbo.Localizacao", "CachorroId", "dbo.Cachorro");
            DropForeignKey("dbo.Coordenada", "CachorroId", "dbo.Cachorro");
            DropForeignKey("dbo.Cachorro", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Vacina", new[] { "CachorroId" });
            DropIndex("dbo.Localizacao", new[] { "CachorroId" });
            DropIndex("dbo.Coordenada", new[] { "CachorroId" });
            DropIndex("dbo.Cachorro", new[] { "UsuarioId" });
            DropColumn("dbo.Usuario", "Endereco");
            DropTable("dbo.Vacina");
            DropTable("dbo.Localizacao");
            DropTable("dbo.Coordenada");
            DropTable("dbo.Cachorro");
            CreateIndex("dbo.Pedidos", "UsuarioId");
            CreateIndex("dbo.Movimentacao", "UsuarioId");
            AddForeignKey("dbo.Pedidos", "UsuarioId", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Movimentacao", "UsuarioId", "dbo.Usuario", "Id");
        }
    }
}
