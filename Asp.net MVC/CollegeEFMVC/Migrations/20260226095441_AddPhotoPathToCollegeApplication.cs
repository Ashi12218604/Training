using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeEFMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoPathToCollegeApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "CollegeApplications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CollegeApplications",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AadhaarNumber",
                table: "CollegeApplications",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "CollegeApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollegeApplications_Email",
                table: "CollegeApplications",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollegeApplications_Phone",
                table: "CollegeApplications",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CollegeApplications_Email",
                table: "CollegeApplications");

            migrationBuilder.DropIndex(
                name: "IX_CollegeApplications_Phone",
                table: "CollegeApplications");

            migrationBuilder.DropColumn(
                name: "AadhaarNumber",
                table: "CollegeApplications");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "CollegeApplications");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "CollegeApplications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CollegeApplications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
