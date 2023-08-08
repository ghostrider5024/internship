using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;
using System.Diagnostics.Metrics;

namespace MusicPlayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        public DbSet<Song> Song { get; set; }
        public DbSet<Artist> Artist{ get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<SongArtist> SongArtist { get; set; }
        public DbSet<SongPlaylist> SongPlaylist { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many relation between Song and Artist
            modelBuilder.Entity<SongArtist>()
                    .HasKey(t => new { t.SongId, t.ArtistId });
            modelBuilder.Entity<SongArtist>()
                    .HasOne(t => t.Song)
                    .WithMany(t => t.SongArtists)
                    .HasForeignKey(f => f.SongId);
            modelBuilder.Entity<SongArtist>()
                    .HasOne(t => t.Aritst)
                    .WithMany(t => t.SongArtists)
                    .HasForeignKey(f => f.ArtistId);

            //Many to Many relation between Song and Playlist
            modelBuilder.Entity<SongPlaylist>()
                    .HasKey(t => new { t.SongId, t.PlaylistId });
            modelBuilder.Entity<SongPlaylist>()
                    .HasOne(t => t.Song)
                    .WithMany(t => t.SongPlaylists)
                    .HasForeignKey(f => f.SongId);
            modelBuilder.Entity<SongPlaylist>()
                    .HasOne(t => t.Playlist)
                    .WithMany(t => t.SongPlaylists)
                    .HasForeignKey(f => f.PlaylistId);



        }
    }
}
