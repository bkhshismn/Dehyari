namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBEdNoTitle : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BedNo", name: "BedNo", newName: "BedNoTitle");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.BedNo", name: "BedNoTitle", newName: "BedNo");
        }
    }
}
