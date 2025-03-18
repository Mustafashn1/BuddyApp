using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuddyApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GorevAdi = table.Column<string>(type: "text", nullable: false),
                    GorevAciklama = table.Column<string>(type: "text", nullable: false),
                    Oncelik = table.Column<int>(type: "integer", nullable: false),
                    SonTarih = table.Column<DateOnly>(type: "date", nullable: false),
                    Durum = table.Column<long>(type: "bigint", nullable: false),
                    Notlar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanAdi = table.Column<string>(type: "text", nullable: false),
                    PlanAciklama = table.Column<string>(type: "text", nullable: false),
                    Oncelik = table.Column<int>(type: "integer", nullable: false),
                    TarihAraligi = table.Column<DateOnly>(type: "date", nullable: false),
                    Durum = table.Column<long>(type: "bigint", nullable: false),
                    Notlar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planlar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Planlar");
        }
    }
}
