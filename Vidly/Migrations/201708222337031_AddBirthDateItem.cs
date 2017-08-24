namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateItem : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Custumers SET BirthDate = '1985/09/02' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
