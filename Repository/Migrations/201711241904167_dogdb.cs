namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dogdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cachorro", "Raio", c => c.Int(nullable: false));
            AddColumn("dbo.Cachorro", "Emergencia", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cachorro", "Emergencia");
            DropColumn("dbo.Cachorro", "Raio");
        }
    }
}
