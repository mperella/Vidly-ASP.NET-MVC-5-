namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMovieProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    GenreId = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    AddDate = c.DateTime(nullable: false),
                    NumberInStock = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO GENRES (Name) VALUES ('Action')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Family')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Romance')");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
