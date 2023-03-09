using Microsoft.EntityFrameworkCore.Migrations;

namespace emlak.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmlak",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaSayisi = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Metrekare = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Fiyat = table.Column<double>(type: "float", maxLength: 30, nullable: false),
                    Sehir = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmlak", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmlak");
        }
    }
}
