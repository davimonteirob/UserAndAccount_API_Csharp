using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connection_To_DataBaseCSharpe.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuariosIdUsuario",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuariosIdUsuario",
                table: "Contas",
                column: "UsuariosIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Usuarios_UsuariosIdUsuario",
                table: "Contas",
                column: "UsuariosIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Usuarios_UsuariosIdUsuario",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_UsuariosIdUsuario",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "UsuariosIdUsuario",
                table: "Contas");
        }
    }
}
