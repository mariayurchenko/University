﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myProject.Data;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContent))]
    partial class AppDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("myProject.Data.Models.Course", b =>
                {
                    b.Property<int>("COURSE_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPTION");

                    b.Property<string>("NAME");

                    b.HasKey("COURSE_ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("myProject.Data.Models.Group", b =>
                {
                    b.Property<int>("GROUP_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("COURSE_ID");

                    b.Property<string>("NAME");

                    b.HasKey("GROUP_ID");

                    b.HasIndex("COURSE_ID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("myProject.Data.Models.Student", b =>
                {
                    b.Property<int>("STUDENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FIRST_NAME");

                    b.Property<int>("GROUP_ID");

                    b.Property<string>("LAST_NAME");

                    b.HasKey("STUDENT_ID");

                    b.HasIndex("GROUP_ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("myProject.Data.Models.Group", b =>
                {
                    b.HasOne("myProject.Data.Models.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("COURSE_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myProject.Data.Models.Student", b =>
                {
                    b.HasOne("myProject.Data.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GROUP_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}