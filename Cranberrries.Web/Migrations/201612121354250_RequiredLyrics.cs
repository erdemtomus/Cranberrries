namespace Cranberrries.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredLyrics : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Lyrics", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Lyrics", c => c.String(storeType: "ntext"));
        }
    }
}
