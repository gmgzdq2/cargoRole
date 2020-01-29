namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KargoSirketi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoSirketi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        VergiNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoSirketi");
        }
    }
}
