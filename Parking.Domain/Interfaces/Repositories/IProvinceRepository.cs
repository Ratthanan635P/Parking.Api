using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Interfaces.Repositories
{
	public interface IProvinceRepository
	{
		List<ProvinceDto> GetProvinceAll();
	}
}
