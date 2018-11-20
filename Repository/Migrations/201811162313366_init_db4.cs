namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_db4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coordenada", "Longitude", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.Coordenada", "Longetitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coordenada", "Longetitude", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.Coordenada", "Longitude");
        }
    }
}
