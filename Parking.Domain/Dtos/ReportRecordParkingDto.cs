using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class ReportRecordParkingDto
	{
		public List<ParkingRecordDto> ListParkingRecords { get; set; }
		public double TotalPrice { get; set; }
	}
	
}
