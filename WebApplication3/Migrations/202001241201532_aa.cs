namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kargocu", "TcNo", c => c.Int());
            AlterColumn("dbo.Kargocu", "TelNo", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kargocu", "TelNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Kargocu", "TcNo", c => c.Int(nullable: false));
        }
    }
}
