namespace RU1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollmentInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            AlterColumn("dbo.Student", "StudentId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Student", new[] { "StudentID" });
            AddPrimaryKey("dbo.Student", "StudentId");
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "StudentId", cascadeDelete: true);
            CreateIndex("dbo.Enrollment", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropPrimaryKey("dbo.Student", new[] { "StudentId" });
            AddPrimaryKey("dbo.Student", "StudentID");
            AlterColumn("dbo.Student", "StudentID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Enrollment", "StudentId");
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "StudentID", cascadeDelete: true);
        }
    }
}
