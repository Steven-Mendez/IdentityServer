﻿// <auto-generated />
using System;
using IdentityServer.Infrastructure.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdentityServer.Infrastructure.Migrations
{
    [DbContext(typeof(IdentityServerContext))]
    [Migration("20240622234100_MicrosoftIdPropertyToUser")]
    partial class MicrosoftIdPropertyToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdentityServer.Domain.Users.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("MicrosoftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("IsDeleted")
                        .HasFilter("IsDeleted = 0");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"),
                            Avatar = "https://randomuser.me/api/portraits/men/1.jpg",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = new Guid("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"),
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "Admin",
                            Password = "3qgXD8CJJvw+H4DkENHDqQ==;zbm8kyh0QCLHoKBgut6mtT8jqCIRcv9vNEKTnbtTGaE=",
                            UserName = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
