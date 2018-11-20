namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_db3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coordenada", "Coord", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Coordenada", "Raio", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coordenada", "Raio", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Coordenada", "Coord", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
    }
}
