using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Infrastructure.Migrations
{
    public partial class InitialDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    IdentificationNumber = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Area = table.Column<float>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PropertyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Medellín" },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bogotá" },
                    { 3, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cali" },
                    { 4, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Barranquilla" }
                });

            migrationBuilder.InsertData(
                table: "PropertyCategories",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Residential" },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Commercial" },
                    { 3, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industrial" },
                    { 4, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Raw Land" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CategoryId",
                table: "Properties",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
