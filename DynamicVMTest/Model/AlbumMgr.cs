using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicVMTest
{
    public class AlbumMgr
    {
        #region members
        Album album;
        #endregion

        #region props
        public Album Album
        {
            get { return album; }
            set { album = value; }
        }
        #endregion

        #region methods
        public void Add(Song song)
        {
            album.Songs.Add(song);
        }

        public void Add(string title, string artist)
        {
            Song song = new Song();
            song.Title = title;
            song.Artist = artist;
            Add(song);
        }

        public bool Delete(Song song)
        {
            return album.Songs.Remove(song);
        }

        public bool Delete(string title, string artist)
        {
            foreach (Song item in album.Songs)
            {
                if (item.Title.Equals(title) && item.Artist.Equals(artist))
                {
                    return Delete(item);
                }
            }
            return false;
        }
        #endregion
    }
}
