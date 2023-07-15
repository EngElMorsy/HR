using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Infrustructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cloths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagSide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagSide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagSide_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagSideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depart_MagSide_MagSideId",
                        column: x => x.MagSideId,
                        principalTable: "MagSide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    DisName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DTDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DTBrith = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DTexp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Social = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepartId = table.Column<int>(type: "int", nullable: false),
                    DTCreation = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DTUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.UniqueConstraint("AK_Employees_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Employees_Depart_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPart_Depart_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Branch = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    MagSide = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Depart = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    JobPart = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    JobFinal = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    StarDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    DTCreation = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DTUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Employees_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "Employees",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualifiction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QfySide = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qfy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    spfy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QfyYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    DTCreation = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DTUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifiction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifiction_Employees_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "Employees",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Safty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sizes = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EmployeeCode = table.Column<int>(type: "int", nullable: false),
                    DTCreation = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DTUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Safty_Employees_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "Employees",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobFinal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobFinal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobFinal_JobPart_JobPartId",
                        column: x => x.JobPartId,
                        principalTable: "JobPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Depart_MagSideId",
                table: "Depart",
                column: "MagSideId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartId",
                table: "Employees",
                column: "DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeeCode",
                table: "Job",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobFinal_JobPartId",
                table: "jobFinal",
                column: "JobPartId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPart_DepartId",
                table: "JobPart",
                column: "DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_MagSide_BranchId",
                table: "MagSide",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifiction_EmployeeCode",
                table: "Qualifiction",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Safty_EmployeeCode",
                table: "Safty",
                column: "EmployeeCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cloths");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "jobFinal");

            migrationBuilder.DropTable(
                name: "Qualifiction");

            migrationBuilder.DropTable(
                name: "Safty");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "JobPart");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Depart");

            migrationBuilder.DropTable(
                name: "MagSide");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
