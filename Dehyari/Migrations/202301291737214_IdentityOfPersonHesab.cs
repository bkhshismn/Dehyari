namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityOfPersonHesab : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PersonHesab");
            AlterColumn("dbo.PersonHesab", "HesabID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PersonHesab", "HesabID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonHesab");
            AlterColumn("dbo.PersonHesab", "HesabID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PersonHesab", "HesabID");
        }
    }
}
