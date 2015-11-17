namespace RU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chapter4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Instructor", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Instructor", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorId })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorId);

            // Create  a department for course to point to.
            Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            ////  default value for FK points to department created above.
            AddColumn("dbo.Course", "DepartmentId", c => c.Int(nullable: false, defaultValue:1));
            AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 50));
            AddForeignKey("dbo.Course", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            CreateIndex("dbo.Course", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseInstructor", new[] { "InstructorId" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.Department", new[] { "InstructorId" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorId" });
            DropIndex("dbo.Course", new[] { "DepartmentId" });
            DropForeignKey("dbo.CourseInstructor", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Department", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.OfficeAssignment", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Department");
            AlterColumn("dbo.Course", "Title", c => c.String());
            DropColumn("dbo.Course", "DepartmentId");
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.Department");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Instructor");
        }
    }
}
