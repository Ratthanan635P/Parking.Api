using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Interfaces.Repositories
{
	public interface IParkingRecordRepository
	{
		// add 
		void CheckIn(ParkingCheckInDto parkingCheckIn);
		// get data by Id
		ParkingRecordDto GetDataParkingRecordById(int Id);
		// get data by ทะเบียนรถ
		List<ParkingRecordDto> GetDataParkingRecordByLicense(string license);
		// update date data by ทะเบียนรถ
		void CheckOut(ParkingCheckOutDto parkingCheckOut);
		//ออกรายงาน ยอด ประวัน วัน*เช็คที่วันเวลาออก
		ReportRecordParkingDto CheckbalanceByDate(DateTime dateTime);
		////ออกรายงาน ยอด สัปดาห์, *เช็คที่วันเวลาออก
		//ReportRecordParkingDto CheckbalanceByWeek(int week);
		//ออกรายงาน ยอด เดือน,*เช็คที่วันเวลาออก
		ReportRecordParkingDto CheckbalanceByMonth(int? year,int month);
		//ออกรายงาน ยอด ปี, *เช็คที่วันเวลาออก
		ReportRecordParkingDto CheckbalanceByYear(int year);
		//ออกรายงาน ยอด ช่วงเวลา *เช็คที่วันเวลาออก
		ReportRecordParkingDto CheckbalanceByTime(DateTime timeIn,DateTime timeOut);
		// check จำนวนรถ ที่เข้า จอด จาก TimeIn and TimeOut==null
		int GetCarParking();
		// ออกรายงาน ตามจังหวัด,
		ReportRecordParkingDto GetDataOrderByProvince();
		// topจังหวัด เช็คทะเบียนซ้ำออก
		List<CarProvinceMaxDto> GetTopProvinceUse();

		double CalculatePirceParking(int hour);
	}
}
