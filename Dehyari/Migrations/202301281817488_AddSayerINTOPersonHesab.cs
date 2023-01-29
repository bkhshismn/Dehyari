namespace Dehyari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSayerINTOPersonHesab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonHesab", "Sayer", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonHesab", "Sayer");
        }
    }
}
