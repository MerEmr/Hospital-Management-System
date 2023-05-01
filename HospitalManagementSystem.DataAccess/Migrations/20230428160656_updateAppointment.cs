using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_UserDoctorMapping_UserDoctorMappingId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "UserDoctorMapping");

            migrationBuilder.RenameColumn(
                name: "UserDoctorMappingId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserDoctorMappingId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "UserDoctorMappingId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserDoctorMappingId");

            migrationBuilder.CreateTable(
                name: "UserDoctorMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDoctorMapping", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_UserDoctorMapping_UserDoctorMappingId",
                table: "Appointments",
                column: "UserDoctorMappingId",
                principalTable: "UserDoctorMapping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
