using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell.Data.Migrations
{
    public partial class faktura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    FakturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojFakture = table.Column<int>(nullable: false),
                    datumStvaranjaFakture = table.Column<DateTime>(nullable: false),
                    datumDospijecaFakture = table.Column<DateTime>(nullable: false),
                    cijenaBezPoreza = table.Column<float>(nullable: false),
                    cijenaSaPorezom = table.Column<float>(nullable: false),
                    korisnikID = table.Column<string>(nullable: true),
                    primateljRacuna = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.FakturaID);
                    table.ForeignKey(
                        name: "FK_Faktura_AspNetUsers_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_korisnikID",
                table: "Faktura",
                column: "korisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faktura");
        }
    }
}
