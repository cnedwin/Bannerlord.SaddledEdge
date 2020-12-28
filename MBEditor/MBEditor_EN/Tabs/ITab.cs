using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEditor.Tabs
{
    public interface ITab
    {
        MBCoordinator Coordinator { get; set; }

        void InitializeTab();

        void Activate();

        void Deactivate();

        void AfterLoad();
    }
}
