using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PokemonData> PokemonData { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<EvolutionGroup> EvolutionGroups { get; set; }
        public DbSet<Evolution> Evolutions { get; set; }
        public DbSet<Moveset> Movesets { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<PokemonRegion> PokemonRegions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TypeList> TypeLists { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Keys
            modelBuilder.Entity<Moveset>()
                .HasKey(ms => new { ms.PokemonID, ms.MoveID });

            modelBuilder.Entity<PokemonRegion>()
                .HasKey(pr => new { pr.PokemonID, pr.RegionID});

            modelBuilder.Entity<PokemonType>()
                .HasKey(pt => new { pt.PokemonID, pt.TypeListID });

            // Relationships
            modelBuilder.Entity<PokemonData>()
                .HasOne(p => p.Picture)
                .WithMany()
                .HasForeignKey(p => p.PictureID);

            modelBuilder.Entity<PokemonData>()
                .HasOne(p => p.EvolutionGroup)
                .WithMany()
                .HasForeignKey(p => p.EvolutionGroupID);

            modelBuilder.Entity<Evolution>()
                .HasOne(e => e.EvolutionGroup)
                .WithMany(eg => eg.Evolutions)
                .HasForeignKey(e => e.EvolutionGroupID);

            modelBuilder.Entity<Evolution>()
                .HasOne(e => e.Pokemon)
                .WithMany()
                .HasForeignKey(e => e.PokemonID);

            modelBuilder.Entity<Moveset>()
                .HasOne(ms => ms.Pokemon)
                .WithMany(p => p.Movesets)
                .HasForeignKey(ms => ms.PokemonID);

            modelBuilder.Entity<Moveset>()
                .HasOne(ms => ms.Move)
                .WithMany(m => m.Movesets)
                .HasForeignKey(ms => ms.MoveID);

            modelBuilder.Entity<PokemonRegion>()
                .HasOne(pr => pr.Pokemon)
                .WithMany(p => p.PokemonRegions)
                .HasForeignKey(pr => pr.PokemonID);

            modelBuilder.Entity<PokemonRegion>()
                .HasOne(pr => pr.Region)
                .WithMany(r => r.PokemonRegions)
                .HasForeignKey(pr => pr.RegionID);


            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Pokemon)
                .WithMany()
                .HasForeignKey(pt => pt.PokemonID);

            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.TypeList)
                .WithMany(tl => tl.PokemonTypes)
                .HasForeignKey(pt => pt.TypeListID);
        }
    }
}
