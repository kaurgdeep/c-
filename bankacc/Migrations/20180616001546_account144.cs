using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bankacc.Migrations
{
    public partial class account144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "users",
                newName: "AccountId2");

            migrationBuilder.CreateIndex(
                name: "IX_users_AccountId2",
                table: "users",
                column: "AccountId2");

            migrationBuilder.AddForeignKey(
                name: "FK_users_accounts_AccountId2",
                table: "users",
                column: "AccountId2",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_accounts_AccountId2",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_AccountId2",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "AccountId2",
                table: "users",
                newName: "AccountId");
        }
    }
}
