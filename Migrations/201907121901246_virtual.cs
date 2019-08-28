namespace Raw_Vidly_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _virtual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMovies",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Movie_MovieId })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Movie_MovieId);
            
            AddColumn("dbo.Customers", "MoviesId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "CustomersId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.CustomerMovies", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.CustomerMovies", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Movies", "CustomersId");
            DropColumn("dbo.Customers", "MoviesId");
            DropTable("dbo.CustomerMovies");
        }
    }
}
