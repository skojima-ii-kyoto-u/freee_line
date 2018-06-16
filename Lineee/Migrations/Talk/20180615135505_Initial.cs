using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lineee.Migrations.Talk
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FromNameID = table.Column<int>(nullable: true),
                    ToNameID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Talk_Account_FromNameID",
                        column: x => x.FromNameID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talk_Account_ToNameID",
                        column: x => x.ToNameID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talk_FromNameID",
                table: "Talk",
                column: "FromNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_ToNameID",
                table: "Talk",
                column: "ToNameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talk");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
