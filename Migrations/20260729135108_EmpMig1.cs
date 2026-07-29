using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2.Migrations
{
    public partial class EmpMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpTbl_DeptTbl_DeptDID",
                table: "EmpTbl");

            migrationBuilder.DropIndex(
                name: "IX_EmpTbl_DeptDID",
                table: "EmpTbl");

            migrationBuilder.DropColumn(
                name: "DeptDID",
                table: "EmpTbl");

            migrationBuilder.AddColumn<long>(
                name: "DeptID",
                table: "EmpTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EmpTbl_DeptID",
                table: "EmpTbl",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTbl_DeptTbl_DeptID",
                table: "EmpTbl",
                column: "DeptID",
                principalTable: "DeptTbl",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpTbl_DeptTbl_DeptID",
                table: "EmpTbl");

            migrationBuilder.DropIndex(
                name: "IX_EmpTbl_DeptID",
                table: "EmpTbl");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "EmpTbl");

            migrationBuilder.AddColumn<long>(
                name: "DeptDID",
                table: "EmpTbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpTbl_DeptDID",
                table: "EmpTbl",
                column: "DeptDID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTbl_DeptTbl_DeptDID",
                table: "EmpTbl",
                column: "DeptDID",
                principalTable: "DeptTbl",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
