using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Users");

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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserDoctorMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDoctorMapping", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_UserDoctorMapping_UserDoctorMappingId",
                table: "Appointments",
                column: "UserDoctorMappingId",
                principalTable: "UserDoctorMapping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Users_UserId",
                table: "Records",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_UserDoctorMapping_UserDoctorMappingId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Users_UserId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "UserDoctorMapping");

            migrationBuilder.DropIndex(
                name: "IX_Records_UserId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "UserDoctorMappingId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserDoctorMappingId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecordId",
                table: "Users",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
