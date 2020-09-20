using System;
using System.Collections.Generic;
using System.Text;
using HeyCurator_basm_Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_basm_Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curator> Curators { get; set; }
        public DbSet<CuratorAssignment> CuratorAssignments { get; set; }
        public DbSet<CuratorSpace> CuratorSpaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemInStorage> ItemInStorages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PurchaserNotification> PurchaserNotifications { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageCuratorSpace> StorageCuratorSpaces { get; set; }
        public DbSet<CuratorRole> CuratorRoles { get; set; }
        public DbSet<ExhibitSpace> ExhibitSpaces { get; set; }
        public DbSet<ExhibitItemInStorage> ExhibitItemInStorages { get; set; }


    }
}
