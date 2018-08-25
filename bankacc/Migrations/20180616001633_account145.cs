using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bankacc.Migrations
{
    public partial class account145 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_AccountsId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "AccountsId",
                table: "transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AccountsId",
                table: "transactions",
                newName: "IX_transactions_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "transactions",
                newName: "AccountsId");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                newName: "IX_transactions_AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_AccountsId",
                table: "transactions",
                column: "AccountsId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
