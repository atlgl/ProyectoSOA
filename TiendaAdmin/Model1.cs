namespace TiendaAdmin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<roles> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<roles>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<roles>()
                .Property(e => e.descripcion)
                .IsUnicode(false);
        }
    }
}
