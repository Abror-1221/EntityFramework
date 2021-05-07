using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateNameTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_RolesId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_tb_m_account_AccountsNIK",
                table: "AccountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_role");

            migrationBuilder.RenameTable(
                name: "AccountRoles",
                newName: "tb_m_roleaccount");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRoles_RolesId",
                table: "tb_m_roleaccount",
                newName: "IX_tb_m_roleaccount_RolesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_role",
                table: "tb_m_role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roleaccount",
                table: "tb_m_roleaccount",
                columns: new[] { "AccountsNIK", "RolesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roleaccount_tb_m_account_AccountsNIK",
                table: "tb_m_roleaccount",
                column: "AccountsNIK",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_roleaccount_tb_m_role_RolesId",
                table: "tb_m_roleaccount",
                column: "RolesId",
                principalTable: "tb_m_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_roleaccount_tb_m_account_AccountsNIK",
                table: "tb_m_roleaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_roleaccount_tb_m_role_RolesId",
                table: "tb_m_roleaccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roleaccount",
                table: "tb_m_roleaccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_role",
                table: "tb_m_role");

            migrationBuilder.RenameTable(
                name: "tb_m_roleaccount",
                newName: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "tb_m_role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_roleaccount_RolesId",
                table: "AccountRoles",
                newName: "IX_AccountRoles_RolesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles",
                columns: new[] { "AccountsNIK", "RolesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_RolesId",
                table: "AccountRoles",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_tb_m_account_AccountsNIK",
                table: "AccountRoles",
                column: "AccountsNIK",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
