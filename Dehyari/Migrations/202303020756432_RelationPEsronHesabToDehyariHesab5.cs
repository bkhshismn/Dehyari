namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationPEsronHesabToDehyariHesab5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DehyariHesab", "PersonHesabID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DehyariHesab", "PersonHesabID");
        }
    }
}
