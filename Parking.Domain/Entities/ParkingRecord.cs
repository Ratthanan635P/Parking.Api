using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Entities
{
	public class ParkingRecord: BaseEntity
	{
		public DateTime Timein { get; set; }
		public DateTime? Timeout { get; set; }
		public string LicensePlate { get; set; }
		public int ProvinceCode { get; set; }
		public Province Province { get; set; }
		public User CreatedBy { get; set; }
		public User UpdatedBy { get; set; }
		public double? TotalPrice { get; set; }
	}
}
