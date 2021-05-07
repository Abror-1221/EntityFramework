using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education");

            migrationBuilder.AlterColumn<int>(
                name: "University_Id",
                table: "tb_m_education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education",
                column: "University_Id",
                principalTable: "tb_m_university",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education");

            migrationBuilder.AlterColumn<int>(
                name: "University_Id",
                table: "tb_m_education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_education_tb_m_university_University_Id",
                table: "tb_m_education",
                column: "University_Id",
                principalTable: "tb_m_university",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
