namespace DMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "MemberName", c => c.String());
            AlterColumn("dbo.Members", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Username", c => c.String());
            DropColumn("dbo.Members", "MemberName");
        }
    }
}
