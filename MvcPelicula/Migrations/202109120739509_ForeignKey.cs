namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "DirectorId", c => c.Int());
            CreateIndex("dbo.Peliculas", "DirectorId");
            AddForeignKey("dbo.Peliculas", "DirectorId", "dbo.Directors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peliculas", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Peliculas", new[] { "DirectorId" });
            DropColumn("dbo.Peliculas", "DirectorId");
        }
    }
}
