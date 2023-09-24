namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDSMSHeaderFoooterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMSHeaderFooter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(maxLength: 500),
                        Footer = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SMSHeaderFooter");
        }
    }
}
