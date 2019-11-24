using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Entities
{
	public class ParkingRate: BaseEntity
	{
		public double Rate { get; set; }
		public int Hours { get; set; }
		public int IsUsed { get; set; }
		public int Order { get; set; }
	}
}
