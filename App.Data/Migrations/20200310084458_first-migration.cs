using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edura.Data.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterCodes",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    FieldOneTitle = table.Column<string>(nullable: true),
                    FieldOneTitleAr = table.Column<string>(nullable: true),
                    FieldOneIsVisible = table.Column<bool>(nullable: false),
                    FieldTwoTitle = table.Column<string>(nullable: true),
                    FieldTwoTitelAr = table.Column<string>(nullable: true),
                    FieldTwoIsVisible = table.Column<bool>(nullable: false),
                    FieldThreeTitle = table.Column<string>(nullable: true),
                    FieldThreeTitleAr = table.Column<string>(nullable: true),
                    FieldThreeIsVisible = table.Column<bool>(nullable: false),
                    FieldFourTitle = table.Column<string>(nullable: true),
                    FieldFourTitleAr = table.Column<string>(nullable: true),
                    FieldFourIsVisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterCodes_MasterCodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MasterCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    NameAr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    ParentRoleId = table.Column<int>(nullable: true),
                    GrantLevel = table.Column<int>(nullable: true),
                    RowStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    ReceiveNotification = table.Column<bool>(nullable: false),
                    ReceiveSms = table.Column<bool>(nullable: false),
                    ReceiveEmail = table.Column<bool>(nullable: false),
                    PreferredLanguageId = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    AuthProviderType = table.Column<int>(nullable: true),
                    AuthProviderAccessToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailCodes",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAr = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    OrderedIndex = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    MasterCodeId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    FieldOneValue = table.Column<string>(nullable: true),
                    FieldTwoValue = table.Column<string>(nullable: true),
                    FieldThreeValue = table.Column<string>(nullable: true),
                    FieldFourValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailCodes_DetailCodes_AreaId",
                        column: x => x.AreaId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailCodes_DetailCodes_CityId",
                        column: x => x.CityId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailCodes_DetailCodes_CountryId",
                        column: x => x.CountryId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailCodes_MasterCodes_MasterCodeId",
                        column: x => x.MasterCodeId,
                        principalTable: "MasterCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailCodes_DetailCodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DetailCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MasterCodes",
                columns: new[] { "Id", "AddUserId", "AddedDate", "Code", "Description", "DescriptionAr", "FieldFourIsVisible", "FieldFourTitle", "FieldFourTitleAr", "FieldOneIsVisible", "FieldOneTitle", "FieldOneTitleAr", "FieldThreeIsVisible", "FieldThreeTitle", "FieldThreeTitleAr", "FieldTwoIsVisible", "FieldTwoTitelAr", "FieldTwoTitle", "IPAddress", "ModifiedDate", "ModifyUserId", "Name", "NameAr", "ParentId", "RowStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(2443), "1001", null, null, false, null, null, true, "Country Code", "كود الدولة", false, null, null, false, null, null, null, null, 0, "Country", "دولة", null, 1 },
                    { 2, 1, new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(8080), "1002", null, null, false, null, null, false, null, null, false, null, null, false, null, null, null, null, 0, "City", "مدينة", null, 1 },
                    { 3, 1, new DateTime(2020, 3, 10, 10, 44, 56, 759, DateTimeKind.Local).AddTicks(8189), "1003", null, null, false, null, null, false, null, null, false, null, null, false, null, null, null, null, 0, " Area", "منطقة", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "DescriptionAr", "GrantLevel", "Name", "NameAr", "NormalizedName", "ParentRoleId", "RowStatus" },
                values: new object[] { 1, "", null, null, 1, "fullaccess", "التحكم الكامل", "fullaccess", null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AreaId", "AuthProviderAccessToken", "AuthProviderType", "CityId", "ConcurrencyStamp", "CountryCode", "CountryId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PreferredLanguageId", "ReceiveEmail", "ReceiveNotification", "ReceiveSms", "RowStatus", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { 1, 0, null, null, null, null, "83229e4d-e32b-4a42-9ae6-283b750394b4", null, null, "admin@edura.com", true, false, null, "admin@edura.com", "admin", "AQAAAAEAACcQAAAAEIpRb2r4NliFIblxjAbpbzR8OYeHRXTO3HTsBbym5bDQATbVk5eAtMLXRLS4ERtZ6Q==", null, false, 0, true, true, true, 1, "", false, "admin", 5 });

            migrationBuilder.InsertData(
                table: "DetailCodes",
                columns: new[] { "Id", "AddUserId", "AddedDate", "AreaId", "CityId", "Code", "CountryId", "Description", "DescriptionAr", "FieldFourValue", "FieldOneValue", "FieldThreeValue", "FieldTwoValue", "IPAddress", "MasterCodeId", "ModifiedDate", "ModifyUserId", "Name", "NameAr", "OrderedIndex", "ParentId", "RowStatus" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(4322), null, null, "eg", null, null, null, null, "+20", null, null, null, 1, null, 0, "Egypt", "مصر", 1, null, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DetailCodes",
                columns: new[] { "Id", "AddUserId", "AddedDate", "AreaId", "CityId", "Code", "CountryId", "Description", "DescriptionAr", "FieldFourValue", "FieldOneValue", "FieldThreeValue", "FieldTwoValue", "IPAddress", "MasterCodeId", "ModifiedDate", "ModifyUserId", "Name", "NameAr", "OrderedIndex", "ParentId", "RowStatus" },
                values: new object[] { 2, 1, new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(6429), null, null, "cai", null, null, null, null, null, null, null, null, 2, null, 0, "Cairo", "القاهرة", 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "DetailCodes",
                columns: new[] { "Id", "AddUserId", "AddedDate", "AreaId", "CityId", "Code", "CountryId", "Description", "DescriptionAr", "FieldFourValue", "FieldOneValue", "FieldThreeValue", "FieldTwoValue", "IPAddress", "MasterCodeId", "ModifiedDate", "ModifyUserId", "Name", "NameAr", "OrderedIndex", "ParentId", "RowStatus" },
                values: new object[] { 3, 1, new DateTime(2020, 3, 10, 10, 44, 56, 761, DateTimeKind.Local).AddTicks(6532), null, null, "11765", null, null, null, null, null, null, null, null, 3, null, 0, "Nasr City", "مدينة نصر", 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DetailCodes_AreaId",
                table: "DetailCodes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCodes_CityId",
                table: "DetailCodes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCodes_CountryId",
                table: "DetailCodes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCodes_MasterCodeId",
                table: "DetailCodes",
                column: "MasterCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCodes_ParentId",
                table: "DetailCodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterCodes_ParentId",
                table: "MasterCodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCodes");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "MasterCodes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
