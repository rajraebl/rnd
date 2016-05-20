namespace RU4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chap7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "CourseId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "CourseId", c => c.Int(nullable: false));
        }
    }
}
