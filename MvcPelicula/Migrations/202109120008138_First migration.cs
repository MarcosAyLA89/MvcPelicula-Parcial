namespace MvcPelicula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Peliculas", "Precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Peliculas", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
