using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPelicula.Models
{
    public class Pelicula
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]

        public string Titulo { get; set; }
        [Display(Name = "Fecha de Lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]

        public DateTime FechaLanzamiento { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genero { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]
        public string Calificacion { get; set; }
        public string Productor { get; set; }
        [Display(Name = "Director")]
        public int? DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public virtual Director Director { get; set; }


    }
    public class PeliculaDBContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }

        public System.Data.Entity.DbSet<MvcPelicula.Models.Director> Directors { get; set; }
    }
}