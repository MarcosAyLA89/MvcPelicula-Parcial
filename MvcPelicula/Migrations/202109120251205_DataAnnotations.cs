namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Peliculas", "Titulo", c => c.String(maxLength: 60));
            AlterColumn("dbo.Peliculas", "Genero", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Peliculas", "Calificacion", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Peliculas", "Calificacion", c => c.String());
            AlterColumn("dbo.Peliculas", "Genero", c => c.String());
            AlterColumn("dbo.Peliculas", "Titulo", c => c.String());
        }
    }
}
