namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KargocuId = c.Int(nullable: false),
                        DurumID = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Durum", t => t.DurumID, cascadeDelete: true)
                .ForeignKey("dbo.Kargocu", t => t.KargocuId, cascadeDelete: true)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.KargocuId)
                .Index(t => t.DurumID)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Urun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kargo", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.Kargo", "KargocuId", "dbo.Kargocu");
            DropForeignKey("dbo.Kargo", "DurumID", "dbo.Durum");
            DropIndex("dbo.Kargo", new[] { "UrunId" });
            DropIndex("dbo.Kargo", new[] { "DurumID" });
            DropIndex("dbo.Kargo", new[] { "KargocuId" });
            DropTable("dbo.Urun");
            DropTable("dbo.Kargo");
        }
    }
}
