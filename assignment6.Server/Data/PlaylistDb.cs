using assignment6.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment6.Server.Data;

public class PlaylistDb : DbContext
{
    public PlaylistDb(DbContextOptions<PlaylistDb> options)
        : base(options){}

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Track> Tracks { get; set; }
}