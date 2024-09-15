using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroMilhao2.Migrations
{
    /// <inheritdoc />
    public partial class inserindoDadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ChavesGeradas2(KeyNumber1,KeyNumber2,KeyNumber3,KeyNumber4,KeyNumber5,KeyStar1,KeyStar2,DataSorteio) " +
                               "VALUES(30, 25, 8, 10, 15, 5, 7, '05/09/2024 15:55:00')");

            migrationBuilder.Sql("INSERT INTO ChavesGeradas2(KeyNumber1,KeyNumber2,KeyNumber3,KeyNumber4,KeyNumber5,KeyStar1,KeyStar2,DataSorteio) " +
                               "VALUES(40, 2, 8, 1, 12, 7, 6, '06/09/2024 16:00:00')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
