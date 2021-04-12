namespace HypeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingShows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "NextReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "NextReleaseDate");
        }
    }
}
