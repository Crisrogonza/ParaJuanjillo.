namespace ApiPeliculasFinalEstasi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Principal")]
    public partial class Principal
    {
        [Key]
        [Column("Id_principal ")]
        public int Id_principal_ { get; set; }

        [StringLength(50)]
        public string Nombre_pelicula { get; set; }

        [StringLength(15)]
        public string Año { get; set; }

        [StringLength(15)]
        public string Duracion { get; set; }

        public int? Productora { get; set; }

        public int? Genero { get; set; }

        public int? Director { get; set; }

        //public virtual Director Director1 { get; set; }

        //public virtual Genero Genero1 { get; set; }

        //public virtual Productora Productora1 { get; set; }
    }
}
