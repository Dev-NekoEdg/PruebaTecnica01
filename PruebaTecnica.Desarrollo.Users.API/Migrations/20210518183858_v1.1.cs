using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.Desarrollo.Users.API.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RoleEntityRoleId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RoleEntityRoleId",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: "14095c34-9018-40ca-b25b-6d547d1cdf98");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: "991817b6-b223-4f10-9c16-ca4e46fe37a7");

            migrationBuilder.DropColumn(
                name: "RoleEntityRoleId",
                table: "Usuario");

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { "2561d6ca-40c2-4fed-8187-7b5aaee44e1a", "Usuario" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { "e34921fb-cb32-4874-b92f-af6dd46c24f7", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: "2561d6ca-40c2-4fed-8187-7b5aaee44e1a");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: "e34921fb-cb32-4874-b92f-af6dd46c24f7");

            migrationBuilder.AddColumn<string>(
                name: "RoleEntityRoleId",
                table: "Usuario",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { "14095c34-9018-40ca-b25b-6d547d1cdf98", "Usuario" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { "991817b6-b223-4f10-9c16-ca4e46fe37a7", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RoleEntityRoleId",
                table: "Usuario",
                column: "RoleEntityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RoleEntityRoleId",
                table: "Usuario",
                column: "RoleEntityRoleId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
