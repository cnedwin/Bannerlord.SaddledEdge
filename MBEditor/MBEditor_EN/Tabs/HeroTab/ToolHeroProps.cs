using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MBEditor.Tabs.HeroTab
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using BrightIdeasSoftware;
    using DarkUI;

    public partial class TabHeroProps : DarkUI.Docking.DarkDocument, ITab
    {
        public Hero selHero => Coordinator?.Hero;

        public TabHeroProps()
        {
            InitializeComponent();
        }

        public MBCoordinator Coordinator { get; set; }

        void ITab.InitializeTab()
        {
            MBEditor.Log.Debug("Initializing Hero Properties Tab");
        }

        void ITab.Activate()
        {
            MBEditor.Log.Debug("Activating Hero Properties Tab");
            this.InitializeAutoSize();
            Reload();
        }

        void ITab.AfterLoad()
        {
        }

        void ITab.Deactivate()
        {
            MBEditor.Log.Debug("Deactivating Hero Properties Tab");
        }

        private void LstItems_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.Control = null;
            }
        }

        private void LstItems_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!e.Column.CheckBoxes && !(e.Column.Renderer is DarkUI.Support.CheckStateRenderer))
            {
                e.AutoDispose = false;
                e.Control = new DarkUI.Controls.DarkNumericUpDown { Bounds = e.CellBounds }.DefaultEditor(e.Value);
            }
        }

        private void Reload()
        {
            if (this.Visible)
                this.darkPropertyGrid1.SetObject( this.selHero);
        }

    }
}
