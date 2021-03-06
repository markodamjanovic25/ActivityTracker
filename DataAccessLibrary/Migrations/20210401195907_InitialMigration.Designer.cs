// <auto-generated />
using System;
using DataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLibrary.Migrations
{
    [DbContext(typeof(ActivityTrackerDbContext))]
    [Migration("20210401195907_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLibrary.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "just excercised!",
                            Flag = "/img/ExcerciseFlag.svg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "just meditated!",
                            Flag = "/img/MeditationFlag.svg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "just drank a glass of water!",
                            Flag = "/img/WaterFlag.svg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "just read a chapter of a book!",
                            Flag = "/img/BookFlag.svg"
                        });
                });

            modelBuilder.Entity("DataAccessLibrary.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataAccessLibrary.Models.Task", b =>
                {
                    b.HasOne("DataAccessLibrary.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
