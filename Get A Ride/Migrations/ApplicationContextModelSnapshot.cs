﻿// <auto-generated />
using System;
using GetARide.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GetARide.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("GetARide.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("GetARide.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("GetARide.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("License")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .HasColumnType("text");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Documents")
                        .HasColumnType("text");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("GetARide.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("GetARide.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Bookingid")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ispayed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<byte[]>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("Bookingid")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("GetARide.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("DropLocation")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("PickUpLocation")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("GetARide.Entities.Admin", b =>
                {
                    b.HasOne("GetARide.Entities.Identity.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("GetARide.Entities.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GetARide.Entities.Booking", b =>
                {
                    b.HasOne("GetARide.Entities.Driver", "Driver")
                        .WithMany("Bookings")
                        .HasForeignKey("DriverId");

                    b.HasOne("GetARide.Entities.Passenger", "Passenger")
                        .WithMany("Bookings")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("GetARide.Entities.Driver", b =>
                {
                    b.HasOne("GetARide.Entities.Identity.User", "User")
                        .WithOne("Driver")
                        .HasForeignKey("GetARide.Entities.Driver", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.UserRoles", b =>
                {
                    b.HasOne("GetARide.Entities.Identity.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetARide.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.Vehicle", b =>
                {
                    b.HasOne("GetARide.Entities.Driver", "Driver")
                        .WithMany("Vehicles")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("GetARide.Entities.Passenger", b =>
                {
                    b.HasOne("GetARide.Entities.Identity.User", "User")
                        .WithOne("Passenger")
                        .HasForeignKey("GetARide.Entities.Passenger", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GetARide.Entities.Payment", b =>
                {
                    b.HasOne("GetARide.Entities.Booking", "Booking")
                        .WithOne("Payment")
                        .HasForeignKey("GetARide.Entities.Payment", "Bookingid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("GetARide.Entities.Trip", b =>
                {
                    b.HasOne("GetARide.Entities.Booking", "Booking")
                        .WithOne("Trip")
                        .HasForeignKey("GetARide.Entities.Trip", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("GetARide.Entities.Booking", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("GetARide.Entities.Driver", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("GetARide.Entities.Identity.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Driver");

                    b.Navigation("Passenger");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("GetARide.Entities.Passenger", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
