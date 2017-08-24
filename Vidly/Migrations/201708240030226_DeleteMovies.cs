namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, Genre_Id) VALUES ('BladeRunner',1,2017/08/23, 1988/01/01, 10,1)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, Genre_Id) VALUES ('Final Fantasy',2,2017/08/23, 2017/01/01, 10,2)");
        }
        
        public override void Down()
        {
        }
    }
}
