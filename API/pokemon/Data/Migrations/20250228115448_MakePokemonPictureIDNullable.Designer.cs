﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Data;

#nullable disable

namespace Pokemon.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250228115448_MakePokemonPictureIDNullable")]
    partial class MakePokemonPictureIDNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokemon.Models.EvolutionGroup", b =>
                {
                    b.Property<int>("EvolutionGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvolutionGroupID"));

                    b.HasKey("EvolutionGroupID");

                    b.ToTable("EvolutionGroups");
                });

            modelBuilder.Entity("Pokemon.Models.EvolutionStage", b =>
                {
                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("StageOrder")
                        .HasColumnType("int");

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.HasKey("GroupID", "StageOrder");

                    b.HasIndex("PokemonID");

                    b.ToTable("EvolutionStages");
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

                    b.Property<int>("MovePokeTypeID")
                        .HasColumnType("int");

                    b.Property<int>("MovePower")
                        .HasColumnType("int");

                    b.HasKey("MoveID");

                    b.HasIndex("MovePokeTypeID");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Pokemon.Models.Moveset", b =>
                {
                    b.Property<int>("MovesetPokemonID")
                        .HasColumnType("int");

                    b.Property<int>("MovesetMoveID")
                        .HasColumnType("int");

                    b.HasKey("MovesetPokemonID", "MovesetMoveID");

                    b.HasIndex("MovesetMoveID");

                    b.ToTable("Movesets");
                });

            modelBuilder.Entity("Pokemon.Models.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureID"));

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Pokemon.Models.PokeType", b =>
                {
                    b.Property<int>("PokeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokeTypeID"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokeTypeID");

                    b.ToTable("PokeTypes");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.Property<int>("PokemonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonID"));

                    b.Property<int?>("EvolutionGroupID")
                        .HasColumnType("int");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PokemonPictureID")
                        .HasColumnType("int");

                    b.Property<int?>("PokemonTrainerID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID");

                    b.HasIndex("EvolutionGroupID");

                    b.HasIndex("PokemonPictureID");

                    b.HasIndex("PokemonTrainerID");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonRegion", b =>
                {
                    b.Property<int>("RegionsPokemonID")
                        .HasColumnType("int");

                    b.Property<int>("RegionsRegionID")
                        .HasColumnType("int");

                    b.HasKey("RegionsPokemonID", "RegionsRegionID");

                    b.HasIndex("RegionsRegionID");

                    b.ToTable("PokemonRegions");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonType", b =>
                {
                    b.Property<int>("TypesPokemonID")
                        .HasColumnType("int");

                    b.Property<int>("TypesPokeTypeID")
                        .HasColumnType("int");

                    b.HasKey("TypesPokemonID", "TypesPokeTypeID");

                    b.HasIndex("TypesPokeTypeID");

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

                    b.Property<int>("TrainerAge")
                        .HasColumnType("int");

                    b.Property<int>("TrainerBadge")
                        .HasColumnType("int");

                    b.Property<bool>("TrainerIsGymLeader")
                        .HasColumnType("bit");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerPhotoID")
                        .HasColumnType("int");

                    b.HasKey("TrainerID");

                    b.HasIndex("TrainerPhotoID");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Pokemon.Models.EvolutionStage", b =>
                {
                    b.HasOne("Pokemon.Models.EvolutionGroup", "EvolutionGroup")
                        .WithMany("EvolutionStages")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("EvolutionStages")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EvolutionGroup");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.Move", b =>
                {
                    b.HasOne("Pokemon.Models.PokeType", "MovePokeType")
                        .WithMany("Moves")
                        .HasForeignKey("MovePokeTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MovePokeType");
                });

            modelBuilder.Entity("Pokemon.Models.Moveset", b =>
                {
                    b.HasOne("Pokemon.Models.Move", "Move")
                        .WithMany("Movesets")
                        .HasForeignKey("MovesetMoveID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("Moves")
                        .HasForeignKey("MovesetPokemonID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.HasOne("Pokemon.Models.EvolutionGroup", "EvolutionGroup")
                        .WithMany("PokemonData")
                        .HasForeignKey("EvolutionGroupID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pokemon.Models.Picture", "PokemonPicture")
                        .WithMany()
                        .HasForeignKey("PokemonPictureID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pokemon.Models.Trainer", "Trainer")
                        .WithMany("Pokemon")
                        .HasForeignKey("PokemonTrainerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("EvolutionGroup");

                    b.Navigation("PokemonPicture");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonRegion", b =>
                {
                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("Regions")
                        .HasForeignKey("RegionsPokemonID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.Region", "Region")
                        .WithMany("PokemonRegions")
                        .HasForeignKey("RegionsRegionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonType", b =>
                {
                    b.HasOne("Pokemon.Models.PokeType", "PokeType")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("TypesPokeTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pokemon.Models.PokemonData", "Pokemon")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("TypesPokemonID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PokeType");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Models.Trainer", b =>
                {
                    b.HasOne("Pokemon.Models.Picture", "TrainerPhoto")
                        .WithMany()
                        .HasForeignKey("TrainerPhotoID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("TrainerPhoto");
                });

            modelBuilder.Entity("Pokemon.Models.EvolutionGroup", b =>
                {
                    b.Navigation("EvolutionStages");

                    b.Navigation("PokemonData");
                });

            modelBuilder.Entity("Pokemon.Models.Move", b =>
                {
                    b.Navigation("Movesets");
                });

            modelBuilder.Entity("Pokemon.Models.PokeType", b =>
                {
                    b.Navigation("Moves");

                    b.Navigation("PokemonTypes");
                });

            modelBuilder.Entity("Pokemon.Models.PokemonData", b =>
                {
                    b.Navigation("EvolutionStages");

                    b.Navigation("Moves");

                    b.Navigation("PokemonTypes");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("Pokemon.Models.Region", b =>
                {
                    b.Navigation("PokemonRegions");
                });

            modelBuilder.Entity("Pokemon.Models.Trainer", b =>
                {
                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
