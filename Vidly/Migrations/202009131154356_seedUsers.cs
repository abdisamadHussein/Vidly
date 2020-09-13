namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40cde44b-eafd-4e6c-98cd-012d03299765', N'admin@vidly.com', 0, N'AHLTJxaWje1E+Vy+Aitz0N8t1pHz/hC2Dhm7FGnW9vaAjix7fiN2kbXfOhNDNmefdQ==', N'7ca0282f-425c-4ff9-9253-22eea5668e61', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'daf44d37-2a4a-4408-a6dc-df1ec492ba4f', N'guest@vidly.com', 0, N'APnUVWMFGIYxkFt0Ox8yvETbrzXJJEL53lNZt238xk5D0m//wWd1biJez3mGL8SYJg==', N'80402416-7315-40b5-9da9-42ac7d9f0b1e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'33250c0d-c091-4f4f-9a3d-a38cf83ea7fb', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'40cde44b-eafd-4e6c-98cd-012d03299765', N'33250c0d-c091-4f4f-9a3d-a38cf83ea7fb')

");
        }
        
        public override void Down()
        {
        }
    }
}
