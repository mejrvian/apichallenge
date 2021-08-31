using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeSoftware.OrderManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ActiveFlag = table.Column<bool>(nullable: true, defaultValue: true),
                    ActivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    DeactivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    SystemFlag = table.Column<bool>(nullable: true, defaultValue: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ActiveFlag = table.Column<bool>(nullable: true, defaultValue: true),
                    ActivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    DeactivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    SystemFlag = table.Column<bool>(nullable: true, defaultValue: false),
                    ModuleNo = table.Column<int>(nullable: false),
                    ModuleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ActiveFlag = table.Column<bool>(nullable: true, defaultValue: true),
                    ActivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    DeactivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    SystemFlag = table.Column<bool>(nullable: true, defaultValue: false),
                    ProductName = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RoleLevel = table.Column<int>(nullable: false),
                    Modules = table.Column<string>(nullable: true),
                    SutId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    ActiveFlag = table.Column<bool>(nullable: true, defaultValue: true),
                    ActivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    DeactivationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    PurchaseOrderNo = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModUserId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    LastModDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    ExternalId = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SourceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true, defaultValue: "Unmanaged data"),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))),
                    Quantity = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProductId",
                table: "PurchaseOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CustomerId",
                table: "PurchaseOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "UserRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
