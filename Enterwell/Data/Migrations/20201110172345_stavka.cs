using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell.Data.Migrations
{
    public partial class stavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FakturaStavka",
                columns: table => new
                {
                    FakturaStavkeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opisProdaneStavke = table.Column<string>(nullable: true),
                    kolicinaProdaneStavke = table.Column<int>(nullable: false),
                    jedinicnaCijenaStavkeBezPoreza = table.Column<float>(nullable: false),
                    ukupnaCijenaZaStavkuBezPoreza = table.Column<float>(nullable: false),
                    fakturaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakturaStavka", x => x.FakturaStavkeID);
                    table.ForeignKey(
                        name: "FK_FakturaStavka_Faktura_fakturaID",
                        column: x => x.fakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_fakturaID",
                table: "FakturaStavka",
                column: "fakturaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakturaStavka");
        }
    }
}
