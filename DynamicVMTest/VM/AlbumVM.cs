using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using xPlusProject.DynaVMBase;

namespace DynamicVMTest
{
    public class AlbumVM : DynaViewModelBase<Album>
    {
        // Generate fake album
        public AlbumVM(Album album) : base(album)
        {
            LoadSongs();
        }

        ObservableCollection<SongVM> songVMs = new ObservableCollection<SongVM>();
        public ObservableCollection<SongVM> SongVMs
        {
            get { return songVMs; }
        }

        void LoadSongs()
        {
            foreach (Song song in this.ModelObject.Songs)
            {
                SongVMs.Add(new SongVM(song));
            }
        }

        #region command

        #endregion

    }
}
