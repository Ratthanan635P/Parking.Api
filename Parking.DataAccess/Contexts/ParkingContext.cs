using Microsoft.EntityFrameworkCore;
using Parking.DataAccess.DataMaster;
using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Parking.DataAccess.Contexts
{
	public class ParkingContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Province> Provinces { get; set; }
		public DbSet<ParkingRecord> ParkingRecords { get; set; }
		public DbSet<ParkingRate> ParkingRates { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=ParkingDB;Trusted_Connection=True;Integrated Security = false;User Id =sa;Password=yourStrong(!)Password");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			ListProvince listProvince = new ListProvince();
			modelBuilder.Entity<Province>().HasData(listProvince.Provinces);

			//modelBuilder.Entity<User>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
			//modelBuilder.Entity<User>()
			//.Property<bool>("IsDeleted");
		}
	}
}
