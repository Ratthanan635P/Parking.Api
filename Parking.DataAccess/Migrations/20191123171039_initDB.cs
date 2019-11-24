using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.DataAccess.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    IsUsed = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceCode = table.Column<int>(nullable: false),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 150, nullable: true),
                    Salt = table.Column<string>(maxLength: 20, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ActiveStatus = table.Column<int>(nullable: false),
                    IsAdministrator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timein = table.Column<DateTime>(nullable: false),
                    Timeout = table.Column<DateTime>(nullable: true),
                    LicensePlate = table.Column<string>(maxLength: 10, nullable: true),
                    ProvinceCode = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_Provinces_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceCode", "ProvinceName" },
                values: new object[,]
                {
                    { 10, "กรุงเทพมหานคร" },
                    { 70, "ราชบุรี" },
                    { 67, "เพชรบูรณ์" },
                    { 66, "พิจิตร" },
                    { 65, "พิษณุโลก" },
                    { 64, "สุโขทัย" },
                    { 63, "ตาก" },
                    { 62, "กำแพงเพชร" },
                    { 61, "อุทัยธานี" },
                    { 60, "นครสวรรค์" },
                    { 58, "แม่ฮ่องสอน" },
                    { 57, "เชียงราย" },
                    { 56, "พะเยา" },
                    { 55, "น่าน" },
                    { 54, "แพร่" },
                    { 53, "อุตรดิตถ์" },
                    { 71, "กาญจนบุรี" },
                    { 72, "สุพรรณบุรี" },
                    { 73, "นครปฐม" },
                    { 74, "สมุทรสาคร" },
                    { 95, "ยะลา" },
                    { 94, "ปัตตานี" },
                    { 93, "พัทลุง" },
                    { 92, "ตรัง" },
                    { 91, "สตูล" },
                    { 90, "สงขลา" },
                    { 86, "ชุมพร" },
                    { 52, "ลำปาง" },
                    { 85, "ระนอง" },
                    { 83, "ภูเก็ต" },
                    { 82, "พังงา" },
                    { 81, "กระบี่" },
                    { 80, "นครศรีธรรมราช" },
                    { 77, "ประจวบคีรีขันธ์" },
                    { 76, "เพชรบุรี" },
                    { 75, "สมุทรสงคราม" },
                    { 84, "สุราษฎร์ธานี" },
                    { 96, "นราธิวาส" },
                    { 51, "ลำพูน" },
                    { 49, "มุกดาหาร" },
                    { 25, "ปราจีนบุรี" },
                    { 24, "ฉะเชิงเทรา" },
                    { 23, "ตราด" },
                    { 22, "จันทบุรี" },
                    { 21, "ระยอง" },
                    { 20, "ชลบุรี" },
                    { 19, "สระบุรี" },
                    { 18, "ชัยนาท" },
                    { 17, "สิงห์บุรี" },
                    { 16, "ลพบุรี" },
                    { 15, "อ่างทอง" },
                    { 14, "พระนครศรีอยุธยา" },
                    { 13, "ปทุมธานี" },
                    { 12, "นนทบุรี" },
                    { 11, "สมุทรปราการ" },
                    { 26, "นครนายก" },
                    { 27, "สระแก้ว" },
                    { 30, "นครราชสีมา" },
                    { 31, "บุรีรัมย์" },
                    { 48, "นครพนม" },
                    { 47, "สกลนคร" },
                    { 46, "กาฬสินธุ์" },
                    { 45, "ร้อยเอ็ด" },
                    { 44, "มหาสารคาม" },
                    { 43, "หนองคาย" },
                    { 42, "เลย" },
                    { 50, "เชียงใหม่" },
                    { 41, "อุดรธานี" },
                    { 39, "หนองบัวลำภู" },
                    { 37, "อำนาจเจริญ" },
                    { 36, "ชัยภูมิ" },
                    { 35, "ยโสธร" },
                    { 34, "อุบลราชธานี" },
                    { 33, "ศรีสะเกษ" },
                    { 32, "สุรินทร์" },
                    { 40, "ขอนแก่น" },
                    { 97, "บึงกาฬ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_CreatedById",
                table: "ParkingRecords",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_ProvinceCode",
                table: "ParkingRecords",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_UpdatedById",
                table: "ParkingRecords",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRates");

            migrationBuilder.DropTable(
                name: "ParkingRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
