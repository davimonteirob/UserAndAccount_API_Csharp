using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connection_To_DataBaseCSharpe.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Contas", new string[] {"Nome","Numero","Saldo"}, 
                new object[] {"Danilo Lima","4545","1400"});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //caso precisemos fazer um DownGrade da nossa tabela, informamos:
            migrationBuilder.Sql("DELETE FROM Contas");
        }
    }
}
