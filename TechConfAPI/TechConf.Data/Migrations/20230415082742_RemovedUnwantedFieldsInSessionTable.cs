using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConf.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnwantedFieldsInSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerSessions_Organizations_OrganizationId",
                table: "SpeakerSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerSessions_Speakers_SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropIndex(
                name: "IX_SpeakerSessions_OrganizationId",
                table: "SpeakerSessions");

            migrationBuilder.DropIndex(
                name: "IX_SpeakerSessions_SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 15, 13, 57, 41, 956, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 15, 13, 57, 41, 956, DateTimeKind.Local).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 15, 13, 57, 41, 956, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 15, 13, 57, 41, 956, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 15, 13, 57, 41, 956, DateTimeKind.Local).AddTicks(5833));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 22, 53, 7, 759, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 22, 53, 7, 759, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 22, 53, 7, 759, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 22, 53, 7, 759, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 22, 53, 7, 759, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerSessions_OrganizationId",
                table: "SpeakerSessions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerSessions_SpeakerId",
                table: "SpeakerSessions",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerSessions_Organizations_OrganizationId",
                table: "SpeakerSessions",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerSessions_Speakers_SpeakerId",
                table: "SpeakerSessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
