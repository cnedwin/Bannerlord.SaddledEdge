using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEditor
{
    using TaleWorlds.Core;

    public class SharedState
    {
        public readonly Dictionary<ItemObject.ItemTypeEnum, string> ModDefaultDict = new Dictionary<ItemObject.ItemTypeEnum, string>();
    }
}
