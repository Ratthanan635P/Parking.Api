using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class ParkingRateDto
	{
		public int Id { get; set; }
		public double Rate { get; set; }
		public int Hours { get; set; }
		public int Order { get; set; }
		public int IsUsed { get; set; }
	}
}
