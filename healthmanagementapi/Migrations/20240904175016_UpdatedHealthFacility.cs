using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace healthmanagementapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedHealthFacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b84ed6-2df6-46a7-a3ee-10bb29f82646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e7c4e9-0fc8-43d5-84ab-7d01c6766e54");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HealthFacilities");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "HealthFacilities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HealthFacilities");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HealthFacilities",
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
                    { "37b50990-175a-4727-b5ab-0ba3666cb523", null, "Role", "Admin", null, null },
                    { "86db9e5f-95c3-4b78-8798-4d4044c4c30b", null, "Role", "Super Admin", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b50990-175a-4727-b5ab-0ba3666cb523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86db9e5f-95c3-4b78-8798-4d4044c4c30b");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HealthFacilities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HealthFacilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "HealthFacilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HealthFacilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "PermissionId" },
                values: new object[,]
                {
                    { "a3b84ed6-2df6-46a7-a3ee-10bb29f82646", null, "Role", "Admin", null, null },
                    { "a8e7c4e9-0fc8-43d5-84ab-7d01c6766e54", null, "Role", "Super Admin", null, null }
                });
        }
    }
}
