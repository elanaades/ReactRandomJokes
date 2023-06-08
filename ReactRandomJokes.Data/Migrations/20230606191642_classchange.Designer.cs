﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactRandomJokes.Data;

#nullable disable

namespace ReactRandomJokes.Data.Migrations
{
    [DbContext(typeof(JokeManagerDataContext))]
    [Migration("20230606191642_classchange")]
    partial class classchange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReactRandomJokes.Data.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("PunchLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetUp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("ReactRandomJokes.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReactRandomJokes.Data.UserLikedJokes", b =>
                {
                    b.Property<int>("JokeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("Liked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeLiked")
                        .HasColumnType("datetime2");

                    b.HasKey("JokeId", "UserId");

                    b.ToTable("UserLikedJokes");
                });

            modelBuilder.Entity("ReactRandomJokes.Data.Joke", b =>
                {
                    b.HasOne("ReactRandomJokes.Data.User", null)
                        .WithMany("Jokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ReactRandomJokes.Data.User", b =>
                {
                    b.Navigation("Jokes");
                });
#pragma warning restore 612, 618
        }
    }
}
