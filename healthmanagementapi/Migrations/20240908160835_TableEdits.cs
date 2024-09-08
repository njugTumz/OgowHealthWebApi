using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace healthmanagementapi.Migrations
{
    /// <inheritdoc />
    public partial class TableEdits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HealthFacilities_HealthFacilityID",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b50990-175a-4727-b5ab-0ba3666cb523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86db9e5f-95c3-4b78-8798-4d4044c4c30b");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HealthWorkers");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "HealthWorkers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HealthWorkers");

            migrationBuilder.AlterColumn<int>(
                name: "HealthFacilityID",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HealthWorkers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "PermissionId" },
                values: new object[,]
                {
                    { "4da858e3-e9e7-4f38-89ee-806928948a03", null, "Role", "Super Admin", null, null },
                    { "fad4397e-dbb7-44f8-8e92-bbdefff21965", null, "Role", "Admin", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HealthFacilities_HealthFacilityID",
                table: "Patients",
                column: "HealthFacilityID",
                principalTable: "HealthFacilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HealthFacilities_HealthFacilityID",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da858e3-e9e7-4f38-89ee-806928948a03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad4397e-dbb7-44f8-8e92-bbdefff21965");

            migrationBuilder.AlterColumn<int>(
                name: "HealthFacilityID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HealthWorkers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HealthWorkers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "HealthWorkers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HealthWorkers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "PermissionId" },
                values: new object[,]
                {
                    { "37b50990-175a-4727-b5ab-0ba3666cb523", null, "Role", "Admin", null, null },
                    { "86db9e5f-95c3-4b78-8798-4d4044c4c30b", null, "Role", "Super Admin", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HealthFacilities_HealthFacilityID",
                table: "Patients",
                column: "HealthFacilityID",
                principalTable: "HealthFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
