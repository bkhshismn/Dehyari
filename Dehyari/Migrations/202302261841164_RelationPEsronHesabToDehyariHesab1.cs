namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationPEsronHesabToDehyariHesab1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DehyariHesab", name: "PersonHesab_HesabID", newName: "PersonHesabID_HesabID");
            RenameIndex(table: "dbo.DehyariHesab", name: "IX_PersonHesab_HesabID", newName: "IX_PersonHesabID_HesabID");
            DropColumn("dbo.DehyariHesab", "PersonHesabID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DehyariHesab", "PersonHesabID", c => c.Int());
            RenameIndex(table: "dbo.DehyariHesab", name: "IX_PersonHesabID_HesabID", newName: "IX_PersonHesab_HesabID");
            RenameColumn(table: "dbo.DehyariHesab", name: "PersonHesabID_HesabID", newName: "PersonHesab_HesabID");
        }
    }
}
