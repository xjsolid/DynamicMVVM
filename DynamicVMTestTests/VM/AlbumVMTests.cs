using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicVMTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicVMTest.Tests
{
    [TestClass()]
    public class AlbumVMTests
    {
        [TestMethod()]
        public void AlbumVMTest()
        {
            Album album = new Album();
            AlbumVM albumVM = new AlbumVM(album);
            Assert.AreEqual(2, albumVM.SongVMs.Count);
        }
    }
}