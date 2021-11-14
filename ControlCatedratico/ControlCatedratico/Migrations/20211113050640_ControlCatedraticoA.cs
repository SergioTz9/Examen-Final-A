using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCatedratico.Migrations
{
    public partial class ControlCatedraticoA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_RegistroCatedratico",
                columns: table => new
                {
                    CodigoCatedratico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCatedratico = table.Column<string>(type: "varchar(35)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(35)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(35)", nullable: false),
                    TelCatedratico = table.Column<string>(type: "varchar(35)", nullable: false),
                    CorreoCatedratico = table.Column<string>(type: "varchar(35)", nullable: false),
                    NoDpi = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EstadoCatedratico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RegistroCatedratico", x => x.CodigoCatedratico);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RegistroCursos",
                columns: table => new
                {
                    CodigoCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(type: "varchar(35)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaFinaliza = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EstadoCurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCatedratico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RegistroCursos", x => x.CodigoCurso);
                });

            migrationBuilder.CreateTable(
                name: "CatedraticoModelCursosModel",
                columns: table => new
                {
                    CatedraticoModelsCodigoCatedratico = table.Column<int>(type: "int", nullable: false),
                    CursosModelsCodigoCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatedraticoModelCursosModel", x => new { x.CatedraticoModelsCodigoCatedratico, x.CursosModelsCodigoCurso });
                    table.ForeignKey(
                        name: "FK_CatedraticoModelCursosModel_tbl_RegistroCatedratico_CatedraticoModelsCodigoCatedratico",
                        column: x => x.CatedraticoModelsCodigoCatedratico,
                        principalTable: "tbl_RegistroCatedratico",
                        principalColumn: "CodigoCatedratico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatedraticoModelCursosModel_tbl_RegistroCursos_CursosModelsCodigoCurso",
                        column: x => x.CursosModelsCodigoCurso,
                        principalTable: "tbl_RegistroCursos",
                        principalColumn: "CodigoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatedraticoModelCursosModel_CursosModelsCodigoCurso",
                table: "CatedraticoModelCursosModel",
                column: "CursosModelsCodigoCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatedraticoModelCursosModel");

            migrationBuilder.DropTable(
                name: "tbl_RegistroCatedratico");

            migrationBuilder.DropTable(
                name: "tbl_RegistroCursos");
        }
    }
}
