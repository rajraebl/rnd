namespace RU4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chap5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OfficeAssignment", "Location", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OfficeAssignment", "Location", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
