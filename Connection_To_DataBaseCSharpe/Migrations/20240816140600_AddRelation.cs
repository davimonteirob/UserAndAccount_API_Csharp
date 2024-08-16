using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connection_To_DataBaseCSharpe.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosIdUsuario",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuariosIdUsuario",
                table: "Contas",
                column: "UsuariosIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Usuarios_UsuariosIdUsuario",
                table: "Contas",
                column: "UsuariosIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
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
                name: "UsuarioId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "UsuariosIdUsuario",
                table: "Contas");
        }
    }
}
