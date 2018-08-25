﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using wall.Models;

namespace wall.Migrations
{
    [DbContext(typeof(WallContext))]
    [Migration("20180619231549_wall1")]
    partial class wall1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("wall.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MessageId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<string>("createcomment");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("wall.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<string>("createmessage");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("wall.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("confirmpass")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("wall.Models.Comment", b =>
                {
                    b.HasOne("wall.Models.Message", "message")
                        .WithMany("comments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wall.Models.User", "user")
                        .WithMany("comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("wall.Models.Message", b =>
                {
                    b.HasOne("wall.Models.User", "user")
                        .WithMany("messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
