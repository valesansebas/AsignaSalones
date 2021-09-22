using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignaSalones.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SedesUniversidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroSalonesDisp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedesUniversidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aforo = table.Column<int>(type: "int", nullable: false),
                    SedeUniversidadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Salones_SedesUniversidad_SedeUniversidadid",
                        column: x => x.SedeUniversidadid,
                        principalTable: "SedesUniversidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    estadoCovid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salonid = table.Column<int>(type: "int", nullable: true),
                    dependencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semestre = table.Column<int>(type: "int", nullable: true),
                    turno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Salones_Salonid",
                        column: x => x.Salonid,
                        principalTable: "Salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contagiados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personaid = table.Column<int>(type: "int", nullable: true),
                    fechaContagio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    periodoAislamiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contagiados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contagiados_Personas_personaid",
                        column: x => x.personaid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contagiados_personaid",
                table: "Contagiados",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Salonid",
                table: "Personas",
                column: "Salonid");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_SedeUniversidadid",
                table: "Salones",
                column: "SedeUniversidadid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contagiados");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "SedesUniversidad");
        }
    }
}
