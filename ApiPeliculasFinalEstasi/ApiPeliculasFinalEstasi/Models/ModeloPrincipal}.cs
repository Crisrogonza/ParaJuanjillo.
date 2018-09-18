namespace ApiPeliculasFinalEstasi.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class ModeloPrincipal_ : DbContext
	{
		public ModeloPrincipal_()
			: base("name=ModeloPrincipal")
		{
		}

		public virtual DbSet<Director> Director { get; set; }
		public virtual DbSet<Genero> Genero { get; set; }
		public virtual DbSet<Principal> Principal { get; set; }
		public virtual DbSet<Productora> Productora { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Director>()
			//	.HasMany(e => e.Principal)
			//	.WithOptional(e => e.Director1)
			//	.HasForeignKey(e => e.Director);

			//modelBuilder.Entity<Genero>()
			//	.HasMany(e => e.Principal)
			//	.WithOptional(e => e.Genero1)
			//	.HasForeignKey(e => e.Genero);

			//modelBuilder.Entity<Productora>()
			//	.HasMany(e => e.Principal)
			//	.WithOptional(e => e.Productora1)
			//	.HasForeignKey(e => e.Productora);
		}
	}
}
