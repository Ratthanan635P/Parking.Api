using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Entities
{
	public class User:BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public DateTime? UpdateDate { get; set; }
		public int ActiveStatus { get; set; }
		public bool IsAdministrator { get; set; }
		public ICollection<ParkingRecord> ParkingRecordCretedBy { get; set; }
		public ICollection<ParkingRecord> ParkingRecordUpdatedBy { get; set; }
	}
}
