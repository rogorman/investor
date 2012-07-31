namespace Investitee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvestorContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Investor_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Investors", t => t.Investor_id)
                .Index(t => t.Investor_id);
            
            AddColumn("dbo.Investors", "FundSize", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.InvestorContacts", new[] { "Investor_id" });
            DropForeignKey("dbo.InvestorContacts", "Investor_id", "dbo.Investors");
            DropColumn("dbo.Investors", "FundSize");
            DropTable("dbo.InvestorContacts");
        }
    }
}
