using Parking.DataAccess.Contexts;
using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.DataAccess.Repositories
{
	public class ParkingRecordRepository : IParkingRecordRepository
	{
		private readonly ParkingContext _context;
		public ParkingRecordRepository(ParkingContext context)
		{
			_context = context;
		}
		public ReportRecordParkingDto CheckbalanceByDate(DateTime dateTime)
		{
			var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == dateTime.Year && pr.Timeout.Value.Month == dateTime.Month && pr.Timeout.Value.Day == dateTime.Day)
					.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
					{
						CreatedBy = p.CreatedBy.Id,
						LicensePlate = p.LicensePlate,
						ProvinceCode = p.ProvinceCode,
						ProvinceName = r.ProvinceName,
						UpdateBy = p.UpdatedBy.Id,
						Timein = p.Timein,
						TimeOut = p.Timeout,
						TotalPrice = (double)p.TotalPrice
					}
				).OrderBy(p => p.ProvinceName).ToList();
			var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == dateTime.Year && pr.Timeout.Value.Month == dateTime.Month && pr.Timeout.Value.Day == dateTime.Day)
				.Sum(p => p.TotalPrice);
			ReportRecordParkingDto Data = new ReportRecordParkingDto()
			{
				ListParkingRecords = listParking,
				TotalPrice = (double)Sum
			};
			return Data;
		}

		public ReportRecordParkingDto CheckbalanceByMonth(int? year,int month)
		{
			if (year != null)
			{
				var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == year && pr.Timeout.Value.Month == month)
					.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
					{
						CreatedBy = p.CreatedBy.Id,
						LicensePlate = p.LicensePlate,
						ProvinceCode = p.ProvinceCode,
						ProvinceName = r.ProvinceName,
						UpdateBy = p.UpdatedBy.Id,
						Timein = p.Timein,
						TimeOut = p.Timeout,
						TotalPrice = (double)p.TotalPrice
					}
				).OrderBy(p => p.ProvinceName).ToList();
				var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == year && pr.Timeout.Value.Month == month)
					.Sum(p => p.TotalPrice);
				ReportRecordParkingDto Data = new ReportRecordParkingDto()
				{
					ListParkingRecords = listParking,
					TotalPrice = (double)Sum
				};
				return Data;

			}
			else
			{
				var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Month == month)
					.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
					{
						CreatedBy = p.CreatedBy.Id,
						LicensePlate = p.LicensePlate,
						ProvinceCode = p.ProvinceCode,
						ProvinceName = r.ProvinceName,
						UpdateBy = p.UpdatedBy.Id,
						Timein = p.Timein,
						TimeOut = p.Timeout,
						TotalPrice = (double)p.TotalPrice
					}
				).OrderBy(p => p.ProvinceName).ToList();
				var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Month == month)
					.Sum(p => p.TotalPrice);
				ReportRecordParkingDto Data = new ReportRecordParkingDto()
				{
					ListParkingRecords = listParking,
					TotalPrice = (double)Sum
				};
				return Data;
			}
			
		}

		public ReportRecordParkingDto CheckbalanceByTime(DateTime timeIn, DateTime timeOut)
		{
			var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout >= timeIn && pr.Timeout <= timeOut)
				.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
				{
					CreatedBy = p.CreatedBy.Id,
					LicensePlate = p.LicensePlate,
					ProvinceCode = p.ProvinceCode,
					ProvinceName = r.ProvinceName,
					UpdateBy = p.UpdatedBy.Id,
					Timein = p.Timein,
					TimeOut = p.Timeout,
					TotalPrice = (double)p.TotalPrice
				}
			).OrderBy(p => p.ProvinceName).ToList();
			var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout >= timeIn && pr.Timeout <= timeOut)
				.Sum(p => p.TotalPrice);
			ReportRecordParkingDto Data = new ReportRecordParkingDto()
			{
				ListParkingRecords = listParking,
				TotalPrice = (double)Sum
			};
			return Data;
		}

		public ReportRecordParkingDto CheckbalanceByWeek(int week)
		{
			//var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value. >= timeIn && pr.Timeout <= timeOut)
			//	.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
			//	{
			//		CreatedBy = p.CreatedBy.Id,
			//		LicensePlate = p.LicensePlate,
			//		ProvinceCode = p.ProvinceCode,
			//		ProvinceName = r.ProvinceName,
			//		UpdateBy = p.UpdatedBy.Id,
			//		Timein = p.Timein,
			//		TimeOut = p.Timeout,
			//		TotalPrice = (double)p.TotalPrice
			//	}
			//).OrderBy(p => p.ProvinceName).ToList();
			//var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout >= timeIn && pr.Timeout <= timeOut)
			//	.Sum(p => p.TotalPrice);
			//ReportRecordParkingDto Data = new ReportRecordParkingDto()
			//{
			//	ListParkingRecords = listParking,
			//	TotalPrice = (double)Sum
			//};
			//return Data;
			var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == week)
				.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
				{
					CreatedBy = p.CreatedBy.Id,
					LicensePlate = p.LicensePlate,
					ProvinceCode = p.ProvinceCode,
					ProvinceName = r.ProvinceName,
					UpdateBy = p.UpdatedBy.Id,
					Timein = p.Timein,
					TimeOut = p.Timeout,
					TotalPrice = (double)p.TotalPrice
				}
			).OrderBy(p => p.ProvinceName).ToList();
			var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == week)
				.Sum(p => p.TotalPrice);
			ReportRecordParkingDto Data = new ReportRecordParkingDto()
			{
				ListParkingRecords = listParking,
				TotalPrice = (double)Sum
			};
			return Data;
		}

		public ReportRecordParkingDto CheckbalanceByYear(int year)
		{
			var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == year)
				.Join(_context.Provinces, p => p.ProvinceCode, r => r.ProvinceCode, (p, r) => new ParkingRecordDto()
				{
					CreatedBy = p.CreatedBy.Id,
					LicensePlate = p.LicensePlate,
					ProvinceCode = p.ProvinceCode,
					ProvinceName = r.ProvinceName,
					UpdateBy = p.UpdatedBy.Id,
					Timein = p.Timein,
					TimeOut = p.Timeout,
					TotalPrice = (double)p.TotalPrice
				}
			).OrderBy(p => p.ProvinceName).ToList();
			var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout.Value.Year == year)
				.Sum(p => p.TotalPrice);
			ReportRecordParkingDto Data = new ReportRecordParkingDto()
			{
				ListParkingRecords = listParking,
				TotalPrice = (double)Sum
			};
			return Data;
		}

		public void CheckIn(ParkingCheckInDto parkingCheckIn)
		{
			//throw new NotImplementedException();
			ParkingRecord parkingRecord = new ParkingRecord()
			{
				LicensePlate= parkingCheckIn.LicensePlate,
				ProvinceCode=parkingCheckIn.ProvinceCode,
				Timein=parkingCheckIn.Timein,
				CreatedBy= new User() { 
	                  Id=parkingCheckIn.CreatedBy } 
			};
			_context.ParkingRecords.Add(parkingRecord);
			_context.SaveChanges();
		}

		public void CheckOut(ParkingCheckOutDto parkingCheckOut)
		{
			//throw new NotImplementedException();
			var DettilUsed = _context.ParkingRecords.Where(pr => pr.Id == parkingCheckOut.Id).FirstOrDefault();
			DettilUsed.Timeout = parkingCheckOut.TimeOut;
			DettilUsed.UpdatedBy= new User()
			{
				Id = parkingCheckOut.UpdateBy			
			};
			DettilUsed.TotalPrice = parkingCheckOut.TotalPrice;
			_context.SaveChanges();
	}

		public int GetCarParking()
		{
			int totalcar = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout == null).Count();
			return totalcar;
		}

		public ReportRecordParkingDto GetDataOrderByProvince()
		{
			var listParking = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout != null)
				.Join(_context.Provinces,p=>p.ProvinceCode,r=>r.ProvinceCode,(p,r) => new ParkingRecordDto()
			    {
				CreatedBy = p.CreatedBy.Id,
				LicensePlate = p.LicensePlate,
				ProvinceCode = p.ProvinceCode,
				ProvinceName=r.ProvinceName,
				UpdateBy = p.UpdatedBy.Id,
				Timein = p.Timein,
				TimeOut = p.Timeout,
				TotalPrice = (double)p.TotalPrice
			}
			).OrderBy(p=>p.ProvinceName).ToList();
			var Sum = _context.ParkingRecords.Where(pr => pr.Timein != null && pr.Timeout != null)
				.Sum(p=>p.TotalPrice);
			ReportRecordParkingDto Data = new ReportRecordParkingDto()
			{
				ListParkingRecords = listParking,
				TotalPrice= (double)Sum
			};
			return Data;
		}

		public ParkingRecordDto GetDataParkingRecordById(int Id)
		{
			var DettilUsed = _context.ParkingRecords.Where(pr => pr.Id == Id).Select(p => new ParkingRecordDto()
			{
				CreatedBy=p.CreatedBy.Id,
				LicensePlate=p.LicensePlate,
				ProvinceCode=p.ProvinceCode,
				UpdateBy=p.UpdatedBy.Id,
				Timein=p.Timein,
				TimeOut=p.Timeout,
				TotalPrice=(double)p.TotalPrice
			}
			).FirstOrDefault();
			return DettilUsed;
		}

		public List<ParkingRecordDto> GetDataParkingRecordByLicense(string license)
		{
			var DettilUsed = _context.ParkingRecords.Where(pr => pr.LicensePlate == license).Select(p => new ParkingRecordDto()
			{
				CreatedBy = p.CreatedBy.Id,
				LicensePlate = p.LicensePlate,
				ProvinceCode = p.ProvinceCode,
				UpdateBy = p.UpdatedBy.Id,
				Timein = p.Timein,
				TimeOut = p.Timeout,
				TotalPrice = (double)p.TotalPrice
			}
			).ToList();
			return DettilUsed;
		}

		public List<CarProvinceMaxDto> GetTopProvinceUse()
		{

			var grouped = from b in _context.ParkingRecords
						  group b.Id by b.Province.ProvinceName into g
						  select new
						  {
							  Key = g.Key,
							  Unit = g.Count()
						  };
			var result = grouped.OrderByDescending(x => x.Unit).Select(x=> new CarProvinceMaxDto()
			{ 
				ProvinceName = x.Key,
				Total=x.Unit
			}).ToList();
			if (result.Count < 3)
			{
				return result;
			}
			else
			{
				List<CarProvinceMaxDto> list = new List<CarProvinceMaxDto>();
				for (int i = 0; i < 3; i++)
				{
					list.Add(result[i]);
				}

				return list;
			}
			
		}
	}
}
