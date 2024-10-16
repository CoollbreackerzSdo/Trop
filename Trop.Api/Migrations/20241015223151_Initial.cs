using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trop.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    key = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_rol = table.Column<string>(type: "text", nullable: false),
                    register_date_utc = table.Column<DateOnly>(type: "date", nullable: false),
                    register_time_utc = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    detail = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_name",
                table: "Users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
