﻿// <auto-generated />
using LabbTwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabbTwo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabbTwo.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LabbTwo.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LabbTwo.Models.SchoolClass", b =>
                {
                    b.Property<int>("SchoolClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolClassId"));

                    b.Property<string>("SchoolClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SchoolClassId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("LabbTwo.Models.SchoolConnection", b =>
                {
                    b.Property<int>("SchoolConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolConnectionId"));

                    b.Property<int>("FK_CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FK_EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FK_SchoolClassId")
                        .HasColumnType("int");

                    b.Property<int>("FK_StudentId")
                        .HasColumnType("int");

                    b.HasKey("SchoolConnectionId");

                    b.HasIndex("FK_CourseId");

                    b.HasIndex("FK_EmployeeId");

                    b.HasIndex("FK_SchoolClassId");

                    b.HasIndex("FK_StudentId");

                    b.ToTable("SchoolConnections");
                });

            modelBuilder.Entity("LabbTwo.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LabbTwo.Models.SchoolConnection", b =>
                {
                    b.HasOne("LabbTwo.Models.Course", "Courses")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabbTwo.Models.Employee", "Employees")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabbTwo.Models.SchoolClass", "SchoolClasses")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabbTwo.Models.Student", "Students")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Employees");

                    b.Navigation("SchoolClasses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("LabbTwo.Models.Course", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("LabbTwo.Models.Employee", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("LabbTwo.Models.SchoolClass", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("LabbTwo.Models.Student", b =>
                {
                    b.Navigation("SchoolConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
