using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Context : DbContext
	{
		private readonly string _connectionString;

		public Context()
		{
            var server = "studentws.database.windows.net";
			var database = "backendws";
			var user = "studentuser";
            var password = "******";

            _connectionString = $"Server={server};Initial Catalog={database};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Constants.schema);

            modelBuilder.Entity<Artikel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Artikel__3214EC277F64688C");

                entity.ToTable("Artikel", Constants.schema);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Namn).HasMaxLength(255);
                entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Kund>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Kund__3214EC2728A49AC1");

                entity.ToTable("Kund", Constants.schema);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Adress).HasMaxLength(255);
                entity.Property(e => e.Mejl).HasMaxLength(255);
                entity.Property(e => e.Namn).HasMaxLength(255);
            });

            modelBuilder.Entity<Lagersaldo>(entity =>
            {
                entity.HasKey(e => e.ArtikelId).HasName("PK__Lagersal__CB7A944D023DCC8D");

                entity.ToTable("Lagersaldo", Constants.schema);

                entity.Property(e => e.ArtikelId)
                    .ValueGeneratedNever()
                    .HasColumnName("ArtikelID");

                entity.HasOne(d => d.Artikel).WithOne(p => p.Lagersaldo)
                    .HasForeignKey<Lagersaldo>(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lagersald__Artik__5FB337D6");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber).HasName("PK__Order__CAC5E742FA55DCC3");

                entity.ToTable("Order", Constants.schema);

                entity.Property(e => e.DatumSkapad).HasColumnType("datetime");
                entity.Property(e => e.KundId).HasColumnName("KundID");
                entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Kund).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.KundId)
                    .HasConstraintName("FK__Order__KundID__693CA210");

                entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Order__StatusID__6A30C649");
            });

            modelBuilder.Entity<OrderRad>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.ArtikelId }).HasName("PK__OrderRad__06724E069265DD64");

                entity.ToTable("OrderRad", Constants.schema);

                entity.Property(e => e.ArtikelId).HasColumnName("ArtikelID");
                entity.Property(e => e.DatumSkapad).HasColumnType("datetime");
                entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Artikel).WithMany(p => p.OrderRads)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderRad__Artike__628FA481");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Status__3214EC27DB09AFA0");

                entity.ToTable("Status", Constants.schema);

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Typ).HasMaxLength(255);
            });


            base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
			base.OnConfiguring(optionsBuilder);
		}

        public virtual DbSet<Artikel> Artiklar { get; set; }

        public virtual DbSet<Kund> Kunder { get; set; }

        public virtual DbSet<Lagersaldo> Lagersaldos { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderRad> OrderRader { get; set; }

        public virtual DbSet<Status> Statusar { get; set; }

    }

}
