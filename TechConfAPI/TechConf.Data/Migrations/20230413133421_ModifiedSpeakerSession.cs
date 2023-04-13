using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConf.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedSpeakerSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "SpeakerSessions");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_EventId",
                table: "SpeakerSessions",
                newName: "IX_SpeakerSessions_EventId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerSessions",
                table: "SpeakerSessions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 19, 4, 21, 3, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 19, 4, 21, 3, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 19, 4, 21, 3, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 19, 4, 21, 3, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 19, 4, 21, 3, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerSessions_SpeakerId",
                table: "SpeakerSessions",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerSessions_Events_EventId",
                table: "SpeakerSessions",
                column: "EventId",
                principalTable: "Events",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerSessions_Events_EventId",
                table: "SpeakerSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerSessions_Speakers_SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerSessions",
                table: "SpeakerSessions");

            migrationBuilder.DropIndex(
                name: "IX_SpeakerSessions_SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SpeakerSessions");

            migrationBuilder.RenameTable(
                name: "SpeakerSessions",
                newName: "Sessions");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerSessions_EventId",
                table: "Sessions",
                newName: "IX_Sessions_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 31, 50, 391, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 31, 50, 391, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 31, 50, 391, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 31, 50, 391, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 31, 50, 391, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
