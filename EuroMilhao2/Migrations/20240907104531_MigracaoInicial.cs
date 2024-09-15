using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroMilhao2.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChavesGeradas2",
                columns: table => new
                {
                    KeysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyNumber1 = table.Column<int>(type: "int", nullable: true),
                    KeyNumber2 = table.Column<int>(type: "int", nullable: true),
                    KeyNumber3 = table.Column<int>(type: "int", nullable: true),
                    KeyNumber4 = table.Column<int>(type: "int", nullable: true),
                    KeyNumber5 = table.Column<int>(type: "int", nullable: true),
                    KeyStar1 = table.Column<int>(type: "int", nullable: true),
                    KeyStar2 = table.Column<int>(type: "int", nullable: true),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChavesGeradas2", x => x.KeysId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChavesGeradas2");
        }
    }
}
