using Parking.DataAccess.Contexts;
using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.DataAccess.Repositories
{
	public class ParkingRateRepository : IParkingRateRepository
	{
		private readonly ParkingContext _context;
		public ParkingRateRepository(ParkingContext context)
		{
			_context = context;
		}
		public void AddParkingRate(ParkingRateDto parkingRateDto)
		{
			//throw new NotImplementedException();
			ParkingRate parkingRate = new ParkingRate()
			{
            Hours= parkingRateDto.Hours,
            IsUsed=1,
            Order= parkingRateDto.Order,
            Rate=parkingRateDto.Rate
			};
			_context.ParkingRates.Add(parkingRate);
			_context.SaveChanges();
		}

		public List<ParkingRateDto> GetParkingRate()
		{
			//throw new NotImplementedException();
			var rate = _context.ParkingRates.Where(pr => pr.IsUsed == 1).Select(p =>  new ParkingRateDto() {
            Id=p.Id,
            Rate=p.Rate,
			Hours=p.Hours,
			Order=p.Order,
			IsUsed=p.IsUsed
			}).ToList();
			return rate;
		}

		public void UpdateParkingRate(ParkingRateDto parkingRate)
		{
			var rate= _context.ParkingRates.Where(p => p.Id == parkingRate.Id).FirstOrDefault();
			if (rate != null)
			{
				rate.Hours = parkingRate.Hours;
				rate.IsUsed = parkingRate.IsUsed;
				rate.Order = parkingRate.Order;
				rate.Rate = parkingRate.Rate;
				_context.SaveChanges();
			}
			
		}
	}
}
