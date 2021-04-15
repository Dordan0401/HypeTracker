namespace HypeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PosterUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "PosterUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "PosterUrl");
        }
    }
}
