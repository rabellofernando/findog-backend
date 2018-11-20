namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status_cachorro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cachorro", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Dispositivo", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dispositivo", "Status");
            DropColumn("dbo.Cachorro", "Status");
        }
    }
}
