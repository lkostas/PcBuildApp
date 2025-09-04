using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcBuildApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMisingComponentsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ComponentType", "Description", "InsertedAt", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Processors" },
                    { 2, "GPU", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Graphics Cards" },
                    { 3, "RAM", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Memory" },
                    { 4, "Storage", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Storage" },
                    { 5, "PSU", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Power Supplies" },
                    { 6, "Motherboard", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Motherboards" },
                    { 7, "Cooling", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Cooling" },
                    { 8, "Case", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Cases" }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InsertedAt", "IsActive", "IsInStock", "ManufacturerId", "Model", "Name", "Price", "StockQuantity", "TDP" },
                values: new object[,]
                {
                    { 11, 6, "AMD B550 motherboard with WiFi", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 5, "B550-F", "ASUS ROG STRIX B550-F", 189.99m, 15, 15 },
                    { 12, 6, "Intel Z690 motherboard with DDR5 support", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 5, "Z690-A", "ASUS Prime Z690-A", 249.99m, 12, 20 },
                    { 13, 7, "Premium air cooler for high-end CPUs", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 6, "NH-D15", "Noctua NH-D15", 99.99m, 20, 0 },
                    { 14, 7, "240mm liquid cooler with RGB", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "H100i", "Corsair H100i RGB", 149.99m, 18, 5 },
                    { 15, 8, "Silent mid-tower case with excellent airflow", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 7, "Define 7", "Fractal Design Define 7", 169.99m, 10, 0 },
                    { 16, 8, "Mid-tower case optimized for airflow", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "4000D", "Corsair 4000D Airflow", 94.99m, 25, 0 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "InsertedAt", "IsActive", "LogoUrl", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Leading CPU manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Intel", null },
                    { 2, "CPU and GPU manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "AMD", null },
                    { 3, "Leading GPU manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "NVIDIA", null },
                    { 4, "Memory and PSU manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Corsair", null },
                    { 5, "Motherboard manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "ASUS", null },
                    { 6, "Cooling manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Noctua", null },
                    { 7, "Case manufacturer", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Fractal Design", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InsertedAt", "IsActive", "IsInStock", "ManufacturerId", "Model", "Name", "Price", "StockQuantity", "TDP" },
                values: new object[,]
                {
                    { 1, 1, "16-core (8 P-cores + 8 E-cores) desktop processor with up to 5.4 GHz boost clock. Excellent for gaming and content creation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "i7-13700K", "Intel Core i7-13700K", 419.99m, 25, null },
                    { 2, 1, "8-core, 16-thread processor with 5.4 GHz boost clock. Built on advanced 5nm process technology.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "7700X", "AMD Ryzen 7 7700X", 349.99m, 18, null },
                    { 3, 2, "High-performance graphics card with 12GB GDDR6X memory. Perfect for 1440p gaming with ray tracing.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 3, "RTX 4070", "NVIDIA GeForce RTX 4070", 599.99m, 12, null },
                    { 4, 2, "16GB GDDR6 graphics card delivering excellent 1440p performance with advanced RDNA 3 architecture.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 2, "RX 7800 XT", "AMD Radeon RX 7800 XT", 499.99m, 0, null },
                    { 5, 3, "32GB (2x16GB) DDR4-3200 memory kit with dynamic RGB lighting. Optimized for Intel and AMD platforms.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMW32GX4M2E3200C16", "Corsair Vengeance RGB Pro 32GB", 129.99m, 45, null },
                    { 6, 3, "16GB (2x8GB) DDR4-3200 memory with low-profile design. Great for compact builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMK16GX4M2B3200C16", "Corsair Vengeance LPX 16GB", 59.99m, 67, null },
                    { 7, 4, "2TB NVMe M.2 SSD with read speeds up to 7,000 MB/s. Perfect for gaming and professional workloads.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "MZ-V8P2T0B/AM", "Samsung 980 PRO 2TB", 199.99m, 33, null },
                    { 8, 4, "1TB NVMe SSD designed for gaming with speeds up to 7,300 MB/s and optimized for DirectStorage.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "WDS100T2X0E", "WD Black SN850X 1TB", 89.99m, 28, null },
                    { 9, 5, "850W 80+ Gold fully modular power supply with Zero RPM fan mode for silent operation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020200-NA", "Corsair RM850x", 139.99m, 19, null },
                    { 10, 5, "650W 80+ Bronze power supply offering reliable performance for mainstream gaming builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020236-NA", "Corsair CV650", 69.99m, 41, null }
                });
        }
    }
}
