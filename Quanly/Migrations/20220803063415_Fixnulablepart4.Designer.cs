// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quanly.Data;

#nullable disable

namespace Quanly.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220803063415_Fixnulablepart4")]
    partial class Fixnulablepart4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Quanly.Models.AccumulatePoints.AccumulatePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccumulatePointsRulesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Importer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberCardsId")
                        .HasColumnType("int");

                    b.Property<int?>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Shop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccumulatePointsRulesId");

                    b.HasIndex("MemberCardsId");

                    b.ToTable("AccumulatePoints");
                });

            modelBuilder.Entity("Quanly.Models.AccumulatePointsRules.AccumulatePointsRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApplyFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ApplyTo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Formula")
                        .HasColumnType("int");

                    b.Property<string>("Guide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Importer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccumulatePointsRules");
                });

            modelBuilder.Entity("Quanly.Models.ContactPersons.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("Quanly.Models.Customers.Customer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyPhone")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Importer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMarried")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TelePhone")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "District 9, Ho Chi Minh City",
                            Age = 20,
                            BirthDate = new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(3972),
                            Code = "KH123456789",
                            CompanyName = "KNS",
                            CompanyPhone = 1234567891,
                            Contact = "An Ngo",
                            CustomerName = "Cong Chinh",
                            DateOfRecord = new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4081),
                            District = "District 9",
                            Email = "Chinhpro@gmail.com",
                            Fax = "+84 (8) 3823 3318",
                            Gender = "Male",
                            IdentityCard = "343456771234",
                            Importer = "Ad",
                            IsActive = true,
                            IsMarried = false,
                            IssueDate = new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4078),
                            Language = "Vietnamese",
                            Note = "",
                            Phone = 1234567891,
                            Position = "Head of KNS",
                            Province = "",
                            TelePhone = 1234567891,
                            Type = "Silver"
                        });
                });

            modelBuilder.Entity("Quanly.Models.MemberCards.MemberCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CardNumber")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EffectDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Importer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RegisterAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ValidDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("MemberCards");
                });

            modelBuilder.Entity("Quanly.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Quanly.Models.AccumulatePoints.AccumulatePoint", b =>
                {
                    b.HasOne("Quanly.Models.AccumulatePointsRules.AccumulatePointsRule", "AccumulatePointsRules")
                        .WithMany("AccumulatePoint")
                        .HasForeignKey("AccumulatePointsRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quanly.Models.MemberCards.MemberCard", "MemberCards")
                        .WithMany("AccumulatePoints")
                        .HasForeignKey("MemberCardsId");

                    b.Navigation("AccumulatePointsRules");

                    b.Navigation("MemberCards");
                });

            modelBuilder.Entity("Quanly.Models.ContactPersons.ContactPerson", b =>
                {
                    b.HasOne("Quanly.Models.Customers.Customer", null)
                        .WithOne("ContactPersons")
                        .HasForeignKey("Quanly.Models.ContactPersons.ContactPerson", "CustomerId");
                });

            modelBuilder.Entity("Quanly.Models.MemberCards.MemberCard", b =>
                {
                    b.HasOne("Quanly.Models.Customers.Customer", "Customer")
                        .WithMany("MemberCards")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Quanly.Models.AccumulatePointsRules.AccumulatePointsRule", b =>
                {
                    b.Navigation("AccumulatePoint");
                });

            modelBuilder.Entity("Quanly.Models.Customers.Customer", b =>
                {
                    b.Navigation("ContactPersons");

                    b.Navigation("MemberCards");
                });

            modelBuilder.Entity("Quanly.Models.MemberCards.MemberCard", b =>
                {
                    b.Navigation("AccumulatePoints");
                });
#pragma warning restore 612, 618
        }
    }
}
