using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_UniversityId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_EducationId",
                table: "Profilings");

            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "Profilings",
                newName: "Education_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Profilings_EducationId",
                table: "Profilings",
                newName: "IX_Profilings_Education_Id");

            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Educations",
                newName: "University_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_UniversityId",
                table: "Educations",
                newName: "IX_Educations_University_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations",
                column: "University_Id",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings",
                column: "Education_Id",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings");

            migrationBuilder.RenameColumn(
                name: "Education_Id",
                table: "Profilings",
                newName: "EducationId");

            migrationBuilder.RenameIndex(
                name: "IX_Profilings_Education_Id",
                table: "Profilings",
                newName: "IX_Profilings_EducationId");

            migrationBuilder.RenameColumn(
                name: "University_Id",
                table: "Educations",
                newName: "UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_University_Id",
                table: "Educations",
                newName: "IX_Educations_UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_UniversityId",
                table: "Educations",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_EducationId",
                table: "Profilings",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
