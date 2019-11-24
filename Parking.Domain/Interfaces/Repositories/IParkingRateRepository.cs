using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Interfaces.Repositories
{
	public interface IParkingRateRepository
	{
		// get parkingRate all order by order 
		List<ParkingRateDto> GetParkingRate();
		// add parkingRate by userId
		void AddParkingRate(ParkingRateDto parkingRateDto);
		// update parkingRate by parkingRateDto
		void UpdateParkingRate(ParkingRateDto parkingRateDto);

	}
}
