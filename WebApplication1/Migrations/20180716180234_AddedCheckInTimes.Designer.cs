﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(BarCodeDbContext))]
    [Migration("20180716180234_AddedCheckInTimes")]
    partial class AddedCheckInTimes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.BarcodeUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Barcode");

                    b.Property<bool>("CheckedIn");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("BarcodeUsers");
                });

            modelBuilder.Entity("WebApplication1.Models.CheckInTimes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Barcode");

                    b.Property<int?>("BarcodeUserID");

                    b.Property<DateTime>("CheckInTime");

                    b.HasKey("ID");

                    b.HasIndex("BarcodeUserID");

                    b.ToTable("CheckInTimes");
                });

            modelBuilder.Entity("WebApplication1.Models.CheckInTimes", b =>
                {
                    b.HasOne("WebApplication1.Models.BarcodeUser")
                        .WithMany("CheckedInTimes")
                        .HasForeignKey("BarcodeUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
