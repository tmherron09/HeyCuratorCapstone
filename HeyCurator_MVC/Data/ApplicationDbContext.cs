﻿using HeyCurator_MVC.AnonymousQuestionBoard;
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
                });

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
                });

            //var hasher = new PasswordHasher<IdentityUser>();

            //builder.Entity<IdentityUser>()
            //    .HasData(
            //    new IdentityUser
            //    {
            //        UserName = "Admin",
            //        PasswordHash = hasher.HashPassword(null, "Admin123!"),
            //        Email = "Admin@admin.com"
            //    });

            builder.Entity<Storage>()
                .HasData(
                new Storage
                {
                    StorageId = 1,
                    Name = "Not Declared",
                    StorageType = "Not Declared",
                    AccessLevel = AccessLevel.Other
                });


            builder.Entity<EmployeeRoles>()
                .HasKey(er => new { er.EmployeeId , er.CuratorRoleId});
            builder.Entity<EmployeeRoles>()
                .HasOne(er => er.Employee)
                .WithMany(emp => emp.EmployeeRoles)
                .HasForeignKey(er => er.EmployeeId);
            builder.Entity<EmployeeRoles>()
                .HasOne(er => er.CuratorRole)
                .WithMany(cr => cr.EmployeeRoles)
                .HasForeignKey(er => er.CuratorRoleId);

            builder.Entity<CuratorSpace>()
                .HasKey(cs => new { cs.CuratorRoleId, cs.ExhibitSpaceId });
            builder.Entity<CuratorSpace>()
                .HasOne(cs => cs.CuratorRole)
                .WithMany(cr => cr.CuratorSpaces)
                .HasForeignKey(cs => cs.CuratorRoleId);
            builder.Entity<CuratorSpace>()
                .HasOne(cs => cs.ExhibitSpace)
                .WithMany(es => es.CuratorSpaces)
                .HasForeignKey(cs => cs.ExhibitSpaceId);


            builder.Entity<StorageItemInstance>()
                .HasKey(sii => new { sii.StorageId, sii.ItemInstanceId });
            builder.Entity<StorageItemInstance>()
                .HasOne(sii => sii.Storage)
                .WithMany(s => s.StorageItemInstances)
                .HasForeignKey(sii => sii.StorageId);
            builder.Entity<StorageItemInstance>()
                .HasOne(sii => sii.ItemInstance)
                .WithMany(ii => ii.StorageItemInstances)
                .HasForeignKey(sii => sii.ItemInstanceId);

            builder.Entity<ExhibitItemInstance>()
                .HasKey(eii => new { eii.ExhibitId, eii.ItemInstanceId });
            builder.Entity<ExhibitItemInstance>()
                .HasOne(eii => eii.Exhibit)
                .WithMany(s => s.ExhibitItemInstances)
                .HasForeignKey(eii => eii.ExhibitId);
            builder.Entity<ExhibitItemInstance>()
                .HasOne(eii => eii.ItemInstance)
                .WithMany(ii => ii.ExhibitItemInstances)
                .HasForeignKey(eii => eii.ItemInstanceId);

            builder.Entity<Record>()
                .HasOne<InventoryControlModel>(r => r.InventoryControlModel)
                .WithMany(icm => icm.Records)
                .HasForeignKey(r => r.InventoryControlModelID)
                .OnDelete(DeleteBehavior.Restrict);


        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<CuratorRole> CuratorRoles { get; set; }
        public DbSet<CuratorSpace> CuratorSpaces { get; set; }
        public DbSet<ExhibitSpace> ExhibitSpaces { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<ExhibitItemInstance> ExhibitItemInstances { get; set; }
       
        public DbSet<ItemInstance> ItemInstances { get; set; }
        public DbSet<InventoryControlModel> InventoryControlModels { get; set; }
        public DbSet<Item> Items { get; set; }



        public DbSet<StorageItemInstance> StorageItemInstances { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Record> Records { get; set; }




        public DbSet<ExpiredUpdateItem> ExpiredUpdateItems { get; set; }

        public DbSet<PurchaserNotification> PurchaserNotifications { get; set; }
        

        public DbSet<HeyCuratorMail> HeyCuratorMails { get; set; }
        public DbSet<LowCountItem> LowCountItems { get; set; }
        public DbSet<AnonymousQuestion> AnonymousQuestions { get; set; }
        public DbSet<AnonymousComment> AnonymousComments { get; set; }


        public DbSet<Order> Orders { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }


        // TODO: Depereciate the following.
        //public DbSet<ItemInStorage> ItemInStorages { get; set; }
        //public DbSet<ExhibitItemInStorage> ExhibitItemInStorages { get; set; }

    }
}
