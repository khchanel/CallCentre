namespace CallCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCallLogModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                        CallDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallLogs", "ContactId", "dbo.Contacts");
            DropIndex("dbo.CallLogs", new[] { "ContactId" });
            DropTable("dbo.CallLogs");
        }
    }
}
