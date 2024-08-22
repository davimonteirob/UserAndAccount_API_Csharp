using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connection_To_DataBaseCSharpe.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Contas");
        }
    }
}
