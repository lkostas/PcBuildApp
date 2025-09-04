using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcBuildApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtTime = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    BuildId = table.Column<int>(type: "integer", nullable: false),
                    ComponentId = table.Column<int>(type: "integer", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalWattage = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ComponentType = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsInStock = table.Column<bool>(type: "boolean", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cores = table.Column<int>(type: "integer", nullable: true),
                    Threads = table.Column<int>(type: "integer", nullable: true),
                    BaseClock = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    BoostClock = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    TDP = table.Column<int>(type: "integer", nullable: true),
                    Socket = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VRAM = table.Column<int>(type: "integer", nullable: true),
                    CoreClock = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    MemoryBandwidth = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    Speed = table.Column<int>(type: "integer", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Latency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ReadSpeed = table.Column<int>(type: "integer", nullable: true),
                    WriteSpeed = table.Column<int>(type: "integer", nullable: true),
                    IOPS = table.Column<int>(type: "integer", nullable: true),
                    StorageCapacity = table.Column<int>(type: "integer", nullable: true),
                    Wattage = table.Column<int>(type: "integer", nullable: true),
                    EfficiencyRating = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Chipset = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MaxRAM = table.Column<int>(type: "integer", nullable: true),
                    RAMSlots = table.Column<int>(type: "integer", nullable: true),
                    ComponentId = table.Column<int>(type: "integer", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Website = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LogoUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserRole = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InsertedAt", "IsActive", "IsInStock", "ManufacturerId", "Model", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "16-core (8 P-cores + 8 E-cores) desktop processor with up to 5.4 GHz boost clock. Excellent for gaming and content creation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "i7-13700K", "Intel Core i7-13700K", 419.99m, 25 },
                    { 2, 1, "8-core, 16-thread processor with 5.4 GHz boost clock. Built on advanced 5nm process technology.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "7700X", "AMD Ryzen 7 7700X", 349.99m, 18 },
                    { 3, 2, "High-performance graphics card with 12GB GDDR6X memory. Perfect for 1440p gaming with ray tracing.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 3, "RTX 4070", "NVIDIA GeForce RTX 4070", 599.99m, 12 },
                    { 4, 2, "16GB GDDR6 graphics card delivering excellent 1440p performance with advanced RDNA 3 architecture.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 2, "RX 7800 XT", "AMD Radeon RX 7800 XT", 499.99m, 0 },
                    { 5, 3, "32GB (2x16GB) DDR4-3200 memory kit with dynamic RGB lighting. Optimized for Intel and AMD platforms.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMW32GX4M2E3200C16", "Corsair Vengeance RGB Pro 32GB", 129.99m, 45 },
                    { 6, 3, "16GB (2x8GB) DDR4-3200 memory with low-profile design. Great for compact builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMK16GX4M2B3200C16", "Corsair Vengeance LPX 16GB", 59.99m, 67 },
                    { 7, 4, "2TB NVMe M.2 SSD with read speeds up to 7,000 MB/s. Perfect for gaming and professional workloads.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "MZ-V8P2T0B/AM", "Samsung 980 PRO 2TB", 199.99m, 33 },
                    { 8, 4, "1TB NVMe SSD designed for gaming with speeds up to 7,300 MB/s and optimized for DirectStorage.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "WDS100T2X0E", "WD Black SN850X 1TB", 89.99m, 28 },
                    { 9, 5, "850W 80+ Gold fully modular power supply with Zero RPM fan mode for silent operation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020200-NA", "Corsair RM850x", 139.99m, 19 },
                    { 10, 5, "650W 80+ Bronze power supply offering reliable performance for mainstream gaming builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020236-NA", "Corsair CV650", 69.99m, 41 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildComponents_BuildId",
                table: "BuildComponents",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildComponents_ComponentId",
                table: "BuildComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_Name",
                table: "Builds",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_UserId",
                table: "Builds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_CategoryId",
                table: "Components",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ManufacturerId",
                table: "Components",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_Name",
                table: "Components",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSpecs_ComponentId",
                table: "ComponentSpecs",
                column: "ComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildComponents");

            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "ComponentSpecs");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
