namespace ApiPeliculasFinalEstasi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Productora")]
    public partial class Productora
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Productora()
        //{
        //    Principal = new HashSet<Principal>();
        //}

        [Key]
        public int Id_productora { get; set; }

        [StringLength(50)]
        public string Nombre_productora { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Principal> Principal { get; set; }
    }
}
