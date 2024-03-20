﻿using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
	public class Context : DbContext
	{
		private readonly string _connectionString;

		public Context()
		{
			_connectionString = "Server=tcp:ne-backend-ws.database.windows.net,1433;Initial Catalog=BackendWorkshop1;Persist Security Info=False;User ID=backendwsadmin;Password=BJ8HNsJLa6LbJTAHbpVs;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

		public DbSet<Artikel> Artikelar { get; set; }
		public DbSet<Kund> Kunder { get; set; }

	}

}
