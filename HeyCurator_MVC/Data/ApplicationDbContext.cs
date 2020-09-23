using HeyCurator_MVC.Controllers;
using HeyCurator_MVC.MessageService;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Curator",
                    NormalizedName = "CURATOR"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
                );

            builder.Entity<CuratorRole>()
                .HasData(
                new CuratorRole
                {
                    NameOfRole = "Admin",
                    CuratorRoleId = 1
                },
                new CuratorRole
                {
                    NameOfRole = "Employee",
                    CuratorRoleId = 2
                }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>()
                .HasData(
                new IdentityUser
                {
                    UserName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "ADMIN123!"),
                    Email = "Admin@admin.com"
                }
                );
            
        }
        public DbSet<CuratorSpace> CuratorSpaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ExpiredUpdateItem> ExpiredUpdateItems { get; set; }
        public DbSet<ItemInStorage> ItemInStorages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PurchaserNotification> PurchaserNotifications { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageCuratorSpace> StorageCuratorSpaces { get; set; }
        public DbSet<CuratorRole> CuratorRoles { get; set; }
        public DbSet<ExhibitSpace> ExhibitSpaces { get; set; }
        public DbSet<ExhibitItemInStorage> ExhibitItemInStorages { get; set; }
        public DbSet<HeyCuratorMail> HeyCuratorMails { get; set; }



    }
}
