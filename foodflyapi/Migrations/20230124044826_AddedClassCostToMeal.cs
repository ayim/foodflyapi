using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foodflyapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedClassCostToMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airlines",
                columns: table => new
                {
                    airlineid = table.Column<int>(name: "airline_id", type: "int", nullable: false),
                    airlinename = table.Column<string>(name: "airline_name", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__airlines__A016BF8034358ED5", x => x.airlineid);
                });

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    planeid = table.Column<int>(name: "plane_id", type: "int", nullable: false),
                    planetype = table.Column<string>(name: "plane_type", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__planes__4D11D7FD33EB8961", x => x.planeid);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    routeid = table.Column<int>(name: "route_id", type: "int", nullable: false),
                    airlineid = table.Column<int>(name: "airline_id", type: "int", nullable: true),
                    departureairport = table.Column<string>(name: "departure_airport", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    destinationairport = table.Column<string>(name: "destination_airport", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__routes__28F706FEB236937F", x => x.routeid);
                    table.ForeignKey(
                        name: "FK__routes__airline___60A75C0F",
                        column: x => x.airlineid,
                        principalTable: "airlines",
                        principalColumn: "airline_id");
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    mealid = table.Column<int>(name: "meal_id", type: "int", nullable: false),
                    routeid = table.Column<int>(name: "route_id", type: "int", nullable: false),
                    planeid = table.Column<int>(name: "plane_id", type: "int", nullable: true),
                    mealname = table.Column<string>(name: "meal_name", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__meals__2910B00FC1EAA60C", x => x.mealid);
                    table.ForeignKey(
                        name: "FK__meals__plane_id__66603565",
                        column: x => x.planeid,
                        principalTable: "planes",
                        principalColumn: "plane_id");
                    table.ForeignKey(
                        name: "FK__meals__route_id__656C112C",
                        column: x => x.routeid,
                        principalTable: "routes",
                        principalColumn: "route_id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    mealid = table.Column<int>(name: "meal_id", type: "int", nullable: false),
                    flightdate = table.Column<DateTime>(name: "flight_date", type: "date", nullable: false),
                    taste = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    texture = table.Column<int>(type: "int", nullable: false),
                    overallfeeling = table.Column<int>(name: "overall_feeling", type: "int", nullable: false),
                    portionsize = table.Column<int>(name: "portion_size", type: "int", nullable: true),
                    servedat = table.Column<string>(name: "served_at", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    photos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__3213E83FF7D615F1", x => x.id);
                    table.ForeignKey(
                        name: "FK__reviews__meal_id__693CA210",
                        column: x => x.mealid,
                        principalTable: "meals",
                        principalColumn: "meal_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_meals_plane_id",
                table: "meals",
                column: "plane_id");

            migrationBuilder.CreateIndex(
                name: "IX_meals_route_id",
                table: "meals",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_meal_id",
                table: "reviews",
                column: "meal_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_airline_id",
                table: "routes",
                column: "airline_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "planes");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "airlines");
        }
    }
}
