// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonQuiz.Data;

namespace PokemonQuiz.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210320143107_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("PokemonQuiz.Models.Pokemon", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EvolutionMethod")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<string>("EvolutionName")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4");

                    b.Property<string>("Type1")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4");

                    b.Property<string>("Type2")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4");

                    b.HasKey("PokemonId");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("PokemonQuiz.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<string>("ExpectedAnswer")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<int>("IncorrectAnswers")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
