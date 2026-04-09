using System.ComponentModel;

namespace assignment6.Server.Models;

public class Playlist
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<Track> Tracks { get; set; }
}

