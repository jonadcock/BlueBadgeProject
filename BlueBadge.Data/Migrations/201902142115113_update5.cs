namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "CourseRatings", c => c.Single(nullable: false));
            DropColumn("dbo.Course", "CourseRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "CourseRating", c => c.Single(nullable: false));
            DropColumn("dbo.Course", "CourseRatings");
        }
    }
}
