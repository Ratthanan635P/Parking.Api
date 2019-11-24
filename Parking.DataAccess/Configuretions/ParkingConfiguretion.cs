using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DataAccess.Configuretions
{
	public class ParkingConfiguretion : IEntityTypeConfiguration<ParkingRecord>
	{
		public void Configure(EntityTypeBuilder<ParkingRecord> builder)
		{
			builder.Property(x => x.LicensePlate).HasMaxLength(10);
			builder.HasOne(x => x.Province).WithMany(x => x.ParkingRecords).HasForeignKey(x => x.ProvinceCode);
			builder.HasOne(x => x.UpdatedBy).WithMany(x => x.ParkingRecordUpdatedBy);
			builder.HasOne(x => x.CreatedBy).WithMany(x => x.ParkingRecordCretedBy);
		}
	}
}
