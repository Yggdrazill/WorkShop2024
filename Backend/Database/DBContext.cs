using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Database.Entities;

namespace Database
{
	public class Context : DbContext
	{
		private readonly string _database;
		private readonly string _server;

		public Context()
		{
		}

		public Context(string server, string database)
		{
			_server = server;
			_database = database;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Constants.schema);

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = new SqlConnectionStringBuilder
			{
				DataSource = _server ?? "temp",
				InitialCatalog = _database ?? "temp",
				IntegratedSecurity = true
			}.ToString();

			optionsBuilder.UseSqlServer(connectionString);
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Item> Items { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

	}

}
