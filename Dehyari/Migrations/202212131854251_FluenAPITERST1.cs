namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluenAPITERST1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 65));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Name", c => c.String());
        }
    }
}
