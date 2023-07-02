using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class CityRoutePassengerMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Location_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_Location_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Istanbul" },
                    { 2, "Ankara" },
                    { 3, "Erzincan" },
                    { 4, "Antalya" },
                    { 5, "Rize" },
                    { 6, "Samsun" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 3, 2 },
                    { 3, 4, 5 },
                    { 4, 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_ArrivalCityId",
                table: "Route",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DepartureCityId",
                table: "Route",
                column: "DepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
