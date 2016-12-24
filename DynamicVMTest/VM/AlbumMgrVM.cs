using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using xPlusProject.DynaVMBase;

namespace DynamicVMTest
{
    public class AlbumMgrVM : DynaViewModelBase<AlbumMgr>
    {
        #region ctor
        public AlbumMgrVM(AlbumMgr modelObject) : base(modelObject)
        {
        }


        #endregion


        #region members
        string currentSongTitle = string.Empty;
        string currentSongArtist = string.Empty;
        #endregion

        #region props
        public string CurrentSongTitle
        {
            get { return currentSongTitle; }
            set
            {
                currentSongTitle = value;
                NotifyPropertyChanged("CurrentSongTitle");
                NotifyPropertyChanged("AddCmd");
                NotifyPropertyChanged("DeleteCmd");
            }
        }

        public string CurrentSongArtist
        {
            get { return currentSongArtist; }
            set
            {
                currentSongArtist = value;
                NotifyPropertyChanged("CurrentSongArtist");
                NotifyPropertyChanged("AddCmd");
                NotifyPropertyChanged("DeleteCmd");
            }
        }
        #endregion

        #region commands
        RelayCommand addCmd = null;
        public ICommand AddCmd
        {
            get
            {
                if (addCmd == null)
                {
                    return new RelayCommand(OnAdd, CanAdd);
                }
                return addCmd;
            }
        }

        void OnAdd()
        {
            this.ModelObject.Add(currentSongTitle, currentSongArtist);
        }

        bool CanAdd()
        {
            if (string.IsNullOrEmpty(currentSongTitle) || string.IsNullOrEmpty(currentSongArtist))
            {
                return false;
            }
            return true;
        }

        RelayCommand deleteCmd = null;
        public ICommand DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    return new RelayCommand(OnDelete, CanDelete);
                }
                return deleteCmd;
            }
        }


        void OnDelete()
        {

        }

        bool CanDelete()
        {
            return true;
        }
        #endregion
    }
}
