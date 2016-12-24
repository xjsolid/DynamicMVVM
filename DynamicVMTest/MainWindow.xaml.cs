using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicVMTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AlbumVM albumVM;
        public MainWindow()
        {
            AlbumMgr albumMgr = new AlbumMgr();
            Album album = new Album();
            albumMgr.Album = album;
            

            AlbumMgrVM albumMgrVM = new AlbumMgrVM(albumMgr);


            InitializeComponent();
            this.DataContext = albumMgrVM;
        }
    }
}
