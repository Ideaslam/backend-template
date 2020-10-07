using Edura.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Edura.Domain.Entity.Common;
using Edura.Enums;
using Microsoft.AspNetCore.Identity;

namespace Edura.Data
{
    public static class DbContextHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("EduraConnection"))).Options;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext() : base(DbContextHelper.GetDbContextOptions())
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // delete behavior
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region identity
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationRole>(entity => 
            {
                entity.ToTable(name: "Roles");
                entity.HasData(new ApplicationRole
                {
                    Id = 1,
                    Name = "fullaccess",
                    NormalizedName = "fullaccess",
                    NameAr = "التحكم الكامل",
                    ConcurrencyStamp = String.Empty,
                    GrantLevel = 1,
                    RowStatus = ResourceStatus.Active
                });
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.HasData(
                    new ApplicationUser
                    {
                        Id = 1,
                        UserName = "admin",
                        NormalizedUserName = "admin",
                        Email = "admin@edura.com",
                        NormalizedEmail = "admin@edura.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "123456"),
                        SecurityStamp = string.Empty,
                        RowStatus = ResourceStatus.Active,
                        UserType = ApplicationUserType.Edura
                        
                    });
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasData(new ApplicationUserRole
                {
                    RoleId = 1,
                    UserId = 1
                });
            });
            modelBuilder.Entity<ApplicationUserClaim>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<ApplicationUserLogin>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<ApplicationUserToken>(entity => { entity.ToTable("UserTokens"); });
            modelBuilder.Entity<ApplicationRoleClaim>(entity => { entity.ToTable("RoleClaims"); });
            #endregion

            #region common
            modelBuilder.Entity<MasterCode>().HasData(
                new MasterCode { Id = 1, Code = "1001", Name = "Country", NameAr = "دولة", FieldOneTitle="Country Code",FieldOneTitleAr = "كود الدولة",FieldOneIsVisible=true, AddedDate = DateTime.Now, RowStatus = ResourceStatus.Active, AddUserId = 1 },
                new MasterCode { Id = 2, Code = "1002", Name = "City", NameAr = "مدينة", AddedDate = DateTime.Now, RowStatus = ResourceStatus.Active, AddUserId = 1 },
                new MasterCode { Id = 3, Code = "1003", Name = " Area", NameAr = "منطقة", AddedDate = DateTime.Now, RowStatus = ResourceStatus.Active, AddUserId = 1 }
                );
            modelBuilder.Entity<DetailCode>().HasData(
            new DetailCode {Id=1, Code="eg",Name="Egypt",NameAr = "مصر", MasterCodeId=1,FieldOneValue="+20",OrderedIndex=1, AddedDate = DateTime.Now,RowStatus = ResourceStatus.Active,AddUserId = 1 },
            new DetailCode {Id=2, Code="cai",Name="Cairo",NameAr = "القاهرة", MasterCodeId=2, ParentId = 1,OrderedIndex=1, AddedDate = DateTime.Now,RowStatus = ResourceStatus.Active,AddUserId = 1 },
            new DetailCode {Id=3, Code= "11765", Name="Nasr City",NameAr = "مدينة نصر", MasterCodeId=3, ParentId = 2, OrderedIndex=1, AddedDate = DateTime.Now,RowStatus = ResourceStatus.Active,AddUserId = 1 }
            );
            #endregion

           

        }

        #region common
        public DbSet<MasterCode> MasterCodes { get; set; }
        public DbSet<DetailCode> DetailCodes { get; set; }
        #endregion
    }
}
