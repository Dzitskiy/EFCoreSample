using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID_comp = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID_comp);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    ID_psg = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.ID_psg);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    trip_no = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_comp = table.Column<int>(type: "integer", nullable: false),
                    plane = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    town_from = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    town_to = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    time_out = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    time_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.trip_no);
                    table.ForeignKey(
                        name: "FK_Trips_Companies_ID_comp",
                        column: x => x.ID_comp,
                        principalTable: "Companies",
                        principalColumn: "ID_comp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pass_in_trip",
                columns: table => new
                {
                    trip_no = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ID_psg = table.Column<int>(type: "integer", nullable: false),
                    place = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pass_in_trip", x => new { x.ID_psg, x.trip_no, x.date });
                    table.ForeignKey(
                        name: "FK_Pass_in_trip_Passengers_ID_psg",
                        column: x => x.ID_psg,
                        principalTable: "Passengers",
                        principalColumn: "ID_psg",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pass_in_trip_Trips_trip_no",
                        column: x => x.trip_no,
                        principalTable: "Trips",
                        principalColumn: "trip_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pass_in_trip_trip_no",
                table: "Pass_in_trip",
                column: "trip_no");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ID_comp",
                table: "Trips",
                column: "ID_comp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pass_in_trip");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
