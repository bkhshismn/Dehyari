namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSarparasgtkhanevadAndKhanedarField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "SarparastKhanevar");
            DropColumn("dbo.Person", "SahebKhane");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "SahebKhane", c => c.Boolean());
            AddColumn("dbo.Person", "SarparastKhanevar", c => c.Boolean());
        }
    }
}
