namespace DMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photourlx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "Url");
        }
    }
}
