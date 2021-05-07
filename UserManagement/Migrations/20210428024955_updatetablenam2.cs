using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatetablenam2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_tb_m_person_NIK",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "tb_m_university");

            migrationBuilder.RenameTable(
                name: "Profilings",
                newName: "tb_m_profiling");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "tb_m_education");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "tb_m_account");

            migrationBuilder.RenameIndex(
                name: "IX_Profilings_Education_Id",
                table: "tb_m_profiling",
                newName: "IX_tb_m_profiling_Education_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_University_Id",
                table: "tb_m_education",
                newName: "IX_tb_m_education_University_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_university",
                table: "tb_m_university",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_profiling",
                table: "tb_m_profiling",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_education",
                table: "tb_m_education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_account",
                table: "tb_m_account",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_account_tb_m_person_NIK",
                table: "tb_m_account",
                column: "NIK",
                principalTable: "tb_m_person",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education",
                column: "University_Id",
                principalTable: "tb_m_university",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profiling_tb_m_account_NIK",
                table: "tb_m_profiling",
                column: "NIK",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_Education_Id",
                table: "tb_m_profiling",
                column: "Education_Id",
                principalTable: "tb_m_education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_account_tb_m_person_NIK",
                table: "tb_m_account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_profiling_tb_m_account_NIK",
                table: "tb_m_profiling");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_profiling_tb_m_education_Education_Id",
                table: "tb_m_profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_university",
                table: "tb_m_university");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_profiling",
                table: "tb_m_profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_education",
                table: "tb_m_education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_account",
                table: "tb_m_account");

            migrationBuilder.RenameTable(
                name: "tb_m_university",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "tb_m_profiling",
                newName: "Profilings");

            migrationBuilder.RenameTable(
                name: "tb_m_education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_profiling_Education_Id",
                table: "Profilings",
                newName: "IX_Profilings_Education_Id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_education_University_Id",
                table: "Educations",
                newName: "IX_Educations_University_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_tb_m_person_NIK",
                table: "Accounts",
                column: "NIK",
                principalTable: "tb_m_person",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_University_Id",
                table: "Educations",
                column: "University_Id",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_Education_Id",
                table: "Profilings",
                column: "Education_Id",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
