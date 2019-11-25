using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.TesT
{
	public class CalculateTimeTotal
	{
		public DateTime TimeIn { get; private set; }
        public DateTime TimeOut { get; private set; }
        public int TotalHour { get; private set; }
		public CalculateTimeTotal(DateTime timeIn,DateTime timeOut)
		{
			TimeIn = timeIn;
			TimeOut = timeOut;
			TotalHour = CalculateTime(timeIn, timeOut);
		}
		public int CalculateTime(DateTime timeIn, DateTime timeOut)
		{
			TimeSpan timeSpan = timeOut - timeIn;
			double TotalMinutes = timeSpan.TotalMinutes;
			double Totalhour = TotalMinutes / 60.00;
			 Totalhour = Math.Ceiling(Totalhour);
			return (int)Totalhour;
		}

	}
}
