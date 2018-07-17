using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class AddedCheckInTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckInTimes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Barcode = table.Column<int>(nullable: false),
                    BarcodeUserID = table.Column<int>(nullable: true),
                    CheckInTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInTimes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckInTimes_BarcodeUsers_BarcodeUserID",
                        column: x => x.BarcodeUserID,
                        principalTable: "BarcodeUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckInTimes_BarcodeUserID",
                table: "CheckInTimes",
                column: "BarcodeUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckInTimes");
        }
    }
}
