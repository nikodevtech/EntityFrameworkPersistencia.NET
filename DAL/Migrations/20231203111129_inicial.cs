using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sc_evaluacion");

            migrationBuilder.CreateTable(
                name: "eva_cat_evaluacion",
                schema: "sc_evaluacion",
                columns: table => new
                {
                    cod_evaluacion = table.Column<string>(type: "text", nullable: false),
                    desc_evaluacion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eva_cat_evaluacion", x => x.cod_evaluacion);
                });

            migrationBuilder.CreateTable(
                name: "eva_tch_notas_evaluacion",
                schema: "sc_evaluacion",
                columns: table => new
                {
                    id_nota_evaluacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    md_uuid = table.Column<string>(type: "text", nullable: true),
                    md_fch = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    cod_alumno = table.Column<string>(type: "text", nullable: false),
                    nota_evaluacion = table.Column<int>(type: "integer", nullable: false),
                    cod_evaluacion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eva_tch_notas_evaluacion", x => x.id_nota_evaluacion);
                    table.ForeignKey(
                        name: "FK_eva_tch_notas_evaluacion_eva_cat_evaluacion_cod_evaluacion",
                        column: x => x.cod_evaluacion,
                        principalSchema: "sc_evaluacion",
                        principalTable: "eva_cat_evaluacion",
                        principalColumn: "cod_evaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eva_tch_notas_evaluacion_cod_evaluacion",
                schema: "sc_evaluacion",
                table: "eva_tch_notas_evaluacion",
                column: "cod_evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eva_tch_notas_evaluacion",
                schema: "sc_evaluacion");

            migrationBuilder.DropTable(
                name: "eva_cat_evaluacion",
                schema: "sc_evaluacion");
        }
    }
}
