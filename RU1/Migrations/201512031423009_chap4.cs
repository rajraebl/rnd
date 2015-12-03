namespace RU1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chap4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructor", "LastName", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Instructor", "FirstName", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructor", "FirstName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Instructor", "LastName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
