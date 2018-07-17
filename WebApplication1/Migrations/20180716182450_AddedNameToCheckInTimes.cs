using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class AddedNameToCheckInTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInTimes_BarcodeUsers_BarcodeUserID",
                table: "CheckInTimes");

            migrationBuilder.DropIndex(
                name: "IX_CheckInTimes_BarcodeUserID",
                table: "CheckInTimes");

            migrationBuilder.DropColumn(
                name: "BarcodeUserID",
                table: "CheckInTimes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CheckInTimes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInTime",
                table: "BarcodeUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CheckInTimes");

            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "BarcodeUsers");

            migrationBuilder.AddColumn<int>(
                name: "BarcodeUserID",
                table: "CheckInTimes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckInTimes_BarcodeUserID",
                table: "CheckInTimes",
                column: "BarcodeUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInTimes_BarcodeUsers_BarcodeUserID",
                table: "CheckInTimes",
                column: "BarcodeUserID",
                principalTable: "BarcodeUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
