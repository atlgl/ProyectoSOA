namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloTiendaLinea : DbContext
    {
        public ModeloTiendaLinea()
            : base("name=ModeloTiendaLinea")
        {
        }

        public virtual DbSet<almacen> almacen { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<compras> compras { get; set; }
        public virtual DbSet<detalle_compra> detalle_compra { get; set; }
        public virtual DbSet<estado_compra> estado_compra { get; set; }
        public virtual DbSet<estado_pedido> estado_pedido { get; set; }
        public virtual DbSet<horario> horario { get; set; }
        public virtual DbSet<lista_deseos> lista_deseos { get; set; }
        public virtual DbSet<modulos> modulos { get; set; }
        public virtual DbSet<ofertas> ofertas { get; set; }
        public virtual DbSet<pagos> pagos { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<permisos> permisos { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<ranking_producto> ranking_producto { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<turno> turno { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<vendedores> vendedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<almacen>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<almacen>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .Property(e => e.tipo_categoria)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .HasMany(e => e.lista_deseos)
                .WithRequired(e => e.clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<compras>()
                .Property(e => e.forma_pago)
                .IsUnicode(false);

            modelBuilder.Entity<detalle_compra>()
                .HasMany(e => e.compras)
                .WithRequired(e => e.detalle_compra)
                .HasForeignKey(e => e.id_detalle_compra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<estado_compra>()
                .Property(e => e.tipo_estado)
                .IsUnicode(false);

            modelBuilder.Entity<estado_pedido>()
                .Property(e => e.tipo_de_estado)
                .IsUnicode(false);

            modelBuilder.Entity<modulos>()
                .Property(e => e.nombremodulo)
                .IsUnicode(false);

            modelBuilder.Entity<modulos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ofertas>()
                .Property(e => e.precio)
                .HasPrecision(10, 3);

            modelBuilder.Entity<ofertas>()
                .Property(e => e.descuento)
                .HasPrecision(10, 3);

            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.precio)
                .HasPrecision(10, 3);

            modelBuilder.Entity<producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ranking_producto>()
                .Property(e => e.popularidad)
                .HasPrecision(5, 0);

            modelBuilder.Entity<roles>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<roles>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<turno>()
                .Property(e => e.tipo_turno)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<vendedores>()
                .Property(e => e.nombre_vendedor)
                .IsUnicode(false);

            modelBuilder.Entity<vendedores>()
                .Property(e => e.apellido_paterno)
                .IsUnicode(false);

            modelBuilder.Entity<vendedores>()
                .Property(e => e.apellido_materno)
                .IsUnicode(false);

            modelBuilder.Entity<vendedores>()
                .Property(e => e.telefono)
                .IsUnicode(false);
        }
    }
}
