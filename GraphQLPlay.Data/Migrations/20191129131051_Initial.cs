using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLPlay.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clones",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentImageId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clones_Images_ParentImageId",
                        column: x => x.ParentImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clones_ParentImageId",
                table: "Clones",
                column: "ParentImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clones");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
