using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2.Migrations
{
    public partial class EmpMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpTbl",
                columns: table => new
                {
                    EmpID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeptDID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTbl", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_EmpTbl_DeptTbl_DeptDID",
                        column: x => x.DeptDID,
                        principalTable: "DeptTbl",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpTbl_DeptDID",
                table: "EmpTbl",
                column: "DeptDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTbl");
        }
    }
}
