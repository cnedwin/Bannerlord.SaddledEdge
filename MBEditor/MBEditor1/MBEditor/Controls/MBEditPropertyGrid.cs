using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Controls;
#if MBVER_010201
using TaleWorlds.Core;
#else
using TaleWorlds.ObjectSystem;
#endif
using MBEditor;

namespace MBEditor.Controls
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;
    using DarkUI.Support;

    public partial class MBEditPropertyGrid : DarkUI.Support.DarkPropertyGrid
    {
        public MBEditPropertyGrid():base()
        {
            
        }

        public MBEditPropertyGrid(IContainer container) : base(container)
        {

        }

        void InitializeGrid()
        {

        }

        protected override void OnCellEditStarting(CellEditEventArgs e)
        {
            if (e.Cancel)
                return;

            if (e.RowObject is IPropertyValue prop) {
                if (prop.Type != null && typeof(MBObjectBase).IsAssignableFrom(prop.Type)) {
                    var cb = new DarkUI.Controls.DarkComboBox {
                        Bounds = e.CellBounds, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = false,
                    };
                    cb.InitializeComboBox(type: prop.Type, value: e.Value as MBObjectBase);
                    e.Control = cb;
                    e.AutoDispose = true;
                    return;
                }
            }

            base.OnCellEditStarting(e);
        }

        protected override void OnCellEditFinishing(CellEditEventArgs e)
        {
            if (e.RowObject is IPropertyValue prop)
            {
                if (e.Control is DarkUI.Controls.DarkComboBox cb)
                {
                    if (typeof(MBObjectBase).IsAssignableFrom(prop.Type))
                    {
                        if (e.Cancel)
                            return;

                        if (cb.SelectedItem is DarkUI.Controls.DarkListItem li) {
                            e.NewValue = li.Tag;
                            prop.Value = li.Tag;
                        }
                        return;
                    }
                }
            }

            base.OnCellEditFinishing(e);
        }
    }
}
