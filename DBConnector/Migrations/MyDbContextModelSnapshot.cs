﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TcDbConnector;

#nullable disable

namespace TcDbConnector.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AuthorTechnologicalCard", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologicalCardsId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "TechnologicalCardsId");

                    b.HasIndex("TechnologicalCardsId");

                    b.ToTable("AuthorTechnologicalCard");
                });

            modelBuilder.Entity("AuthorTechnologicalProcess", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologicalProcessesId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "TechnologicalProcessesId");

                    b.HasIndex("TechnologicalProcessesId");

                    b.ToTable("AuthorTechnologicalProcess");
                });

            modelBuilder.Entity("TcModels.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Component_TC", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Component_TC", (string)null);
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Instrument_kit<TcModels.Models.TcContent.Component>", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Instrument_kit<Component>");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.LinkEntety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ComponentId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("MachineId")
                        .HasColumnType("int");

                    b.Property<int?>("ProtectionId")
                        .HasColumnType("int");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("MachineId");

                    b.HasIndex("ProtectionId");

                    b.HasIndex("ToolId");

                    b.ToTable("LinkEntety");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Machine_TC", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Machine_TC", (string)null);
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Protection_TC", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Protection_TC", (string)null);
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Staff_TC", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("-");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("ParentId", "ChildId", "Symbol");

                    b.HasIndex("ChildId");

                    b.ToTable("Staff_TC", (string)null);
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Tool_TC", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double")
                        .HasDefaultValue(0.0);

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Tool_TC", (string)null);
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClassifierCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.ExecutionWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("TechnologicalCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TechnologicalCardId");

                    b.ToTable("ExecutionWorks");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClassifierCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Protection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClassifierCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Protections");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CombineResponsibility")
                        .HasColumnType("longtext");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<string>("Functions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.TechOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ExecutionWorkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionWorkId");

                    b.ToTable("TechOperations");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClassifierCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("TcModels.Models.TechnologicalCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Applicability")
                        .HasColumnType("longtext");

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DamageType")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("FinalProduct")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NetworkVoltage")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("Parameter")
                        .HasColumnType("longtext");

                    b.Property<string>("RepairType")
                        .HasColumnType("longtext");

                    b.Property<string>("TechnologicalProcessName")
                        .HasColumnType("longtext");

                    b.Property<string>("TechnologicalProcessNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("TechnologicalProcessType")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TechnologicalCards");
                });

            modelBuilder.Entity("TcModels.Models.TechnologicalProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TechnologicalProcesses");
                });

            modelBuilder.Entity("TechnologicalCardTechnologicalProcess", b =>
                {
                    b.Property<int>("TechnologicalCardsId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologicalProcessId")
                        .HasColumnType("int");

                    b.HasKey("TechnologicalCardsId", "TechnologicalProcessId");

                    b.HasIndex("TechnologicalProcessId");

                    b.ToTable("TechnologicalCardTechnologicalProcess");
                });

            modelBuilder.Entity("AuthorTechnologicalCard", b =>
                {
                    b.HasOne("TcModels.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", null)
                        .WithMany()
                        .HasForeignKey("TechnologicalCardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthorTechnologicalProcess", b =>
                {
                    b.HasOne("TcModels.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalProcess", null)
                        .WithMany()
                        .HasForeignKey("TechnologicalProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Component_TC", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Component", "Child")
                        .WithMany("Component_TCs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", "Parent")
                        .WithMany("Component_TCs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Instrument_kit<TcModels.Models.TcContent.Component>", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Component", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TcContent.Component", "Parent")
                        .WithMany("Kit")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.LinkEntety", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Component", null)
                        .WithMany("Links")
                        .HasForeignKey("ComponentId");

                    b.HasOne("TcModels.Models.TcContent.Machine", null)
                        .WithMany("Links")
                        .HasForeignKey("MachineId");

                    b.HasOne("TcModels.Models.TcContent.Protection", null)
                        .WithMany("Links")
                        .HasForeignKey("ProtectionId");

                    b.HasOne("TcModels.Models.TcContent.Tool", null)
                        .WithMany("Links")
                        .HasForeignKey("ToolId");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Machine_TC", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Machine", "Child")
                        .WithMany("Machine_TCs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", "Parent")
                        .WithMany("Machine_TCs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Protection_TC", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Protection", "Child")
                        .WithMany("Protection_TCs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", "Parent")
                        .WithMany("Protection_TCs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Staff_TC", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Staff", "Child")
                        .WithMany("Staff_TCs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", "Parent")
                        .WithMany("Staff_TCs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.IntermediateTables.Tool_TC", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.Tool", "Child")
                        .WithMany("Tool_TCs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalCard", "Parent")
                        .WithMany("Tool_TCs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.ExecutionWork", b =>
                {
                    b.HasOne("TcModels.Models.TechnologicalCard", null)
                        .WithMany("ExecutionWorks")
                        .HasForeignKey("TechnologicalCardId");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.TechOperation", b =>
                {
                    b.HasOne("TcModels.Models.TcContent.ExecutionWork", null)
                        .WithMany("TechOperations")
                        .HasForeignKey("ExecutionWorkId");
                });

            modelBuilder.Entity("TechnologicalCardTechnologicalProcess", b =>
                {
                    b.HasOne("TcModels.Models.TechnologicalCard", null)
                        .WithMany()
                        .HasForeignKey("TechnologicalCardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TcModels.Models.TechnologicalProcess", null)
                        .WithMany()
                        .HasForeignKey("TechnologicalProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Component", b =>
                {
                    b.Navigation("Component_TCs");

                    b.Navigation("Kit");

                    b.Navigation("Links");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.ExecutionWork", b =>
                {
                    b.Navigation("TechOperations");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Machine", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Machine_TCs");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Protection", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Protection_TCs");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Staff", b =>
                {
                    b.Navigation("Staff_TCs");
                });

            modelBuilder.Entity("TcModels.Models.TcContent.Tool", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Tool_TCs");
                });

            modelBuilder.Entity("TcModels.Models.TechnologicalCard", b =>
                {
                    b.Navigation("Component_TCs");

                    b.Navigation("ExecutionWorks");

                    b.Navigation("Machine_TCs");

                    b.Navigation("Protection_TCs");

                    b.Navigation("Staff_TCs");

                    b.Navigation("Tool_TCs");
                });
#pragma warning restore 612, 618
        }
    }
}