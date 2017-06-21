namespace Cranberrries.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d0b7abd-c405-4c8b-b7be-aef867937959', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd27bb633-8eb6-4408-a4e1-5597f1634cc9', N'CanBeSongWriter')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9024c3b6-ceaf-4ace-8d23-66af694632b7', N'noel@linatomus.com', 0, N'ACQpXMikV9srKFFHu74+hV7yCAy34CdJhXqwIxUXSrgq8oRROEgK3sChzs8nB/TMmA==', N'e29d0cd8-4d6e-4614-a310-99fcd6bc58e0', NULL, 0, 0, NULL, 1, 0, N'noel@linatomus.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'91a56702-5d83-4836-b917-7a1ba5bed315', N'fergal@linatomus.com', 0, N'AOnRb/0amZPGQOntUF76NW+c3dYfF337bA97zruyByVg0ZOojRrLcdjhLjPn5IkQ6Q==', N'43747d37-a465-4bce-a72e-e0daa30a96bd', NULL, 0, 0, NULL, 1, 0, N'fergal@linatomus.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab32b84e-f566-4a2d-b283-fa8ab2dbb086', N'mike@linatomus.com', 0, N'AOkEdhw8LhVkF3+6Ca0Lcvo9/9R3dxEOEZeoQxXCk/v6MT81mTyU2DbPD+rBSM3Ihg==', N'9573943c-bbcb-4aaf-865e-7bdb1a48a989', NULL, 0, 0, NULL, 1, 0, N'mike@linatomus.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'be0bb220-140c-4823-9cf5-f2ef41e213d3', N'dolores@linatomus.com', 0, N'AKQpVXR0mCig9sP11VvLNNmQ3QV4CiZC9Khalp7t5LcZrQIsRqsvRMGefNx1n9Fpvg==', N'669d97ed-5944-459d-80e9-1ef952c813c1', NULL, 0, 0, NULL, 1, 0, N'dolores@linatomus.com')
");
        }
        
        public override void Down()
        {
        }
    }
}
