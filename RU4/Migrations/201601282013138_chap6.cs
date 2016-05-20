namespace RU4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chap6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructor", "LastName", c => c.String(nullable: false, maxLength: 15));
            Sql("SET IDENTITY_INSERT Course ON");

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructor", "LastName", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
