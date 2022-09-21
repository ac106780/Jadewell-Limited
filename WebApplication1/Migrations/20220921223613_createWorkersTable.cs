using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class createWorkersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBought = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSold = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkersID);
                    table.ForeignKey(
                        name: "FK_Workers_House_HouseID",
                        column: x => x.HouseID,
                        principalTable: "House",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_HouseID",
                table: "Workers",
                column: "HouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
