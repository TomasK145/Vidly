namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90b0defc-06b2-4c69-ad36-e6e56ca8a3a3', N'guest@vidly.com', 0, N'AEn+ZE9mKnY4m7Fm/xTJazS9yGxmi8H0+1DJYyr/9iXAbl+RHK39gMmMOmegfYmuJw==', N'c6b81f97-06eb-4875-9e1b-9d259561bd79', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a43afe26-b1b5-463c-bc50-5edc000fe937', N'admin@vidly.com', 0, N'ABjVC297u69Fa4YOF1BCPg9zbu9tc+Bo/yR2ZABrWpIyIVwH1t57cWaZWAmbdQMNug==', N'337895c1-ba6d-4647-b81b-e4bde5342a87', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'46ffb65d-f4e6-4526-afb2-1c545e84027e', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a43afe26-b1b5-463c-bc50-5edc000fe937', N'46ffb65d-f4e6-4526-afb2-1c545e84027e')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
