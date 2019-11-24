using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parking.Domain.Entities
{
	public class Province
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ProvinceCode { get; set; }
		public string ProvinceName { get; set; }
		public ICollection<ParkingRecord> ParkingRecords { get; set; }
	}
}
