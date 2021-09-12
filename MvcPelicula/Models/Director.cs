using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPelicula.Models
{
    public class Director
    {
        [Key]
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }

        public int Edad { get; set; }

        public int TotalPeliculas { get; set; }
        
    }
    public class DirectorDBContext : DbContext
    {
        public DbSet<Director> Peliculas { get; set; }

        public System.Data.Entity.DbSet<MvcPelicula.Models.Director> Directors { get; set; }
    }

}