namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kullanici : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        TcNo = c.String(),
                        Email = c.String(),
                        Sifre = c.String(),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kullanici", "RolId", "dbo.Rol");
            DropIndex("dbo.Kullanici", new[] { "RolId" });
            DropTable("dbo.Kullanici");
        }
    }
}
