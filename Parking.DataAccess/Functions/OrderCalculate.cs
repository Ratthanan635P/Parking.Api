using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DataAccess
{
	public class OrderCalculate
	{
		public long Deduction { get; set; }
		public double TaxRate { get; set; }
		public double TaxMoney { get; set; }
	}
}
