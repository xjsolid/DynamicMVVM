using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicVMTest
{
    public class Album
    {
        public Album()
        {
            this.Name = "UnTitiled";

            Song song1 = new Song();
            song1.Title = "饿狼传说";
            song1.Artist = "张学友";

            Song song2 = new Song();
            song2.Title = "棋子";
            song2.Artist = "王菲";

            songs.Add(song1);
            songs.Add(song2);
        }

        public string Name { get; set; }

        List<Song> songs = new List<Song>();
        public List<Song> Songs
        {
            get { return songs; }
        }

        public Song this[string name]
        {
            get { return FindSong(name); }
        }

        Song FindSong(string name)
        {
            foreach (Song song in songs)
            {
                if (song.Title == name)
                {
                    return song;
                }
            }
            return null;
        }
    }
}
