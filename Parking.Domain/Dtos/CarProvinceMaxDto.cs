using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Dtos
{
	public class CarProvinceMaxDto
	{
		public int ProvinceCode { get; set; }
		public string ProvinceName { get; set; }
		public int Total { get; set; }
	}
}
