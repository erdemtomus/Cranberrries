namespace Cranberrries.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
//            Sql(@"
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7690342b-2464-4c6a-9d90-d35d7e52e4bb', N'3d0b7abd-c405-4c8b-b7be-aef867937959')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9024c3b6-ceaf-4ace-8d23-66af694632b7', N'd27bb633-8eb6-4408-a4e1-5597f1634cc9')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'91a56702-5d83-4836-b917-7a1ba5bed315', N'd27bb633-8eb6-4408-a4e1-5597f1634cc9')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab32b84e-f566-4a2d-b283-fa8ab2dbb086', N'd27bb633-8eb6-4408-a4e1-5597f1634cc9')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be0bb220-140c-4823-9cf5-f2ef41e213d3', N'd27bb633-8eb6-4408-a4e1-5597f1634cc9')
//");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
        }
    }
}
