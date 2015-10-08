namespace DMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Username = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LookingFor = c.String(),
                        Introduction = c.String(),
                        Pitch = c.String(),
                        Demographics_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Demographics", t => t.Demographics_Id)
                .Index(t => t.Demographics_Id);
            
            CreateTable(
                "dbo.Demographics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        CityTown = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestType_Id = c.Int(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterestTypes", t => t.InterestType_Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.InterestType_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.InterestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        IsMain = c.Boolean(nullable: false),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        MessageSent = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Favourites", new[] { "MemberId" });
            DropIndex("dbo.Messages", new[] { "Member_Id" });
            DropIndex("dbo.Photos", new[] { "Profile_Id" });
            DropIndex("dbo.Interests", new[] { "Profile_Id" });
            DropIndex("dbo.Interests", new[] { "InterestType_Id" });
            DropIndex("dbo.Profiles", new[] { "Demographics_Id" });
            DropIndex("dbo.Members", new[] { "Id" });
            DropForeignKey("dbo.Favourites", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Messages", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Photos", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Interests", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Interests", "InterestType_Id", "dbo.InterestTypes");
            DropForeignKey("dbo.Profiles", "Demographics_Id", "dbo.Demographics");
            DropForeignKey("dbo.Members", "Id", "dbo.Profiles");
            DropTable("dbo.Favourites");
            DropTable("dbo.Messages");
            DropTable("dbo.Photos");
            DropTable("dbo.InterestTypes");
            DropTable("dbo.Interests");
            DropTable("dbo.Demographics");
            DropTable("dbo.Profiles");
            DropTable("dbo.Members");
        }
    }
}
