﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HomeBuh.Data;

namespace HomeBuh.Data.MigrationsBuh
{
    [DbContext(typeof(BuhContext))]
    [Migration("20170318181807_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeBuh.Models.BuhAccount", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("BuhAccounts");
                });

            modelBuilder.Entity("HomeBuh.Models.Entry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuhAccountID");

                    b.Property<DateTime>("DateOperation");

                    b.Property<string>("Description");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("BuhAccountID");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("HomeBuh.Models.Entry", b =>
                {
                    b.HasOne("HomeBuh.Models.BuhAccount")
                        .WithMany("Entries")
                        .HasForeignKey("BuhAccountID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
