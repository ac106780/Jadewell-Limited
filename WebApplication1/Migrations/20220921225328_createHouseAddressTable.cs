using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class createHouseAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "houseAddress",
                columns: table => new
                {
                    houseAddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houseAddress", x => x.houseAddressID);
                    table.ForeignKey(
                        name: "FK_houseAddress_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_houseAddress_HouseID",
                table: "houseAddress",
                column: "HouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "houseAddress");
        }
    }
}
