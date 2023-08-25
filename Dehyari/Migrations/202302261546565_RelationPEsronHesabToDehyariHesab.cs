namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationPEsronHesabToDehyariHesab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DehyariHesab", "PersonHesabID", c => c.Int());
            AddColumn("dbo.DehyariHesab", "PersonHesab_HesabID", c => c.Int());
            CreateIndex("dbo.DehyariHesab", "PersonHesab_HesabID");
            AddForeignKey("dbo.DehyariHesab", "PersonHesab_HesabID", "dbo.PersonHesab", "HesabID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DehyariHesab", "PersonHesab_HesabID", "dbo.PersonHesab");
            DropIndex("dbo.DehyariHesab", new[] { "PersonHesab_HesabID" });
            DropColumn("dbo.DehyariHesab", "PersonHesab_HesabID");
            DropColumn("dbo.DehyariHesab", "PersonHesabID");
        }
    }
}
