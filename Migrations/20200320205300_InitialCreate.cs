using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampRegistrationProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sport = table.Column<string>(nullable: true),
                    Game = table.Column<string>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstMidName = table.Column<string>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Menu = table.Column<string>(nullable: true),
                    Perday = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MealsID = table.Column<Guid>(nullable: false),
                    CampersID = table.Column<Guid>(nullable: false),
                    Menu = table.Column<int>(nullable: true),
                    ActivitiesID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Activities_ActivitiesID",
                        column: x => x.ActivitiesID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Campers_CampersID",
                        column: x => x.CampersID,
                        principalTable: "Campers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Meals_MealsID",
                        column: x => x.MealsID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ActivitiesID",
                table: "Enrollments",
                column: "ActivitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CampersID",
                table: "Enrollments",
                column: "CampersID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_MealsID",
                table: "Enrollments",
                column: "MealsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
