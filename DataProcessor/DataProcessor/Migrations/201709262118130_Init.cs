namespace DataProcessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 2147483647, unicode: false),
                        LastName = c.String(maxLength: 2147483647, unicode: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogs");
        }
    }
}
