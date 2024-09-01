using AtulaDotNetTest.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtulaDotNetTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define many-to-many relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("ProductCategories"));

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Table" },
                new Category { Id = 2, Name = "Chair" },
                new Category { Id = 3, Name = "Sofa" }
            );

            // Seed Product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Sku = "SKUA", Name = "Lorem Table" },
                new Product { Id = 2, Sku = "SKUB", Name = "Ipsum Table" },
                new Product { Id = 3, Sku = "SKUC", Name = "Dolor Table" },
                new Product { Id = 4, Sku = "SKUD", Name = "Sit Chair" },
                new Product { Id = 5, Sku = "SKUE", Name = "Amet Chair" },
                new Product { Id = 6, Sku = "SKUF", Name = "Consectetur Chair" },
                new Product { Id = 7, Sku = "SKUG", Name = "Adipiscing Sofa" },
                new Product { Id = 8, Sku = "SKUH", Name = "Elit Sofa" },
                new Product { Id = 9, Sku = "SKUI", Name = "Mauris Sofa" }
            );

            // Seed Product-Category relationships
            modelBuilder.Entity<Product>().HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.HasData(
                    new { ProductsId = 1, CategoriesId = 1 },
                    new { ProductsId = 2, CategoriesId = 1 },
                    new { ProductsId = 3, CategoriesId = 1 },
                    new { ProductsId = 4, CategoriesId = 2 },
                    new { ProductsId = 5, CategoriesId = 2 },
                    new { ProductsId = 6, CategoriesId = 2 },
                    new { ProductsId = 7, CategoriesId = 3 },
                    new { ProductsId = 8, CategoriesId = 3 },
                    new { ProductsId = 9, CategoriesId = 3 }
                ));

            // Seed Admin User
            var adminUserId = "admin-user-id";
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = adminUserId,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            // Seed Admin Role if it does not exist
            var adminRoleId = "admin-role-id";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            // Link Admin Role to Admin User if not already linked
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                });
        }
    }
}
