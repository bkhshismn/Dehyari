namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluenAPITERST : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Name", c => c.String(maxLength: 60));
        }
    }
}
