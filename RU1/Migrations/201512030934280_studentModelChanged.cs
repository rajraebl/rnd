namespace RU1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentModelChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Student", name: "FirstMidName", newName: "FirstName");
            AlterColumn("dbo.Student", "LastName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "LastName", c => c.String(maxLength: 50));
            RenameColumn(table: "dbo.Student", name: "FirstName", newName: "FirstMidName");
        }
    }
}
