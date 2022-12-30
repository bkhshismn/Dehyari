namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNerkhAb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JaygahZamin", "NerkhAb", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JaygahZamin", "NerkhAb");
        }
    }
}
