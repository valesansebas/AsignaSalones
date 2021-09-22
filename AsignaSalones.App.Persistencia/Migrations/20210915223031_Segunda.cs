using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignaSalones.App.Persistencia.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Salones_Salonid",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salones_SedesUniversidad_SedeUniversidadid",
                table: "Salones");

            migrationBuilder.DropIndex(
                name: "IX_Salones_SedeUniversidadid",
                table: "Salones");

            migrationBuilder.DropColumn(
                name: "SedeUniversidadid",
                table: "Salones");

            migrationBuilder.RenameColumn(
                name: "numeroSalonesDisp",
                table: "SedesUniversidad",
                newName: "numeroSalonesDispHora");

            migrationBuilder.RenameColumn(
                name: "Salonid",
                table: "Personas",
                newName: "HorarioClaseid");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_Salonid",
                table: "Personas",
                newName: "IX_Personas_HorarioClaseid");

            migrationBuilder.AddColumn<string>(
                name: "departamento",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "materia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HorarioClase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profesorid = table.Column<int>(type: "int", nullable: true),
                    cantPersonas = table.Column<int>(type: "int", nullable: false),
                    salonAsignadoid = table.Column<int>(type: "int", nullable: true),
                    hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SedeUniversidadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioClase", x => x.id);
                    table.ForeignKey(
                        name: "FK_HorarioClase_Personas_profesorid",
                        column: x => x.profesorid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioClase_Salones_salonAsignadoid",
                        column: x => x.salonAsignadoid,
                        principalTable: "Salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioClase_SedesUniversidad_SedeUniversidadid",
                        column: x => x.SedeUniversidadid,
                        principalTable: "SedesUniversidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioClase_profesorid",
                table: "HorarioClase",
                column: "profesorid");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioClase_salonAsignadoid",
                table: "HorarioClase",
                column: "salonAsignadoid");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioClase_SedeUniversidadid",
                table: "HorarioClase",
                column: "SedeUniversidadid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_HorarioClase_HorarioClaseid",
                table: "Personas",
                column: "HorarioClaseid",
                principalTable: "HorarioClase",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_HorarioClase_HorarioClaseid",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "HorarioClase");

            migrationBuilder.DropColumn(
                name: "departamento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "materia",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "numeroSalonesDispHora",
                table: "SedesUniversidad",
                newName: "numeroSalonesDisp");

            migrationBuilder.RenameColumn(
                name: "HorarioClaseid",
                table: "Personas",
                newName: "Salonid");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_HorarioClaseid",
                table: "Personas",
                newName: "IX_Personas_Salonid");

            migrationBuilder.AddColumn<int>(
                name: "SedeUniversidadid",
                table: "Salones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salones_SedeUniversidadid",
                table: "Salones",
                column: "SedeUniversidadid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Salones_Salonid",
                table: "Personas",
                column: "Salonid",
                principalTable: "Salones",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salones_SedesUniversidad_SedeUniversidadid",
                table: "Salones",
                column: "SedeUniversidadid",
                principalTable: "SedesUniversidad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
