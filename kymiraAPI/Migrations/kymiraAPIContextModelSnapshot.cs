﻿// <auto-generated />
using kymiraAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace kymiraAPI.Migrations
{
    [DbContext(typeof(kymiraAPIContext))]
    partial class kymiraAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kymiraAPI.Models.Credentials", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phoneNumber")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("kymiraAPI.Models.Resident", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("password");

                    b.Property<string>("phoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Resident");
                });
#pragma warning restore 612, 618
        }
    }
}
