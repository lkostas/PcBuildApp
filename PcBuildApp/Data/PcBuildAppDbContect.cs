using PcBuildApp.Enums;
using Microsoft.EntityFrameworkCore;

namespace PcBuildApp.Data
{
    public class PcBuildAppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentSpecs> ComponentSpecs { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<BuildComponent> BuildComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.UserRole).HasConversion<string>();
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();
                entity.HasIndex(e => e.UserName, "IX_Users_UserName").IsUnique();
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturers");
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.HasIndex(e => e.Name, "IX_Manufacturers_Name").IsUnique();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(e => e.ComponentType).HasConversion<string>();
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.HasIndex(e => e.Name, "IX_Categories_Name").IsUnique();
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Components");
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.Price).HasPrecision(10, 2);
                entity.HasIndex(e => e.Name, "IX_Components_Name");
                entity.HasIndex(e => e.ManufacturerId, "IX_Components_ManufacturerId");
                entity.HasIndex(e => e.CategoryId, "IX_Components_CategoryId");
            });

            modelBuilder.Entity<ComponentSpecs>(entity =>
            {
                entity.ToTable("ComponentSpecs");
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.BaseClock).HasPrecision(5, 2);
                entity.Property(e => e.BoostClock).HasPrecision(5, 2);
                entity.Property(e => e.CoreClock).HasPrecision(8, 2);
                entity.Property(e => e.MemoryBandwidth).HasPrecision(8, 2);
                entity.HasIndex(e => e.ComponentId, "IX_ComponentSpecs_ComponentId").IsUnique();
            });

            modelBuilder.Entity<Build>(entity =>
            {
                entity.ToTable("Builds");
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.TotalPrice).HasPrecision(10, 2);
                entity.HasIndex(e => e.Name, "IX_Builds_Name");
                entity.HasIndex(e => e.UserId, "IX_Builds_UserId");
            });

            modelBuilder.Entity<BuildComponent>(entity =>
            {
                entity.ToTable("BuildComponents");
                entity.Property(e => e.InsertedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.ModifiedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("NOW()");
                entity.Property(e => e.PriceAtTime).HasPrecision(10, 2);
                entity.HasIndex(e => e.BuildId, "IX_BuildComponents_BuildId");
                entity.HasIndex(e => e.ComponentId, "IX_BuildComponents_ComponentId");
            });

            // Add this in your OnModelCreating method after the Categories seed data
// Add this after your existing component seed data
modelBuilder.Entity<Category>().HasData(
    new Category { Id = 1, Name = "Processors", ComponentType = ComponentType.CPU, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 2, Name = "Graphics Cards", ComponentType = ComponentType.GPU, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 3, Name = "Memory", ComponentType = ComponentType.RAM, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 4, Name = "Storage", ComponentType = ComponentType.Storage, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 5, Name = "Power Supplies", ComponentType = ComponentType.PSU, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 6, Name = "Motherboards", ComponentType = ComponentType.Motherboard, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 7, Name = "Cooling", ComponentType = ComponentType.Cooling, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Category { Id = 8, Name = "Cases", ComponentType = ComponentType.Case, IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
);

modelBuilder.Entity<Manufacturer>().HasData(
    new Manufacturer { Id = 1, Name = "Intel", Description = "Leading CPU manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 2, Name = "AMD", Description = "CPU and GPU manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 3, Name = "NVIDIA", Description = "Leading GPU manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 4, Name = "Corsair", Description = "Memory and PSU manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 5, Name = "ASUS", Description = "Motherboard manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 6, Name = "Noctua", Description = "Cooling manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Manufacturer { Id = 7, Name = "Fractal Design", Description = "Case manufacturer", IsActive = true, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
);

// Add components for missing categories
modelBuilder.Entity<Component>().HasData(
    // Motherboards
    new Component { Id = 11, Name = "ASUS ROG STRIX B550-F", Model = "B550-F", Description = "AMD B550 motherboard with WiFi", Price = 189.99m, IsActive = true, IsInStock = true, StockQuantity = 15, ManufacturerId = 5, CategoryId = 6, TDP = 15, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Component { Id = 12, Name = "ASUS Prime Z690-A", Model = "Z690-A", Description = "Intel Z690 motherboard with DDR5 support", Price = 249.99m, IsActive = true, IsInStock = true, StockQuantity = 12, ManufacturerId = 5, CategoryId = 6, TDP = 20, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    
    // Cooling
    new Component { Id = 13, Name = "Noctua NH-D15", Model = "NH-D15", Description = "Premium air cooler for high-end CPUs", Price = 99.99m, IsActive = true, IsInStock = true, StockQuantity = 20, ManufacturerId = 6, CategoryId = 7, TDP = 0, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Component { Id = 14, Name = "Corsair H100i RGB", Model = "H100i", Description = "240mm liquid cooler with RGB", Price = 149.99m, IsActive = true, IsInStock = true, StockQuantity = 18, ManufacturerId = 4, CategoryId = 7, TDP = 5, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    
    // Cases
    new Component { Id = 15, Name = "Fractal Design Define 7", Model = "Define 7", Description = "Silent mid-tower case with excellent airflow", Price = 169.99m, IsActive = true, IsInStock = true, StockQuantity = 10, ManufacturerId = 7, CategoryId = 8, TDP = 0, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    new Component { Id = 16, Name = "Corsair 4000D Airflow", Model = "4000D", Description = "Mid-tower case optimized for airflow", Price = 94.99m, IsActive = true, IsInStock = true, StockQuantity = 25, ManufacturerId = 4, CategoryId = 8, TDP = 0, InsertedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
);
        }
    }
}