﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Data;

#nullable disable

namespace Pokemon.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250221143239_UpdatedDb1")]
    partial class UpdatedDb1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokemon.Models.Evolution", b =>
                {
                    b.Property<int>("EvolutionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvolutionID"));

                    b.Property<int>("EvolutionGroupID")
                        .HasColumnType("int");

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("StageNumber")
                        .HasColumnType("int");

                    b.HasKey("EvolutionID");

                    b.HasIndex("EvolutionGroupID");

                    b.HasIndex("PokemonID");

                    b.ToTable("Evolutions");
                });

            modelBuilder.Entity("Pokemon.Models.EvolutionGroup", b =>
                {
                    b.Property<int>("EvolutionGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvolutionGroupID"));

                    b.HasKey("EvolutionGroupID");

                    b.ToTable("EvolutionGroups");
                });

            modelBuilder.Entity("Pokemon.Models.Move", b =>
                {
                    b.Property<int>("MoveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoveID"));

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovePP")
                        .HasColumnType("int");

                    b.Property<int>("MovePower")
                        .HasColumnType("int");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoveID");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Pokemon.Models.Moveset", b =>
                {
                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("MoveID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID", "MoveID");

                    b.HasIndex("MoveID");

                    b.ToTable("Movesets");
                });

            modelBuilder.Entity("Pokemon.Models.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureID"));

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.Property<int>("PokemonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonID"));

                    b.Property<int?>("EvolutionGroupID")
                        .HasColumnType("int");

                    b.Property<int?>("PictureID")
                        .HasColumnType("int");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID");

                    b.HasIndex("EvolutionGroupID");

                    b.HasIndex("PictureID");

                    b.HasIndex("TrainerID");

                    b.ToTable("PokemonData");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonRegion", b =>
                {
                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<int>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID", "RegionID", "TrainerID");

                    b.HasIndex("RegionID");

                    b.HasIndex("TrainerID");

                    b.ToTable("PokemonRegions");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonType", b =>
                {
                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("TypeListID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID", "TypeListID");

                    b.HasIndex("TypeListID");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("Pokemon.Models.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionID"));

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Pokemon.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerID"));

                    b.Property<bool>("IsGymLeader")
                        .HasColumnType("bit");

                    b.Property<int?>("TrainerAge")
                        .HasColumnType("int");

                    b.Property<string>("TrainerBadge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerID");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Pokemon.Models.TypeList", b =>
                {
                    b.Property<int>("TypeListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeListID"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeListID");

                    b.ToTable("TypeLists");
                });

            modelBuilder.Entity("Pokemon.Models.Evolution", b =>
                {
                    b.HasOne("Pokemon.Models.EvolutionGroup", "EvolutionGroup")
                        .WithMany("Evolutions")
                        .HasForeignKey("EvolutionGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvolutionGroup");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.Moveset", b =>
                {
                    b.HasOne("Pokemon.Models.Move", "Move")
                        .WithMany("Movesets")
                        .HasForeignKey("MoveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("Movesets")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.HasOne("Pokemon.Models.EvolutionGroup", "EvolutionGroup")
                        .WithMany()
                        .HasForeignKey("EvolutionGroupID");

                    b.HasOne("Pokemon.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureID");

                    b.HasOne("Pokemon.Models.Trainer", "Trainer")
                        .WithMany("Pokemons")
                        .HasForeignKey("TrainerID");

                    b.Navigation("EvolutionGroup");

                    b.Navigation("Picture");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonRegion", b =>
                {
                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("PokemonRegions")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.Region", "Region")
                        .WithMany("PokemonRegions")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.Trainer", "Trainer")
                        .WithMany("PokemonRegions")
                        .HasForeignKey("TrainerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Region");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonType", b =>
                {
                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.TypeList", "TypeList")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("TypeListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("TypeList");
                });

            modelBuilder.Entity("Pokemon.Models.EvolutionGroup", b =>
                {
                    b.Navigation("Evolutions");
                });

            modelBuilder.Entity("Pokemon.Models.Move", b =>
                {
                    b.Navigation("Movesets");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.Navigation("Movesets");

                    b.Navigation("PokemonRegions");
                });

            modelBuilder.Entity("Pokemon.Models.Region", b =>
                {
                    b.Navigation("PokemonRegions");
                });

            modelBuilder.Entity("Pokemon.Models.Trainer", b =>
                {
                    b.Navigation("PokemonRegions");

                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("Pokemon.Models.TypeList", b =>
                {
                    b.Navigation("PokemonTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
