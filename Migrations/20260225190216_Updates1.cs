using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNB.Migrations
{
    /// <inheritdoc />
    public partial class Updates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenitiesHotel_Amenities_AmenitiesId",
                table: "AmenitiesHotel");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenitiesHotel_Hotels_HotelsId",
                table: "AmenitiesHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenitiesHotel",
                table: "AmenitiesHotel");

            migrationBuilder.RenameTable(
                name: "AmenitiesHotel",
                newName: "HotelAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_AmenitiesHotel_HotelsId",
                table: "HotelAmenities",
                newName: "IX_HotelAmenities_HotelsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelAmenities",
                table: "HotelAmenities",
                columns: new[] { "AmenitiesId", "HotelsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAmenities_Amenities_AmenitiesId",
                table: "HotelAmenities",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAmenities_Hotels_HotelsId",
                table: "HotelAmenities",
                column: "HotelsId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAmenities_Amenities_AmenitiesId",
                table: "HotelAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelAmenities_Hotels_HotelsId",
                table: "HotelAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelAmenities",
                table: "HotelAmenities");

            migrationBuilder.RenameTable(
                name: "HotelAmenities",
                newName: "AmenitiesHotel");

            migrationBuilder.RenameIndex(
                name: "IX_HotelAmenities_HotelsId",
                table: "AmenitiesHotel",
                newName: "IX_AmenitiesHotel_HotelsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenitiesHotel",
                table: "AmenitiesHotel",
                columns: new[] { "AmenitiesId", "HotelsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AmenitiesHotel_Amenities_AmenitiesId",
                table: "AmenitiesHotel",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AmenitiesHotel_Hotels_HotelsId",
                table: "AmenitiesHotel",
                column: "HotelsId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
