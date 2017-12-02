namespace TrialsAutumn2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kossomy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsActivated", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "ActivationKey", c => c.String());
            AddColumn("dbo.AspNetUsers", "PasswordRestoreKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PasswordRestoreKey");
            DropColumn("dbo.AspNetUsers", "ActivationKey");
            DropColumn("dbo.AspNetUsers", "IsActivated");
        }
    }
}
