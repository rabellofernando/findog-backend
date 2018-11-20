namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dispositivos_db : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coordenada", "CachorroId", "dbo.Cachorro");
            DropIndex("dbo.Coordenada", new[] { "CachorroId" });
            CreateTable(
                "dbo.Dispositivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        NumeroSerie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cachorro", "DispositivoId", c => c.Int(nullable: false));
            AddColumn("dbo.Coordenada", "DispositivoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cachorro", "DispositivoId");
            CreateIndex("dbo.Coordenada", "DispositivoId");
            AddForeignKey("dbo.Cachorro", "DispositivoId", "dbo.Dispositivo", "Id");
            AddForeignKey("dbo.Coordenada", "DispositivoId", "dbo.Dispositivo", "Id");
            DropColumn("dbo.Coordenada", "CachorroId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coordenada", "CachorroId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Coordenada", "DispositivoId", "dbo.Dispositivo");
            DropForeignKey("dbo.Cachorro", "DispositivoId", "dbo.Dispositivo");
            DropIndex("dbo.Coordenada", new[] { "DispositivoId" });
            DropIndex("dbo.Cachorro", new[] { "DispositivoId" });
            DropColumn("dbo.Coordenada", "DispositivoId");
            DropColumn("dbo.Cachorro", "DispositivoId");
            DropTable("dbo.Dispositivo");
            CreateIndex("dbo.Coordenada", "CachorroId");
            AddForeignKey("dbo.Coordenada", "CachorroId", "dbo.Cachorro", "Id");
        }
    }
}
