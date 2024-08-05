using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyMoshNet8.Migrations
{
    /// <inheritdoc />
    public partial class SetNameToMemeberShipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Insertar Name en MembershipType
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Pay as You Go' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Annual' WHERE Id = 4");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
