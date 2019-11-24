using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DataAccess.Configuretions
{
	public class UserConfiguretion : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.UserName).HasMaxLength(50);
			builder.Property(x => x.Salt).HasMaxLength(20);
			builder.Property(x => x.Password).HasMaxLength(150);
		}
	}
}
