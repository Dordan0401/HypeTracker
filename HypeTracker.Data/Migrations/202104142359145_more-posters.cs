namespace HypeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreposters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "PosterUrl", c => c.String());
            AddColumn("dbo.Show", "PosterUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "PosterUrl");
            DropColumn("dbo.Game", "PosterUrl");
        }
    }
}
