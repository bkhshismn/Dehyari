namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationPEsronHesabToDehyariHesab2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DehyariHesab", name: "PersonHesabID_HesabID", newName: "PersonHesabID");
            RenameIndex(table: "dbo.DehyariHesab", name: "IX_PersonHesabID_HesabID", newName: "IX_PersonHesabID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DehyariHesab", name: "IX_PersonHesab_HesabID", newName: "IX_PersonHesabID");
            RenameColumn(table: "dbo.DehyariHesab", name: "PersonHesab_HesabID", newName: "PersonHesabID");
        }
    }
}
