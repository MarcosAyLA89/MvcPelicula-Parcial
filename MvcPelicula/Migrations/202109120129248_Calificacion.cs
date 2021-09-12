namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "Calificacion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peliculas", "Calificacion");
        }
    }
}
