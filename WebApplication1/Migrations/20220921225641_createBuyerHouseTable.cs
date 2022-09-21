using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class createBuyerHouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerHouse",
                columns: table => new
                {
                    BuyerHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    BuyerID = table.Column<int>(type: "int", nullable: false),
                    BuyersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerHouse", x => x.BuyerHouseID);
                    table.ForeignKey(
                        name: "FK_BuyerHouse_Buyers_BuyersID",
                        column: x => x.BuyersID,
                        principalTable: "Buyers",
                        principalColumn: "BuyersID");
                    table.ForeignKey(
                        name: "FK_BuyerHouse_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerHouse_BuyersID",
                table: "BuyerHouse",
                column: "BuyersID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerHouse_HouseID",
                table: "BuyerHouse",
                column: "HouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerHouse");
        }
    }
}
