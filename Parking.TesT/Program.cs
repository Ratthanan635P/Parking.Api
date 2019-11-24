using Parking.DataAccess.Contexts;
using Parking.DataAccess.Repositories;
using Parking.Domain.Dtos;
using Parking.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.TesT
{
	class Program
	{
		static void Main(string[] args)
		{
			ParkingContext _context = new ParkingContext();

			IProvinceRepository Province = new ProvinceRepository(_context);
			var Provinces = Province.GetProvinceAll();
			foreach (var item in Provinces)
			{
				Console.WriteLine("{0} :{1}", item.ProvinceCode, item.ProvinceName);
			}

			IParkingRateRepository rate = new ParkingRateRepository(_context);
			var ParkingRate = rate.GetParkingRate();
			foreach (var item in ParkingRate)
			{
				Console.WriteLine("{0} :{1} :{2} :{3} ", item.Id, item.Rate,item.Hours,item.Order);
			}

			IUserRepository users = new UserRepository(_context);
			var admin = users.GetUserIdByUserName("Admin");
			Console.WriteLine("UserId Admin :{0}", admin.Id);

			IParkingRecordRepository parking = new ParkingRecordRepository(_context);
			var totalcar = parking.GetCarParking();
			Console.WriteLine("TotalCar :{0}", totalcar);
			var daetail = parking.GetDataParkingRecordById(5);
			if (daetail != null)
			{
				Console.WriteLine("License :{0}", daetail.LicensePlate);
				Console.WriteLine("ProvinceCode :{0}", daetail.ProvinceCode);
				Console.WriteLine("TimeIn :{0}", daetail.Timein);
				Console.WriteLine("TimeOut :{0}", daetail.TimeOut);
				Console.WriteLine("TotalPrice:{0:C2}", daetail.TotalPrice);
			}
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("---------------------CheckbalanceByYear---------------------");
			Console.WriteLine("------------------------------------------------------------");
			var daetail5 = parking.CheckbalanceByYear(2019);
		
			if (daetail5 != null)
			{
				var totalprice = daetail5.TotalPrice;
				Console.WriteLine("Totalprice :{0:C2}", totalprice);
				foreach (var item in daetail5.ListParkingRecords)
				{
					Console.WriteLine("License :{0}", item.LicensePlate);
					Console.WriteLine("ProvinceCode :{0}", item.ProvinceCode);
					Console.WriteLine("TimeIn :{0}", item.Timein);
					Console.WriteLine("TimeOut :{0}", item.TimeOut);
					Console.WriteLine("TotalPrice:{0:C2}", item.TotalPrice);
				}				
			}

			//var useMax = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout == null)
			//	.GroupBy(x => x.ProvinceCode, (x, y) => new
			//	{
			//		ProvinceName = y.Max(z => z.ProvinceCode),
			//		Total = x,
			//	}).ToList();
			//foreach (var item in useMax)
			//{
			//	Console.WriteLine("Total :{0}", item.Total);
			//	Console.WriteLine("ProvinceName :{0}", item.ProvinceName);
			//}
			//var grouped = from b in _context.ParkingRecords
			//			  group b.Id by b.Province.ProvinceName into g
			//			  select new
			//			  {
			//				  Key = g.Key,
			//				  Unit = g.Count()
			//			  };
			//var result = grouped.ToList().OrderByDescending(x=>x.Unit);
			var result = parking.GetTopProvinceUse();

			foreach (var item in result)
			{
				Console.WriteLine("ProvinceName :{0}", item.ProvinceName);
				Console.WriteLine("Unit :{0}", item.Total);
			}
		}
	}
}
