using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
	public class Context : DbContext
	{
		private readonly string _connectionString;

		public Context()
		{
			var server = "localhost\\MSSQLSERVER02";
			var database = "BackendWS";
			var user = "";
			var password = "";
			//_connectionString = $"Server={server};Initial Catalog={database};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			_connectionString = $"Server={server};Initial Catalog={database};Persist Security Info=False;Integrated Security=True;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Constants.schema);

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Artikel> Artiklar { get; set; }
		public DbSet<Kund> Kunder { get; set; }

	}

}
