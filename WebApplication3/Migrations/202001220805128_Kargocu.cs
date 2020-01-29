namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargocu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kargocu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        TcNo = c.Int(nullable: false),
                        TelNo = c.Int(nullable: false),
                        KargoSirketiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KargoSirketi", t => t.KargoSirketiId, cascadeDelete: true)
                .Index(t => t.KargoSirketiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kargocu", "KargoSirketiId", "dbo.KargoSirketi");
            DropIndex("dbo.Kargocu", new[] { "KargoSirketiId" });
            DropTable("dbo.Kargocu");
        }
    }
}
