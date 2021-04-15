namespace HypeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Game", "ReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Show", "PremierDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Show", "NextReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Show", "NextReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Show", "PremierDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Game", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
