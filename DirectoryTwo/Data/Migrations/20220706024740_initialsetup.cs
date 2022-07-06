using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectoryTwo.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectoryEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prot = table.Column<string>(nullable: true),
                    SubDom = table.Column<string>(nullable: true),
                    Dom = table.Column<string>(nullable: true),
                    TopDom = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: true),
                    SiteType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryEntry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectoryEntry");
        }
    }
}
