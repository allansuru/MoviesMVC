namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custumers", "BirtDate", c => c.DateTime());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.Custumers", "BirtDate");
        }
    }
}
