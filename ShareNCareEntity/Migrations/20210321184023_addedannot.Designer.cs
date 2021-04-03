﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareNCareEntity.DataContext;

namespace ShareNCareEntity.Migrations
{
    [DbContext(typeof(TheContext))]
    [Migration("20210321184023_addedannot")]
    partial class addedannot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FriendUser", b =>
                {
                    b.Property<int>("FriendsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("FriendsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("FriendUser");
                });

            modelBuilder.Entity("ShareAndCare.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ShareAndCare.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FriendId")
                        .HasMaxLength(128)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ShareAndCare.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Msg")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ShareAndCare.Models.Password", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("ShareAndCare.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FriendUser", b =>
                {
                    b.HasOne("ShareAndCare.Models.Friend", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShareAndCare.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShareAndCare.Models.File", b =>
                {
                    b.HasOne("ShareAndCare.Models.User", null)
                        .WithMany("Files")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShareAndCare.Models.Message", b =>
                {
                    b.HasOne("ShareAndCare.Models.User", null)
                        .WithMany("Msg")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShareAndCare.Models.Password", b =>
                {
                    b.HasOne("ShareAndCare.Models.User", "User")
                        .WithOne("Password")
                        .HasForeignKey("ShareAndCare.Models.Password", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShareAndCare.Models.User", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Msg");

                    b.Navigation("Password");
                });
#pragma warning restore 612, 618
        }
    }
}