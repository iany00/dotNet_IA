﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferencePlanner.Data.Migrations
{
    public partial class ChangeSpeakerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Speakers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Speakers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
