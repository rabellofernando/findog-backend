namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_coordcampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coordenada", "Longetitude", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Coordenada", "Latitude", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coordenada", "Latitude");
            DropColumn("dbo.Coordenada", "Longetitude");
        }
    }
}
