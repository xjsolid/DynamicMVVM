using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xPlusProject.DynaVMBase;

namespace DynamicVMTest
{
    public class SongVM : DynaViewModelBase<Song>
    {
        public SongVM(Song modelObject) : base(modelObject)
        {
        }
    }
}
