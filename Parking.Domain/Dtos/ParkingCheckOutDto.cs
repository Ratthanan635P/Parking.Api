using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class ParkingCheckOutDto
	{
		public int Id { get; set; }
		public DateTime? TimeOut { get; set; }
		public int UpdateBy { get; set; } 
		public double TotalPrice { get; set; }
	}
}
