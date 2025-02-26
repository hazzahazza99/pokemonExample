using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<PokemonData> Pokemon { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<EvolutionGroup> EvolutionGroups { get; set; }
        public DbSet<EvolutionStage> EvolutionStages { get; set; }
        public DbSet<Moveset> Movesets { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PokemonRegion> PokemonRegions { get; set; }
        public DbSet<PokeType> PokeTypes { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<PokemonData>().HasKey(p => p.PokemonID);
            modelBuilder.Entity<Trainer>().HasKey(t => t.TrainerID);
            modelBuilder.Entity<Picture>().HasKey(p => p.PictureID);
            modelBuilder.Entity<EvolutionGroup>().HasKey(eg => eg.EvolutionGroupID);
            modelBuilder.Entity<Move>().HasKey(m => m.MoveID);
            modelBuilder.Entity<PokeType>().HasKey(t => t.PokeTypeID);
            modelBuilder.Entity<Region>().HasKey(r => r.RegionID);

            // Composite Keys
            modelBuilder.Entity<EvolutionStage>().HasKey(es => new { es.GroupID, es.StageOrder });
            modelBuilder.Entity<Moveset>().HasKey(ms => new { ms.MovesetPokemonID, ms.MovesetMoveID });
            modelBuilder.Entity<PokemonRegion>().HasKey(pr => new { pr.RegionsPokemonID, pr.RegionsRegionID });
            modelBuilder.Entity<PokemonType>().HasKey(pt => new { pt.TypesPokemonID, pt.TypesPokeTypeID });

            // Relationships
            modelBuilder.Entity<PokemonData>()
                .HasOne(p => p.PokemonPicture)
                .WithMany()
                .HasForeignKey(p => p.PokemonPictureID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonData>()
                .HasOne(p => p.Trainer)
                .WithMany(t => t.Pokemon)
                .HasForeignKey(p => p.PokemonTrainerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonData>()
                .HasOne(p => p.EvolutionGroup)
                .WithMany(eg => eg.PokemonData)
                .HasForeignKey(p => p.EvolutionGroupID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.TrainerPhoto)
                .WithMany()
                .HasForeignKey(t => t.TrainerPhotoID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvolutionStage>()
                .HasOne(es => es.EvolutionGroup)
                .WithMany(eg => eg.EvolutionStages)
                .HasForeignKey(es => es.GroupID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EvolutionStage>()
                .HasOne(es => es.Pokemon)
                .WithMany(p => p.EvolutionStages)
                .HasForeignKey(es => es.PokemonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Moveset>()
                .HasOne(ms => ms.Pokemon)
                .WithMany(p => p.Moves)
                .HasForeignKey(ms => ms.MovesetPokemonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Moveset>()
                .HasOne(ms => ms.Move)
                .WithMany(m => m.Movesets)
                .HasForeignKey(ms => ms.MovesetMoveID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Move>()
                .HasOne(m => m.MovePokeType)
                .WithMany(t => t.Moves)
                .HasForeignKey(m => m.MovePokeTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Pokemon)
                .WithMany(p => p.PokemonTypes)
                .HasForeignKey(pt => pt.TypesPokemonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.PokeType)
                .WithMany(t => t.PokemonTypes)
                .HasForeignKey(pt => pt.TypesPokeTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonRegion>()
                .HasOne(pr => pr.Pokemon)
                .WithMany(p => p.Regions)
                .HasForeignKey(pr => pr.RegionsPokemonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PokemonRegion>()
                .HasOne(pr => pr.Region)
                .WithMany(r => r.PokemonRegions)
                .HasForeignKey(pr => pr.RegionsRegionID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}