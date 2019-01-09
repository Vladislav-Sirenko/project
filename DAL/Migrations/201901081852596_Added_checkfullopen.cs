namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_checkfullopen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "IsFullOpenChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "IsFullOpenChecked");
        }
    }
}
