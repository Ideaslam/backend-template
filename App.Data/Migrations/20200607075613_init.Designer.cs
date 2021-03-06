﻿// <auto-generated />
using System;
using Edura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Edura.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200607075613_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Edura.Domain.Entity.Common.AppResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CustomFieldEightKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldEightValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldFiveKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldFiveValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldFourKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldFourValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldNineKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldNineValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldOneKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldOneValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldSevenKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldSevenValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldSixKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldSixValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldTenKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldTenValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldThreeKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldThreeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldTwoKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFieldTwoValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifyUserId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedTo")
                        .HasColumnType("int");

                    b.Property<int>("RowStatus")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("AppResources");
                });

            modelBuilder.Entity("Edura.Domain.Entity.Common.DetailCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldFourValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOneValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldThreeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldTwoValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasterCodeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderedIndex")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("RowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("MasterCodeId");

                    b.HasIndex("ParentId");

                    b.ToTable("DetailCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9137),
                            Code = "eg",
                            FieldOneValue = "+20",
                            MasterCodeId = 1,
                            ModifyUserId = 0,
                            Name = "Egypt",
                            NameAr = "مصر",
                            OrderedIndex = 1,
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 2,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9637),
                            Code = "cai",
                            MasterCodeId = 2,
                            ModifyUserId = 0,
                            Name = "Cairo",
                            NameAr = "القاهرة",
                            OrderedIndex = 1,
                            ParentId = 1,
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 3,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(9709),
                            Code = "11765",
                            MasterCodeId = 3,
                            ModifyUserId = 0,
                            Name = "Nasr City",
                            NameAr = "مدينة نصر",
                            OrderedIndex = 1,
                            ParentId = 2,
                            RowStatus = 1
                        });
                });

            modelBuilder.Entity("Edura.Domain.Entity.Common.MasterCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FieldFourIsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("FieldFourTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldFourTitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FieldOneIsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("FieldOneTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOneTitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FieldThreeIsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("FieldThreeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldThreeTitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FieldTwoIsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("FieldTwoTitelAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldTwoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("RowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("MasterCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(3189),
                            Code = "1001",
                            FieldFourIsVisible = false,
                            FieldOneIsVisible = true,
                            FieldOneTitle = "Country Code",
                            FieldOneTitleAr = "كود الدولة",
                            FieldThreeIsVisible = false,
                            FieldTwoIsVisible = false,
                            ModifyUserId = 0,
                            Name = "Country",
                            NameAr = "دولة",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 2,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(4537),
                            Code = "1002",
                            FieldFourIsVisible = false,
                            FieldOneIsVisible = false,
                            FieldThreeIsVisible = false,
                            FieldTwoIsVisible = false,
                            ModifyUserId = 0,
                            Name = "City",
                            NameAr = "مدينة",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 3,
                            AddUserId = 1,
                            AddedDate = new DateTime(2020, 6, 7, 10, 56, 13, 56, DateTimeKind.Local).AddTicks(4563),
                            Code = "1003",
                            FieldFourIsVisible = false,
                            FieldOneIsVisible = false,
                            FieldThreeIsVisible = false,
                            FieldTwoIsVisible = false,
                            ModifyUserId = 0,
                            Name = " Area",
                            NameAr = "منطقة",
                            RowStatus = 1
                        });
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GrantLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("ParentRoleId")
                        .HasColumnType("int");

                    b.Property<int>("RowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "",
                            GrantLevel = 1,
                            Name = "fullaccess",
                            NameAr = "التحكم الكامل",
                            NormalizedName = "fullaccess",
                            RowStatus = 1
                        });
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("AuthProviderAccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthProviderType")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("PreferredLanguageId")
                        .HasColumnType("int");

                    b.Property<bool>("ReceiveEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("ReceiveNotification")
                        .HasColumnType("bit");

                    b.Property<bool>("ReceiveSms")
                        .HasColumnType("bit");

                    b.Property<int>("RowStatus")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d9a66f84-d36f-41c3-8db5-67debfad76da",
                            Email = "admin@edura.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@edura.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEF5I5gEOoivSa7NTT+yngT+JfYv02TdOKi6PjSb9bicG9+ZFjy8MczkbksulqmCT6g==",
                            PhoneNumberConfirmed = false,
                            PreferredLanguageId = 0,
                            ReceiveEmail = true,
                            ReceiveNotification = true,
                            ReceiveSms = true,
                            RowStatus = 1,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            UserType = 5
                        });
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Edura.Domain.Entity.Common.AppResource", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "Area")
                        .WithMany("AreaAppResources")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "City")
                        .WithMany("CityAppResources")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "Country")
                        .WithMany("CountryAppResources")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Edura.Domain.Entity.Common.DetailCode", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "Area")
                        .WithMany("AreaDetailCodes")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "City")
                        .WithMany("CityDetailCodes")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "Country")
                        .WithMany("CountryDetailCodes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Edura.Domain.Entity.Common.MasterCode", "MasterCode")
                        .WithMany("DetailCodes")
                        .HasForeignKey("MasterCodeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Edura.Domain.Entity.Common.DetailCode", "ParentDetailCode")
                        .WithMany("ChildDetailCodes")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Edura.Domain.Entity.Common.MasterCode", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Common.MasterCode", "ParentMasterCode")
                        .WithMany("ChildMasterCodes")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserClaim", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserLogin", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserRole", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Edura.Domain.Entity.Identity.ApplicationUserToken", b =>
                {
                    b.HasOne("Edura.Domain.Entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
