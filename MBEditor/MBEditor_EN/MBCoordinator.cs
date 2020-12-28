using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBEditor
{
    using TaleWorlds.CampaignSystem;
    using TaleWorlds.Core;
    using TaleWorlds.Library;
    using MBEditor.Tabs;
    using System.Windows.Forms;

    /// <summary>
    /// This class holds all the common bits of code that are used across multiple tabs.
    /// It also provides the tabs with access to form level elements, like status bar texts.
    /// </summary>
    public class MBCoordinator
    {
        public readonly SharedState State = new SharedState();

        private Hero _hero;
        internal Hero Hero 
        {
            get => _hero;
            set
            {
                if (_hero == value)
                    return;
                Deactivate();
                _hero = value;
                Activate();                
            }
        }

        public EventHandler<EventArgs> DataChanged;

        DarkUI.Docking.DarkDockPanel _control;
        DarkUI.Docking.DarkDockContent _page;

        internal DarkUI.Docking.DarkDockPanel Control
        {
            get => _control;
            set
            {
                _control = value;
                if (_control != null)
                {
                    foreach (var v in _control.GetDocuments().OfType<Tabs.ITab>())
                    {
                        v.Coordinator = this;
                        v.InitializeTab();
                    }
                    _control.ActiveContentChanged += (sender, e) => this.TabPage = e.Content;
                    this.TabPage = _control.ActiveContent;
                }
            }
        }

        internal DarkUI.Docking.DarkDockContent TabPage
        {
            get => _page;
            set
            {
                if (_page is Tabs.ITab)
                        ((Tabs.ITab)_page).Deactivate();

                _page = value;

                if (_page is Tabs.ITab)
                    ((Tabs.ITab)_page).Activate();
            }
        }

        internal void Activate()
        {
            if (_page is Tabs.ITab)
                ((Tabs.ITab)_page).Activate();
        }

        internal void Deactivate()
        {
            if (_page is Tabs.ITab)
                ((Tabs.ITab)_page).Deactivate();
        }

        internal void InvokeDataChange()
        {
            DataChanged?.Invoke(this.Hero, EventArgs.Empty);
        }

        internal void InvokeDataChange<T>() where T : EventArgs, new()
        {
            DataChanged?.Invoke(this.Hero, new T());
        }
    }
}
