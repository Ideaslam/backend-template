using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edura.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    AddUserId = table.Column<int>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    RelatedTo = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    CustomFieldOneKey = table.Column<string>(nullable: true),
                    CustomFieldOneValue = table.Column<string>(nullable: true),
                    CustomFieldTwoKey = table.Column<string>(nullable: true),
                    CustomFieldTwoValue = table.Column<string>(nullable: true),
                    CustomFieldThreeKey = table.Column<string>(nullable: true),
                    CustomFieldThreeValue = table.Column<string>(nullable: true),
                    CustomFieldFourKey = table.Column<string>(nullable: true),
                    CustomFieldFourValue = table.Column<string>(nullable: true),
                    CustomFieldFiveKey = table.Column<string>(nullable: true),
                    CustomFieldFiveValue = table.Column<string>(nullable: true),
                    CustomFieldSixKey = table.Column<string>(nullable: true),
                    CustomFieldSixValue = table.Column<string>(nullable: true),
                    CustomFieldSevenKey = table.Column<string>(nullable: true),
                    CustomFieldSevenValue = table.Column<string>(nullable: true),
                    CustomFieldEightKey = table.Column<string>(nullable: true),
                    CustomFieldEightValue = table.Column<string>(nullable: true),
                    CustomFieldNineKey = table.Column<string>(nullable: true),
                    CustomFieldNineValue = table.Column<string>(nullable: true),
                    CustomFieldTenKey = table.Column<string>(nullable: true),
                    CustomFieldTenValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppResources_DetailCodes_AreaId",
                        column: x => x.AreaId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppResources_DetailCodes_CityId",
                        column: x => x.CityId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppResources_DetailCodes_CountryId",
                        column: x => x.CountryId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9a66f84-d36f-41c3-8db5-67debfad76da", "AQAAAAEAACcQAAAAEF5I5gEOoivSa7NTT+yngT+JfYv02TdOKi6PjSb9bicG9+ZFjy8MczkbksulqmCT6g==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppResources_AreaId",
                table: "AppResources",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResources_CityId",
                table: "AppResources",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppResources_CountryId",
                table: "AppResources",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppResources");

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "DetailCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "MasterCodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83229e4d-e32b-4a42-9ae6-283b750394b4", "AQAAAAEAACcQAAAAEIpRb2r4NliFIblxjAbpbzR8OYeHRXTO3HTsBbym5bDQATbVk5eAtMLXRLS4ERtZ6Q==" });
        }
    }
}
