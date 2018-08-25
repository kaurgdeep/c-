using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bankacc.Migrations
{
    public partial class account8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactions_TransactionId1",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionId1",
                table: "transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_TransactionId1",
                table: "transactions",
                newName: "IX_transactions_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "transactions",
                newName: "TransactionId1");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                newName: "IX_transactions_TransactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactions_TransactionId1",
                table: "transactions",
                column: "TransactionId1",
                principalTable: "transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
