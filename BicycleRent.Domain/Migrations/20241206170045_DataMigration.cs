using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BicycleRent.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bicycle_renters",
                columns: table => new
                {
                    renter_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    full_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_bicycle = table.Column<DateOnly>(type: "date", nullable: true),
                    phone_number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bicycle_renters", x => x.renter_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bicycle_types",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bicycle_types", x => x.type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bicycles",
                columns: table => new
                {
                    bicycle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    serial_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bicycles", x => x.bicycle_id);
                    table.ForeignKey(
                        name: "FK_bicycles_bicycle_types_type_id",
                        column: x => x.type_id,
                        principalTable: "bicycle_types",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rents",
                columns: table => new
                {
                    rent_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    renter_id = table.Column<int>(type: "int", nullable: false),
                    bicycle_id = table.Column<int>(type: "int", nullable: false),
                    time_start = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    time_end = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rents", x => x.rent_id);
                    table.ForeignKey(
                        name: "FK_rents_bicycle_renters_renter_id",
                        column: x => x.renter_id,
                        principalTable: "bicycle_renters",
                        principalColumn: "renter_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rents_bicycles_bicycle_id",
                        column: x => x.bicycle_id,
                        principalTable: "bicycles",
                        principalColumn: "bicycle_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "bicycle_renters",
                columns: new[] { "renter_id", "id_bicycle", "full_name", "phone_number" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 9, 1), "Kruglova Daria Grigorievna", "71110010101" },
                    { 2, new DateOnly(1978, 1, 27), "Astakhov Timur Fedorovich", "71114668965" },
                    { 3, new DateOnly(1999, 8, 10), "Morozov Konstantin Alexandrovich", "71117382789" },
                    { 4, new DateOnly(2004, 12, 11), "Timofeev Nikolai Alexandrovich", "71110661323" },
                    { 5, new DateOnly(1989, 3, 22), "Zakharova Kristina Konstantinovna", "71111970567" },
                    { 6, new DateOnly(2002, 5, 17), "Shcherbakov Vladimir Semyonovich", "71113754455" },
                    { 7, new DateOnly(1997, 10, 19), "Stepanova Ekaterina Dmitrievna", "71111238745" },
                    { 8, new DateOnly(1998, 6, 8), "Kuznetsova Alina Igorevna", "71113039008" },
                    { 9, new DateOnly(2003, 5, 28), "Sokolov Daniil Ivanovich", "71118567832" },
                    { 10, new DateOnly(2000, 2, 28), "Makarov Savva Evgenievich", "71113840393" }
                });

            migrationBuilder.InsertData(
                table: "bicycle_types",
                columns: new[] { "type_id", "price", "type" },
                values: new object[,]
                {
                    { 1, 300m, "Mountain" },
                    { 2, 200m, "Road" },
                    { 3, 200m, "Walking" },
                    { 4, 250m, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "bicycles",
                columns: new[] { "bicycle_id", "color", "model", "serial_number", "type_id" },
                values: new object[,]
                {
                    { 1, "Blue", "Navigator 910 MD", "M001", 1 },
                    { 2, "Orange", "Forward Apache 29 XD", "M002", 1 },
                    { 3, "Yellow", "Stinger Element Evo 29", "M003", 1 },
                    { 4, "White", "Aspect Allroad", "R001", 2 },
                    { 5, "Black", "Stark Peloton", "R002", 2 },
                    { 6, "Black-Blue", "Format 5211", "R003", 2 },
                    { 7, "Beige", "Stark Comfort 3-speed", "W001", 3 },
                    { 8, "Gray", "Stels Energy VI", "W002", 3 },
                    { 9, "White", "Stark Comfort 3-speed", "W003", 3 },
                    { 10, "Orange", "Format 5222 CF", "S001", 4 },
                    { 11, "Beige", "Bear Bike Perm 2021", "S002", 4 },
                    { 12, "Black", "Electra Loft 7D", "S003", 4 }
                });

            migrationBuilder.InsertData(
                table: "rents",
                columns: new[] { "rent_id", "bicycle_id", "renter_id", "time_end", "time_start" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 12, 14, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 12, 35, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2024, 6, 1, 20, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 16, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 2, new DateTime(2024, 6, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 11, 2, new DateTime(2024, 7, 10, 18, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 12, 3, new DateTime(2024, 9, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 8, 4, new DateTime(2024, 8, 18, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 18, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 9, 4, new DateTime(2024, 7, 1, 20, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 18, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, 5, new DateTime(2024, 4, 29, 16, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, 6, new DateTime(2024, 4, 29, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 8, 6, new DateTime(2024, 7, 7, 20, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 7, 19, 35, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 7, 6, new DateTime(2024, 6, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, 6, new DateTime(2024, 5, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 13, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, 7, new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 5, 8, new DateTime(2024, 8, 1, 14, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 10, 8, new DateTime(2024, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 7, 9, new DateTime(2024, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 11, 9, new DateTime(2024, 6, 11, 18, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 11, 17, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, 9, new DateTime(2024, 7, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 12, 10, new DateTime(2024, 6, 11, 18, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 11, 17, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 8, 10, new DateTime(2024, 8, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bicycles_type_id",
                table: "bicycles",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_rents_bicycle_id",
                table: "rents",
                column: "bicycle_id");

            migrationBuilder.CreateIndex(
                name: "IX_rents_renter_id",
                table: "rents",
                column: "renter_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rents");

            migrationBuilder.DropTable(
                name: "bicycle_renters");

            migrationBuilder.DropTable(
                name: "bicycles");

            migrationBuilder.DropTable(
                name: "bicycle_types");
        }
    }
}
