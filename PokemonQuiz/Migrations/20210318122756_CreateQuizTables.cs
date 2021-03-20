using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonQuiz.Migrations
{
    public partial class CreateQuizTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswers",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExpectedAnswer",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncorrectAnswers",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    EvolutionName = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    EvolutionLevel = table.Column<int>(type: "int", nullable: false),
                    Type1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.PokemonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropColumn(
                name: "CorrectAnswers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpectedAnswer",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IncorrectAnswers",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
