namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kargo", "SonIslemTarihi", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kargo", "SonIslemTarihi");
        }
    }
}
