using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastPay.Transactions.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account_Sequences",
                columns: table => new
                {
                    client_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    last_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Sequences", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Sequences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Sequences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    credit_limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Accounts", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Client_Sequences",
                columns: new[] { "id", "last_number" },
                values: new object[] { 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_Sequences");

            migrationBuilder.DropTable(
                name: "Client_Sequences");

            migrationBuilder.DropTable(
                name: "Tb_Accounts");
        }
    }
}
