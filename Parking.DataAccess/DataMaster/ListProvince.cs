using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DataAccess.DataMaster
{
	public class ListProvince
	{
		public List<Province> Provinces { get; set; }
		public ListProvince()
		{
			Provinces = new List<Province>()
			{
				new Province(){ ProvinceName = "กรุงเทพมหานคร", ProvinceCode = 10 },
				new Province(){ ProvinceName = "สมุทรปราการ", ProvinceCode = 11 },
				new Province(){ ProvinceName = "นนทบุรี", ProvinceCode = 12 },
				new Province(){ ProvinceName = "ปทุมธานี", ProvinceCode = 13 },
				new Province(){ ProvinceName = "พระนครศรีอยุธยา", ProvinceCode = 14 },
				new Province(){ ProvinceName = "อ่างทอง", ProvinceCode = 15 },
				new Province(){ ProvinceName = "ลพบุรี", ProvinceCode = 16 },
				new Province(){ ProvinceName = "สิงห์บุรี", ProvinceCode = 17 },
				new Province(){ ProvinceName = "ชัยนาท", ProvinceCode = 18 },
				new Province(){ ProvinceName = "สระบุรี", ProvinceCode = 19 },
				new Province(){ ProvinceName = "ชลบุรี", ProvinceCode = 20 },
				new Province(){ ProvinceName = "ระยอง", ProvinceCode = 21 },
				new Province(){ ProvinceName = "จันทบุรี", ProvinceCode = 22 },
				new Province(){ ProvinceName = "ตราด", ProvinceCode = 23 },
				new Province(){ ProvinceName = "ฉะเชิงเทรา", ProvinceCode = 24 },
				new Province(){ ProvinceName = "ปราจีนบุรี", ProvinceCode = 25 },
				new Province(){ ProvinceName = "นครนายก", ProvinceCode = 26 },
				new Province(){ ProvinceName = "สระแก้ว", ProvinceCode = 27 },
				new Province(){ ProvinceName = "นครราชสีมา", ProvinceCode = 30 },
				new Province(){ ProvinceName = "บุรีรัมย์", ProvinceCode = 31 },
				new Province(){ ProvinceName = "สุรินทร์", ProvinceCode = 32 },
				new Province(){ ProvinceName = "ศรีสะเกษ", ProvinceCode = 33 },
				new Province(){ ProvinceName = "อุบลราชธานี", ProvinceCode = 34 },
				new Province(){ ProvinceName = "ยโสธร", ProvinceCode = 35 },
				new Province(){ ProvinceName = "ชัยภูมิ", ProvinceCode = 36 },
				new Province(){ ProvinceName = "อำนาจเจริญ", ProvinceCode = 37 },
				new Province(){ ProvinceName = "หนองบัวลำภู", ProvinceCode = 39 },
				new Province(){ ProvinceName = "ขอนแก่น", ProvinceCode = 40 },
				new Province(){ ProvinceName = "อุดรธานี", ProvinceCode = 41 },
				new Province(){ ProvinceName = "เลย", ProvinceCode = 42 },
				new Province(){ ProvinceName = "หนองคาย", ProvinceCode = 43 },
				new Province(){ ProvinceName = "มหาสารคาม", ProvinceCode = 44 },
				new Province(){ ProvinceName = "ร้อยเอ็ด", ProvinceCode = 45 },
				new Province(){ ProvinceName = "กาฬสินธุ์", ProvinceCode = 46 },
				new Province(){ ProvinceName = "สกลนคร", ProvinceCode = 47 },
				new Province(){ ProvinceName = "นครพนม", ProvinceCode = 48 },
				new Province(){ ProvinceName = "มุกดาหาร", ProvinceCode = 49 },
				new Province(){ ProvinceName = "เชียงใหม่", ProvinceCode = 50 },
				new Province(){ ProvinceName = "ลำพูน", ProvinceCode = 51 },
				new Province(){ ProvinceName = "ลำปาง", ProvinceCode = 52 },
				new Province(){ ProvinceName = "อุตรดิตถ์", ProvinceCode = 53 },
				new Province(){ ProvinceName = "แพร่", ProvinceCode = 54 },
				new Province(){ ProvinceName = "น่าน", ProvinceCode = 55 },
				new Province(){ ProvinceName = "พะเยา", ProvinceCode = 56 },
				new Province(){ ProvinceName = "เชียงราย", ProvinceCode = 57 },
				new Province(){ ProvinceName = "แม่ฮ่องสอน", ProvinceCode = 58 },
				new Province(){ ProvinceName = "นครสวรรค์", ProvinceCode = 60 },
				new Province(){ ProvinceName = "อุทัยธานี", ProvinceCode = 61 },
				new Province(){ ProvinceName = "กำแพงเพชร", ProvinceCode = 62 },
				new Province(){ ProvinceName = "ตาก", ProvinceCode = 63 },
				new Province(){ ProvinceName = "สุโขทัย", ProvinceCode = 64 },
				new Province(){ ProvinceName = "พิษณุโลก", ProvinceCode = 65 },
				new Province(){ ProvinceName = "พิจิตร", ProvinceCode = 66 },
				new Province(){ ProvinceName = "เพชรบูรณ์", ProvinceCode = 67 },
				new Province(){ ProvinceName = "ราชบุรี", ProvinceCode = 70 },
				new Province(){ ProvinceName = "กาญจนบุรี", ProvinceCode = 71 },
				new Province(){ ProvinceName = "สุพรรณบุรี", ProvinceCode = 72 },
				new Province(){ ProvinceName = "นครปฐม", ProvinceCode = 73 },
				new Province(){ ProvinceName = "สมุทรสาคร", ProvinceCode = 74 },
				new Province(){ ProvinceName = "สมุทรสงคราม", ProvinceCode = 75 },
				new Province(){ ProvinceName = "เพชรบุรี", ProvinceCode = 76 },
				new Province(){ ProvinceName = "ประจวบคีรีขันธ์", ProvinceCode = 77 },
				new Province(){ ProvinceName = "นครศรีธรรมราช", ProvinceCode = 80 },
				new Province(){ ProvinceName = "กระบี่", ProvinceCode = 81 },
				new Province(){ ProvinceName = "พังงา", ProvinceCode = 82 },
				new Province(){ ProvinceName = "ภูเก็ต", ProvinceCode = 83 },
				new Province(){ ProvinceName = "สุราษฎร์ธานี", ProvinceCode = 84 },
				new Province(){ ProvinceName = "ระนอง", ProvinceCode = 85 },
				new Province(){ ProvinceName = "ชุมพร", ProvinceCode = 86 },
				new Province(){ ProvinceName = "สงขลา", ProvinceCode = 90 },
				new Province(){ ProvinceName = "สตูล", ProvinceCode = 91 },
				new Province(){ ProvinceName = "ตรัง", ProvinceCode = 92 },
				new Province(){ ProvinceName = "พัทลุง", ProvinceCode = 93 },
				new Province(){ ProvinceName = "ปัตตานี", ProvinceCode = 94 },
				new Province(){ ProvinceName = "ยะลา", ProvinceCode = 95 },
				new Province(){ ProvinceName = "นราธิวาส", ProvinceCode = 96 },
				new Province(){ ProvinceName = "บึงกาฬ", ProvinceCode = 97 }
			};
		}
	}
}
