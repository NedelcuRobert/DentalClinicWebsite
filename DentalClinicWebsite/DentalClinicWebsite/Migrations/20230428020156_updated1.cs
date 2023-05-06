using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicWebsite.Migrations
{
    /// <inheritdoc />
    public partial class updated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
