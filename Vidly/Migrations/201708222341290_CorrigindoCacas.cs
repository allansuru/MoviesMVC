namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoCacas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custumers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {          
            DropColumn("dbo.Custumers", "BirthDate");
        }
    }
}
