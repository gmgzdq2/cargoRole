namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Durum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Durum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Durum");
        }
    }
}
