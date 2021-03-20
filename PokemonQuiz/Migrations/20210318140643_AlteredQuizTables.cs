using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonQuiz.Migrations
{
    public partial class AlteredQuizTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolutionLevel",
                table: "Pokemon");

            migrationBuilder.AddColumn<string>(
                name: "EvolutionMethod",
                table: "Pokemon",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolutionMethod",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "EvolutionLevel",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
