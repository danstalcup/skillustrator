using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class UpdateContextForPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Organization_OrganizationId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_Person_PersonId",
                table: "PersonSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "Person",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_People_PersonId",
                table: "PersonSkill",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Person_OrganizationId",
                table: "Person",
                newName: "IX_People_OrganizationId");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSkill_People_PersonId",
                table: "PersonSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Organization_OrganizationId",
                table: "People",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSkill_Person_PersonId",
                table: "PersonSkill",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_People_OrganizationId",
                table: "People",
                newName: "IX_Person_OrganizationId");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");
        }
    }
}
