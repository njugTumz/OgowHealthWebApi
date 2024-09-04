using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace healthmanagementapi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredFieldUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_ApplicationRoleID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b4adad1-add1-4822-b11c-33aa162517ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5f25560-687e-4ecb-b2bb-ae97a20d9653");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationRoleID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "PermissionId" },
                values: new object[,]
                {
                    { "a3b84ed6-2df6-46a7-a3ee-10bb29f82646", null, "Role", "Admin", null, null },
                    { "a8e7c4e9-0fc8-43d5-84ab-7d01c6766e54", null, "Role", "Super Admin", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_ApplicationRoleID",
                table: "AspNetUsers",
                column: "ApplicationRoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_ApplicationRoleID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b84ed6-2df6-46a7-a3ee-10bb29f82646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e7c4e9-0fc8-43d5-84ab-7d01c6766e54");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationRoleID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "PermissionId" },
                values: new object[,]
                {
                    { "1b4adad1-add1-4822-b11c-33aa162517ca", null, "Role", "Admin", null, null },
                    { "c5f25560-687e-4ecb-b2bb-ae97a20d9653", null, "Role", "Super Admin", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_ApplicationRoleID",
                table: "AspNetUsers",
                column: "ApplicationRoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
