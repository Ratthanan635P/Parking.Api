using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DataAccess.Configuretions
{
	public class ProvinceConfiguretion : IEntityTypeConfiguration<Province>
	{
		public void Configure(EntityTypeBuilder<Province> builder)
		{
			builder.Property(x => x.ProvinceName).HasMaxLength(50);
		}
	}
}
