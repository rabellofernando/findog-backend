namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Celular = c.String(nullable: false, maxLength: 14, unicode: false),
                        Status = c.Int(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
