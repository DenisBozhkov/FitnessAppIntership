using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessAppIntership.Migrations
{
    /// <inheritdoc />
    public partial class ConnectedTrainingsAndMembersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberEntityTrainingEntity",
                columns: table => new
                {
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEntityTrainingEntity", x => new { x.MembersId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_MemberEntityTrainingEntity_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberEntityTrainingEntity_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberEntityTrainingEntity_TrainingsId",
                table: "MemberEntityTrainingEntity",
                column: "TrainingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberEntityTrainingEntity");
        }
    }
}
