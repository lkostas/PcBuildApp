using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcBuildApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedComponentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InsertedAt", "IsActive", "IsInStock", "ManufacturerId", "Model", "Name", "Price", "StockQuantity", "TDP" },
                values: new object[,]
                {
                    // CPUs (CategoryId = 1)
                    { 1, 1, "16-core (8 P-cores + 8 E-cores) desktop processor with up to 5.4 GHz boost clock. Excellent for gaming and content creation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "i7-13700K", "Intel Core i7-13700K", 419.99m, 25, 125 },
                    { 2, 1, "8-core, 16-thread processor with 5.4 GHz boost clock. Built on advanced 5nm process technology.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "7700X", "AMD Ryzen 7 7700X", 349.99m, 18, 105 },
                    { 17, 1, "6-core, 12-thread processor with excellent gaming performance.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "i5-13600K", "Intel Core i5-13600K", 319.99m, 30, 125 },
                    { 18, 1, "6-core, 12-thread AMD processor with high efficiency.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "5600X", "AMD Ryzen 5 5600X", 199.99m, 35, 65 },

                    // GPUs (CategoryId = 2)
                    { 3, 2, "High-performance graphics card with 12GB GDDR6X memory. Perfect for 1440p gaming with ray tracing.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 3, "RTX 4070", "NVIDIA GeForce RTX 4070", 599.99m, 12, 200 },
                    { 4, 2, "16GB GDDR6 graphics card delivering excellent 1440p performance with advanced RDNA 3 architecture.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, 2, "RX 7800 XT", "AMD Radeon RX 7800 XT", 499.99m, 0, 263 },
                    { 19, 2, "Excellent 1080p gaming performance with 8GB VRAM.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 3, "RTX 4060", "NVIDIA GeForce RTX 4060", 299.99m, 20, 115 },
                    { 20, 2, "Budget-friendly 1080p gaming card.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "RX 6600", "AMD Radeon RX 6600", 229.99m, 15, 132 },

                    // RAM (CategoryId = 3)
                    { 5, 3, "32GB (2x16GB) DDR4-3200 memory kit with dynamic RGB lighting. Optimized for Intel and AMD platforms.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMW32GX4M2E3200C16", "Corsair Vengeance RGB Pro DDR4-3200 32GB", 129.99m, 45, 10 },
                    { 6, 3, "16GB (2x8GB) DDR4-3200 memory with low-profile design. Great for compact builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMK16GX4M2B3200C16", "Corsair Vengeance LPX DDR4-3200 16GB", 59.99m, 67, 8 },
                    { 21, 3, "High-speed DDR5 memory for latest Intel and AMD platforms.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMK32GX5M2B5600C36", "Corsair Vengeance DDR5-5600 32GB", 199.99m, 25, 12 },
                    { 22, 3, "16GB DDR5 kit for modern systems.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CMK16GX5M2B5600C36", "Corsair Vengeance DDR5-5600 16GB", 119.99m, 40, 10 },

                    // Storage (CategoryId = 4)
                    { 7, 4, "2TB NVMe M.2 SSD with read speeds up to 7,000 MB/s. Perfect for gaming and professional workloads.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "MZ-V8P2T0B/AM", "Samsung 980 PRO 2TB NVMe", 199.99m, 33, 7 },
                    { 8, 4, "1TB NVMe SSD designed for gaming with speeds up to 7,300 MB/s and optimized for DirectStorage.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 2, "WDS100T2X0E", "WD Black SN850X 1TB NVMe", 89.99m, 28, 6 },
                    { 23, 4, "500GB budget NVMe SSD for essential storage.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 1, "MZ-V7S500BW", "Samsung 970 EVO Plus 500GB", 49.99m, 50, 5 },

                    // PSU (CategoryId = 5)
                    { 9, 5, "850W 80+ Gold fully modular power supply with Zero RPM fan mode for silent operation.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020200-NA", "Corsair RM850x 850W Gold", 139.99m, 19, 0 },
                    { 10, 5, "650W 80+ Bronze power supply offering reliable performance for mainstream gaming builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020236-NA", "Corsair CV650 650W Bronze", 69.99m, 41, 0 },
                    { 24, 5, "750W 80+ Gold modular PSU for high-end systems.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020195-NA", "Corsair RM750x 750W Gold", 119.99m, 25, 0 },
                    { 25, 5, "550W 80+ Bronze PSU for budget builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "CP-9020171-NA", "Corsair CV550 550W Bronze", 59.99m, 30, 0 },

                    // Motherboards (CategoryId = 6) - Already seeded as IDs 11-12
                    { 26, 6, "Intel Z790 motherboard with DDR5 and PCIe 5.0 support.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 5, "Z790-A", "ASUS Prime Z790-A (Intel DDR5)", 229.99m, 15, 18 },
                    { 27, 6, "AMD B650 motherboard with DDR5 support for Ryzen 7000 series.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 5, "B650-PLUS", "ASUS Prime B650-PLUS (AMD DDR5)", 179.99m, 20, 16 },

                    // Cooling (CategoryId = 7) - Already seeded as IDs 13-14
                    { 28, 7, "Budget air cooler for moderate CPU cooling needs.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 6, "NH-U12S", "Noctua NH-U12S Air Cooler", 69.99m, 35, 0 },
                    { 29, 7, "360mm AIO liquid cooler for high-end CPUs.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "H150i", "Corsair H150i RGB 360mm AIO", 199.99m, 12, 8 },

                    // Cases (CategoryId = 8) - Already seeded as IDs 15-16
                    { 30, 8, "Compact mid-tower with excellent airflow.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 7, "Core 1000", "Fractal Design Core 1000", 79.99m, 25, 0 },
                    { 31, 8, "Full-tower case for high-end builds.", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, true, 4, "7000D", "Corsair 7000D Airflow Full-Tower", 249.99m, 8, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 });
        }
    }
}