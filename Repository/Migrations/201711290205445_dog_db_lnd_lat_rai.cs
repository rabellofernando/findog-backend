namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dog_db_lnd_lat_rai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cachorro", "Endereco", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AddColumn("dbo.Cachorro", "Lat", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AddColumn("dbo.Cachorro", "Lng", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cachorro", "Lng");
            DropColumn("dbo.Cachorro", "Lat");
            DropColumn("dbo.Cachorro", "Endereco");
        }
    }
}
