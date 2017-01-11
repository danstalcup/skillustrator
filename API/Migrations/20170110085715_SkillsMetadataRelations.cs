using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class SkillsMetadataRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_SkillLevel_SkillLevelId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_TimePeriod_TimeSinceUsedId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_TimePeriod_TimeUsedId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_People_PersonId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimePeriod",
                table: "TimePeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillLevel",
                table: "SkillLevel");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PersonId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Skills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimePeriods",
                table: "TimePeriod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillLevels",
                table: "SkillLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_SkillLevels_SkillLevelId",
                table: "PersonSkill",
                column: "SkillLevelId",
                principalTable: "SkillLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_TimePeriods_TimeSinceUsedId",
                table: "PersonSkill",
                column: "TimeSinceUsedId",
                principalTable: "TimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_TimePeriods_TimeUsedId",
                table: "PersonSkill",
                column: "TimeUsedId",
                principalTable: "TimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "TimePeriod",
                newName: "TimePeriods");

            migrationBuilder.RenameTable(
                name: "SkillLevel",
                newName: "SkillLevels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_SkillLevels_SkillLevelId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_TimePeriods_TimeSinceUsedId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_TimePeriods_TimeUsedId",
                table: "PersonSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimePeriods",
                table: "TimePeriods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillLevels",
                table: "SkillLevels");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimePeriod",
                table: "TimePeriods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillLevel",
                table: "SkillLevels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonId",
                table: "Skills",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_SkillLevel_SkillLevelId",
                table: "PersonSkill",
                column: "SkillLevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_TimePeriod_TimeSinceUsedId",
                table: "PersonSkill",
                column: "TimeSinceUsedId",
                principalTable: "TimePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_TimePeriod_TimeUsedId",
                table: "PersonSkill",
                column: "TimeUsedId",
                principalTable: "TimePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_People_PersonId",
                table: "Skills",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "TimePeriods",
                newName: "TimePeriod");

            migrationBuilder.RenameTable(
                name: "SkillLevels",
                newName: "SkillLevel");
        }
    }
}
