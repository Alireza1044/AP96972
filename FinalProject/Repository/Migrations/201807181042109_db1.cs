namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notes", "LightColor", c => c.String());
            AddColumn("dbo.notes", "DarkColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.notes", "DarkColor");
            DropColumn("dbo.notes", "LightColor");
        }
    }
}
