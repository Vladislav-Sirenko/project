namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullOpenResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "FullOpenAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "FullOpenAnswer");
        }
    }
}
