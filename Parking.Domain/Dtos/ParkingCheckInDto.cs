using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class ParkingCheckInDto
	{
		public DateTime Timein { get; set; }
		public string LicensePlate { get; set; }
		public int ProvinceCode { get; set; }
		public int CreatedBy { get; set; }
	}
}
