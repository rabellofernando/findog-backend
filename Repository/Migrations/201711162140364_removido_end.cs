namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removido_end : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Endereco", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}
