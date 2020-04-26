using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentalAgency.Migrations
{
    public partial class SeedDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Brand", "CustomerId", "Frame", "LocationId", "OnHire", "ReservationsId", "type" },
                values: new object[,]
                {
                    { 1, "Trek", null, 1, 1, false, null, 1 },
                    { 2, "Mongoose", null, 0, 3, false, null, 2 },
                    { 3, "Raleigh", null, 1, 1, false, null, 4 },
                    { 4, "Diamondback", null, 1, 4, false, null, 0 },
                    { 5, "Specialized", null, 2, 1, false, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Admin", "FirstName", "LastName", "LocationId" },
                values: new object[,]
                {
                    { 1, true, "John", "Smith", 2 },
                    { 2, false, "Tyler", "Johnson", 1 },
                    { 3, false, "Banana", "Backpack", 4 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "BranchEmail", "City", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "123 North Street", "JaxBranch@KoolBikes.com", "Jacksonville", "NC", 28542 },
                    { 2, "456 South Street", "NewBern@KoolBikes.com", "New Bern", "NC", 25343 },
                    { 3, "678 West Street", "Wilminton@KoolBikes.com", "Wilmington", "NC", 24423 },
                    { 4, "234 East Street", "Raleigh@KoolBikes.com", "Raleigh", "NC", 24242 },
                    { 5, "525 Center Street", "Emerald@KoolBikes.com", "Emerald Isle", "NC", 26876 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
