using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bankacc.Migrations
{
    public partial class account2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId1",
                table: "transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_AccountId",
                table: "users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TransactionId1",
                table: "transactions",
                column: "TransactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactions_TransactionId1",
                table: "transactions",
                column: "TransactionId1",
                principalTable: "transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_accounts_AccountId",
                table: "users",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactions_TransactionId1",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_users_accounts_AccountId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_AccountId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_transactions_TransactionId1",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "transactions");
        }
    }
}
