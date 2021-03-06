﻿// <auto-generated />
using System;
using ChatServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190130184427_changed_table")]
    partial class changed_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatCore.Models.Group", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ChatCore.Models.Media", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("ChatCore.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsRead");

                    b.Property<string>("SenderId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId")
                        .IsUnique()
                        .HasFilter("[SenderId] IS NOT NULL");

                    b.ToTable("Messages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Message");
                });

            modelBuilder.Entity("ChatCore.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MainPhotoId");

                    b.Property<string>("PasswordHash");

                    b.Property<DateTime?>("RegistrationDate");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("MainPhotoId")
                        .IsUnique()
                        .HasFilter("[MainPhotoId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatCore.Models.UserGroup", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("GroupId");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsOwner");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("ChatCore.Models.GroupMessage", b =>
                {
                    b.HasBaseType("ChatCore.Models.Message");

                    b.Property<string>("GroupId");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("GroupMessage");
                });

            modelBuilder.Entity("ChatCore.Models.Message", b =>
                {
                    b.HasOne("ChatCore.Models.User", "Sender")
                        .WithOne()
                        .HasForeignKey("ChatCore.Models.Message", "SenderId");
                });

            modelBuilder.Entity("ChatCore.Models.User", b =>
                {
                    b.HasOne("ChatCore.Models.Media", "MainPhoto")
                        .WithOne()
                        .HasForeignKey("ChatCore.Models.User", "MainPhotoId");
                });

            modelBuilder.Entity("ChatCore.Models.UserGroup", b =>
                {
                    b.HasOne("ChatCore.Models.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChatCore.Models.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChatCore.Models.GroupMessage", b =>
                {
                    b.HasOne("ChatCore.Models.Group", "Group")
                        .WithMany("Messages")
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
