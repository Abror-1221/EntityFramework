using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_account_tb_m_profiling_NIK",
                table: "tb_m_account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_person_tb_m_account_NIK",
                table: "tb_m_person");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_account_tb_m_person_NIK",
                table: "tb_m_account",
                column: "NIK",
                principalTable: "tb_m_person",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_profiling_tb_m_account_NIK",
                table: "tb_m_profiling",
                column: "NIK",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_account_tb_m_person_NIK",
                table: "tb_m_account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_profiling_tb_m_account_NIK",
                table: "tb_m_profiling");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_account_tb_m_profiling_NIK",
                table: "tb_m_account",
                column: "NIK",
                principalTable: "tb_m_profiling",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_person_tb_m_account_NIK",
                table: "tb_m_person",
                column: "NIK",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
