using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyMoshNet8.Migrations
{
    /// <inheritdoc />
    public partial class AddDateSubscribed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubscribed",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSubscribed",
                table: "Customers");
        }
    }
}
