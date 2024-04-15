using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_BL3W.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TxnRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTransactions", x => x.TransactionId);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 15, 21, 52, 8, 378, DateTimeKind.Local).AddTicks(9876));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineTransactions");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 15, 21, 50, 3, 553, DateTimeKind.Local).AddTicks(8518));
        }
    }
}
