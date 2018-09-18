namespace ApiPeliculasFinalEstasi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Director")]
    public partial class Director
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Director()
        //{
        //    Principal = new HashSet<Principal>();
        //}

        [Key]
        public int Id_Director { get; set; }

        [StringLength(50)]
        public string Nombre_Director { get; set; }

        [StringLength(25)]
        public string Nacionalidad { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Principal> Principal { get; set; }
    }
}
