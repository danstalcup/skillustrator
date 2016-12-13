using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class UpdateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_Skill_SkillId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTag_Skill_SkillId",
                table: "SkillTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skill",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonId",
                table: "Skill",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_Skills_SkillId",
                table: "PersonSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_People_PersonId",
                table: "Skill",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTag_Skills_SkillId",
                table: "SkillTag",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_Skills_SkillId",
                table: "PersonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_People_PersonId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTag_Skills_SkillId",
                table: "SkillTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PersonId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Skills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_Skill_SkillId",
                table: "PersonSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTag_Skill_SkillId",
                table: "SkillTag",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");
        }
    }
}
