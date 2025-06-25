namespace WebApplication11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPasswordFeatures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PasswordEntries", "LastAccessDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PasswordEntries", "IsFavorite", c => c.Boolean(nullable: false));
            AddColumn("dbo.PasswordEntries", "PasswordStrength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PasswordEntries", "PasswordStrength");
            DropColumn("dbo.PasswordEntries", "IsFavorite");
            DropColumn("dbo.PasswordEntries", "LastAccessDate");
        }
    }
}
