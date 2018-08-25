using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bankacc.Migrations
{
    public partial class account7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_accounts_AccountId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_AccountId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_PersonId",
                table: "accounts",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_users_PersonId",
                table: "accounts",
                column: "PersonId",
                principalTable: "users",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_users_PersonId",
                table: "accounts");

            migrationBuilder.DropIndex(
                name: "IX_accounts_PersonId",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "accounts");

            migrationBuilder.CreateIndex(
                name: "IX_users_AccountId",
                table: "users",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_accounts_AccountId",
                table: "users",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
