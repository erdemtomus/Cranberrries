namespace Cranberrries.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdtoString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Lyrics", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Songs", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Songs", "Lyrics");
        }
    }
}
