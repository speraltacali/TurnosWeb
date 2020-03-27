using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TW.Infraestructura.Context.Migrations
{
    public partial class EliminandoRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SubCategoria");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Lugar");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Fecha");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SubCategoria",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Lugar",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Horario",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Fecha",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Empresa",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Comprobante",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Categoria",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
