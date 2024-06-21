using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class MusicPlaylist
    {
        public static void Run()
        {
            Console.WriteLine("Iterating over MusicPlaylist collection:");
            var myPlaylist = new Playlist();
            myPlaylist.AddSong(new Song("Title 1", "Artist 1"));
            myPlaylist.AddSong(new Song("Title 2", "Artist 2"));
            myPlaylist.AddSong(new Song("Title 3", "Artist 3"));
            INextIterator<Song> iterator = myPlaylist.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            
        }
    }
    
    //Concrete Aggregate - Playlist
    public class Playlist : INextAggregate<Song>
    {
        private List<Song> _songs = new List<Song>();
        public void AddSong(Song song)
        {
            _songs.Add(song);
        }
        public INextIterator<Song> CreateIterator()
        {
            return new PlaylistIterator(this);
        }
        public int Count => _songs.Count;
        public Song this[int index] => _songs[index];
    }
    //Concrete Song Class
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
        public override string ToString() => $"{Title} by {Artist}";
    }
    //Concrete Iterator - PlaylistIterator
    public class PlaylistIterator : INextIterator<Song>
    {
        private readonly Playlist _playlist;
        private int _index = 0;
        public PlaylistIterator(Playlist playlist)
        {
            _playlist = playlist;
        }
        public bool HasNext()
        {
            return _index < _playlist.Count;
        }
        public Song Next()
        {
            return _playlist[_index++];
        }
    }
    
}
