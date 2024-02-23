using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class GestionPiscinasContext : DbContext
{
    public GestionPiscinasContext()
    {
    }

    public GestionPiscinasContext(DbContextOptions<GestionPiscinasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Piscina> Piscinas { get; set; }

    public virtual DbSet<PiscinaProducto> PiscinaProductos { get; set; }

    public virtual DbSet<PiscinaRepuesto> PiscinaRepuestos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<sp_GetAllClientes_Result> Sp_GetAllClientes_Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANDRES\\SQLEXPRESS;Database=GestionPiscinas;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD0A78B1C6FD6");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F02E4A6925");

            entity.ToTable("Empleado");

            entity.Property(e => e.EmpleadoId)
                .ValueGeneratedNever()
                .HasColumnName("EmpleadoID");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Piscina>(entity =>
        {
            entity.HasKey(e => e.PiscinaId).HasName("PK__Piscina__692645523B86234F");

            entity.ToTable("Piscina");

            entity.Property(e => e.PiscinaId)
                .ValueGeneratedNever()
                .HasColumnName("PiscinaID");
            entity.Property(e => e.Tamano)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Empleados).WithMany(p => p.Piscinas)
                .UsingEntity<Dictionary<string, object>>(
                    "PiscinaEmpleado",
                    r => r.HasOne<Empleado>().WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Piscina_E__Emple__5441852A"),
                    l => l.HasOne<Piscina>().WithMany()
                        .HasForeignKey("PiscinaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Piscina_E__Pisci__534D60F1"),
                    j =>
                    {
                        j.HasKey("PiscinaId", "EmpleadoId").HasName("PK__Piscina___707EFB3D9E5395B9");
                        j.ToTable("Piscina_Empleado");
                        j.IndexerProperty<int>("PiscinaId").HasColumnName("PiscinaID");
                        j.IndexerProperty<int>("EmpleadoId").HasColumnName("EmpleadoID");
                    });

            entity.HasMany(d => d.Servicios).WithMany(p => p.Piscinas)
                .UsingEntity<Dictionary<string, object>>(
                    "PiscinaServicio",
                    r => r.HasOne<Servicio>().WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Piscina_S__Servi__59FA5E80"),
                    l => l.HasOne<Piscina>().WithMany()
                        .HasForeignKey("PiscinaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Piscina_S__Pisci__59063A47"),
                    j =>
                    {
                        j.HasKey("PiscinaId", "ServicioId").HasName("PK__Piscina___547CAB90FD627C59");
                        j.ToTable("Piscina_Servicio");
                        j.IndexerProperty<int>("PiscinaId").HasColumnName("PiscinaID");
                        j.IndexerProperty<int>("ServicioId").HasColumnName("ServicioID");
                    });
        });

        modelBuilder.Entity<PiscinaProducto>(entity =>
        {
            entity.HasKey(e => new { e.PiscinaId, e.ProductoId }).HasName("PK__Piscina___43654FBA8DB7464C");

            entity.ToTable("Piscina_Producto");

            entity.Property(e => e.PiscinaId).HasColumnName("PiscinaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Piscina).WithMany(p => p.PiscinaProductos)
                .HasForeignKey(d => d.PiscinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Piscina_P__Pisci__6477ECF3");

            entity.HasOne(d => d.Producto).WithMany(p => p.PiscinaProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Piscina_P__Produ__656C112C");
        });

        modelBuilder.Entity<PiscinaRepuesto>(entity =>
        {
            entity.HasKey(e => new { e.PiscinaId, e.RepuestoId }).HasName("PK__Piscina___3E7D75253B6EC946");

            entity.ToTable("Piscina_Repuesto");

            entity.Property(e => e.PiscinaId).HasColumnName("PiscinaID");
            entity.Property(e => e.RepuestoId).HasColumnName("RepuestoID");

            entity.HasOne(d => d.Piscina).WithMany(p => p.PiscinaRepuestos)
                .HasForeignKey(d => d.PiscinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Piscina_R__Pisci__60A75C0F");

            entity.HasOne(d => d.Repuesto).WithMany(p => p.PiscinaRepuestos)
                .HasForeignKey(d => d.RepuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Piscina_R__Repue__619B8048");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83140BEF74");

            entity.ToTable("Producto");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.RepuestoId).HasName("PK__Repuesto__75B3077478106D70");

            entity.ToTable("Repuesto");

            entity.Property(e => e.RepuestoId)
                .ValueGeneratedNever()
                .HasColumnName("RepuestoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reserva__C39937034C85F981");

            entity.ToTable("Reserva");

            entity.Property(e => e.ReservaId)
                .ValueGeneratedNever()
                .HasColumnName("ReservaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.PiscinaId).HasColumnName("PiscinaID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Reserva__Cliente__4D94879B");

            entity.HasOne(d => d.Piscina).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PiscinaId)
                .HasConstraintName("FK__Reserva__Piscina__4E88ABD4");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("PK__Servicio__D5AEEC22F03384B5");

            entity.ToTable("Servicio");

            entity.Property(e => e.ServicioId)
                .ValueGeneratedNever()
                .HasColumnName("ServicioID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
