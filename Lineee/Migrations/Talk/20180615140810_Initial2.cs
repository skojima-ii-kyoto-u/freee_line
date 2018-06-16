using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lineee.Migrations.Talk
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talk_Account_FromNameID",
                table: "Talk");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_Account_ToNameID",
                table: "Talk");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Talk_FromNameID",
                table: "Talk");

            migrationBuilder.DropIndex(
                name: "IX_Talk_ToNameID",
                table: "Talk");

            migrationBuilder.AlterColumn<int>(
                name: "ToNameID",
                table: "Talk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromNameID",
                table: "Talk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Talk",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Talk");

            migrationBuilder.AlterColumn<int>(
                name: "ToNameID",
                table: "Talk",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FromNameID",
                table: "Talk",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.CreateIndex(
                name: "IX_Talk_FromNameID",
                table: "Talk",
                column: "FromNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_ToNameID",
                table: "Talk",
                column: "ToNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_Account_FromNameID",
                table: "Talk",
                column: "FromNameID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_Account_ToNameID",
                table: "Talk",
                column: "ToNameID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
