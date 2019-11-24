using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class ParkingRecordDto
	{
		public DateTime Timein { get; set; }
		public string LicensePlate { get; set; }
		public int ProvinceCode { get; set; }
		public string ProvinceName { get; set; }
		public int CreatedBy { get; set; }
		public DateTime? TimeOut { get; set; }
		public int UpdateBy { get; set; }
		public double TotalPrice { get; set; }
	}
}
