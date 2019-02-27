﻿// <auto-generated />
using System;
using GroupBuilderPersistence.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupBuilderPersistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190227075729_Passwords")]
    partial class Passwords
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupBuilderDomain.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GroupBuilderDomain.GroupMember", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("GroupId");

                    b.HasKey("UserId", "GroupId");

                    b.HasAlternateKey("GroupId", "UserId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("GroupBuilderDomain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("RoomCode");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("GroupBuilderDomain.RoomParticipant", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoomId");

                    b.HasKey("UserId", "RoomId");

                    b.HasAlternateKey("RoomId", "UserId");

                    b.ToTable("RoomParticipants");
                });

            modelBuilder.Entity("GroupBuilderDomain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupBuilderDomain.Group", b =>
                {
                    b.HasOne("GroupBuilderDomain.Room", "Room")
                        .WithMany("Groups")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupBuilderDomain.GroupMember", b =>
                {
                    b.HasOne("GroupBuilderDomain.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupBuilderDomain.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupBuilderDomain.RoomParticipant", b =>
                {
                    b.HasOne("GroupBuilderDomain.Room", "Room")
                        .WithMany("Participants")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupBuilderDomain.User", "User")
                        .WithMany("Rooms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
