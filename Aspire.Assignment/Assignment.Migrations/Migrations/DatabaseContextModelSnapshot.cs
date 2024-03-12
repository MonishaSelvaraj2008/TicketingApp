﻿// <auto-generated />
using System;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.BugHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("BugId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Environment")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FixedID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NotFixedReason")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Regression")
                        .HasColumnType("bit");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BugId");

                    b.ToTable("BugHistory");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.CustomerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerName")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.CustomerSupport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Responsible");

                    b.HasIndex("StatusId");

                    b.ToTable("CustomerSupport");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.CustomerSupportHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerSupportId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerSupportId");

                    b.ToTable("CustomerSupportHistory");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mobile")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.UserStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcceptanceCriteria")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("StoryPoint")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Responsible");

                    b.HasIndex("StatusId");

                    b.ToTable("UserStory");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.UserStoryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcceptanceCriteria")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("StoryPoint")
                        .HasColumnType("int");

                    b.Property<int>("UserStoryId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserStoryId");

                    b.ToTable("UserStoryHistory");
                });

            modelBuilder.Entity("Bug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Environment")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FixedID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NotFixedReason")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Regression")
                        .HasColumnType("bit");

                    b.Property<int>("Responsible")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Responsible");

                    b.HasIndex("StatusId");

                    b.ToTable("Bug");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.BugHistory", b =>
                {
                    b.HasOne("Bug", "Bug")
                        .WithMany()
                        .HasForeignKey("BugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bug");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.CustomerSupport", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Responsible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.CustomerSupportHistory", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.CustomerDetails", "CustomerDetails")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.CustomerSupport", "CustomerSupport")
                        .WithMany()
                        .HasForeignKey("CustomerSupportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerDetails");

                    b.Navigation("CustomerSupport");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.UserStory", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Responsible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.UserStoryHistory", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.UserStory", "UserStory")
                        .WithMany()
                        .HasForeignKey("UserStoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("Bug", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("Responsible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Contracts.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
