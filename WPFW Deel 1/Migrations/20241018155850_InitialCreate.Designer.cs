﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFW_Deel_1.codes.ORM;

#nullable disable

namespace WPFW_Deel_1.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20241018155850_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("studentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("studentId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.GradeStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("gradeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("studentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("GradeStudent");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Student", b =>
                {
                    b.HasBaseType("WPFW_Deel_1.codes.ORM.User");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Teacher", b =>
                {
                    b.HasBaseType("WPFW_Deel_1.codes.ORM.User");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("teachingCourse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("StudentId");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Grade", b =>
                {
                    b.HasOne("WPFW_Deel_1.codes.ORM.Student", "student")
                        .WithMany("grades")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Teacher", b =>
                {
                    b.HasOne("WPFW_Deel_1.codes.ORM.Student", null)
                        .WithMany("teachers")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("WPFW_Deel_1.codes.ORM.Student", b =>
                {
                    b.Navigation("grades");

                    b.Navigation("teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
