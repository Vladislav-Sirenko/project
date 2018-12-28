namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClientProfiles", "Score");
            DropTable("dbo.Disciplines_classes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Disciplines_classes",
                c => new
                    {
                        Test_Id = c.Int(nullable: false, identity: true),
                        Discipline_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Test_Id);
            
            AddColumn("dbo.ClientProfiles", "Score", c => c.Int(nullable: false));
        }
    }
}
