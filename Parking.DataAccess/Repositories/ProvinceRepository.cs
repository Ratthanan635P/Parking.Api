using Parking.DataAccess.Contexts;
using Parking.Domain.Dtos;
using Parking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.DataAccess.Repositories
{
	public class ProvinceRepository : IProvinceRepository
	{
		private readonly ParkingContext _context;
		public ProvinceRepository(ParkingContext context)
		{
			_context = context;
		}
		public List<ProvinceDto> GetProvinceAll()
		{
			//List<ProvinceDto> provinces = new List<ProvinceDto>();
			//var provinces = _context.Provinces.Select(u => new ProvinceDto()
			//{
			//	ProvinceCode = u.ProvinceCode,
			//	ProvinceName = u.ProvinceName
			//}).ToList();
			var provinces = _context.Provinces.ToList();
			var Data= provinces.Select(p => new ProvinceDto()
			{
				ProvinceCode=p.ProvinceCode,
				ProvinceName=p.ProvinceName
			}).ToList();
			return Data;
		}
	}
}
