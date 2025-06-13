using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagementBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "ServerId", "City", "IsOnline", "Name" },
                values: new object[,]
                {
                    { 1, "Chennai", false, "Server1" },
                    { 2, "Chennai", true, "Server2" },
                    { 3, "Chennai", true, "Server3" },
                    { 4, "Thanjavur", true, "Server4" },
                    { 5, "Thanjavur", false, "Server5" },
                    { 6, "Erode", false, "Server6" },
                    { 7, "Erode", false, "Server7" },
                    { 8, "Erode", false, "Server8" },
                    { 9, "Coimbatore", true, "Server9" },
                    { 10, "Coimbatore", true, "Server10" },
                    { 11, "Coimbatore", false, "Server11" },
                    { 12, "Thiruchy", false, "Server12" },
                    { 13, "Thiruchy", true, "Server13" },
                    { 14, "Thiruchy", false, "Server13" },
                    { 15, "Madurai", false, "Server13" },
                    { 16, "Madurai", false, "Server13" },
                    { 17, "Theni", false, "Server13" },
                    { 18, "Madurai", true, "Server13" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
