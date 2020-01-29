namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aab : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kargocu", "TcNo", c => c.String());
            AlterColumn("dbo.Kargocu", "TelNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kargocu", "TelNo", c => c.Int());
            AlterColumn("dbo.Kargocu", "TcNo", c => c.Int());
        }
    }
}
