using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DarkUI
{
    public static class Extensions
    {
        static readonly Color highlightCellColor = Color.FromArgb(255, 250, 250, 250);
        static readonly Color primaryCellColor = Color.FromArgb(255, 189, 193, 202);
        static readonly Color otherCellColor = Color.FromArgb(255, 140, 140, 140);

        public static void DefaultGrid(this PropertyGrid grid)
        {
            grid.HelpBackColor = DarkUI.Config.Colors.LighterBackground;
            grid.ViewBackColor = DarkUI.Config.Colors.MediumBackground;
            grid.ViewForeColor = DarkUI.Config.Colors.LightText;
            //grid.CategorySplitterColor = DarkUI.Config.Colors.LightBorder;
            //grid.DisabledItemForeColor = DarkUI.Config.Colors.MediumBackground;
            grid.HelpForeColor = DarkUI.Config.Colors.LightText;
            grid.LineColor = DarkUI.Config.Colors.LightBorder;
            grid.CategoryForeColor = DarkUI.Config.Colors.LightText;
        }

        public static void DefaultList(this BrightIdeasSoftware.ObjectListView list)
        {
            list.CellEditUseWholeCell = true;
            list.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            list.FullRowSelect = true;
            list.GridLines = true;
            list.HeaderWordWrap = true;
            list.HideSelection = false;
            list.UseCompatibleStateImageBehavior = false;
            list.ShowCommandMenuOnRightClick = true;
            list.ShowImagesOnSubItems = true;
            list.ShowItemCountOnGroups = true;
            list.UseFiltering = true;
            list.UseHotItem = false;
            list.UseAlternatingBackColors = true;
            //list.BackColor = DarkUI.Config.Colors.GreyBackground;
            //list.AlternateRowBackColor = DarkUI.Config.Colors.HeaderBackground;
            //list.ForeColor = DarkUI.Config.Colors.MediumBackground;
            list.UseHotControls = false;
            list.UseTranslucentHotItem = false;
            list.UseTranslucentSelection = false;
            list.HoverSelection = false;
            list.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            list.MultiSelect = false;
            list.ShowGroups = false;
            list.OwnerDraw = true;
            list.FullRowSelect = true;
            list.HeaderUsesThemes = false;

            list.BackColor = DarkUI.Config.Colors.LightBackground;
            list.ForeColor = DarkUI.Config.Colors.LightText;
            list.AlternateRowBackColor = DarkUI.Config.Colors.MediumBackground;
            list.GridLines = false;
            //list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            //list.HighlightBackgroundColor = DarkUI.Config.Colors.BlueSelection;
            //list.HighlightForegroundColor = DarkUI.Config.Colors.LightText;
            list.SelectedBackColor = DarkUI.Config.Colors.BlueSelection;
            list.SelectedForeColor = DarkUI.Config.Colors.LightText;
            list.UseCustomSelectionColors = true;
            list.HeaderFormatStyle = new BrightIdeasSoftware.HeaderFormatStyle()
            {
                Normal = new BrightIdeasSoftware.HeaderStateStyle
                {
                    BackColor = DarkUI.Config.Colors.DarkBackground,
                    ForeColor = DarkUI.Config.Colors.LightText,
                    Font = list.Font,
                    FrameColor = DarkUI.Config.Colors.LighterBackground,
                    FrameWidth = 1,
                },
                Hot = new BrightIdeasSoftware.HeaderStateStyle
                {
                    BackColor = DarkUI.Config.Colors.DarkBlueBackground,
                    ForeColor = DarkUI.Config.Colors.LightText,
                    Font = list.Font,
                    FrameColor = DarkUI.Config.Colors.LighterBackground,
                    FrameWidth = 1,
                },
                Pressed = new BrightIdeasSoftware.HeaderStateStyle
                {
                    BackColor = DarkUI.Config.Colors.BlueBackground,
                    ForeColor = DarkUI.Config.Colors.LightText,
                    Font = list.Font,
                    FrameColor = DarkUI.Config.Colors.LighterBackground,
                    FrameWidth = 1,
                }
            };

            list.UseCustomSelectionColors = true;
            list.FormatCell += List_FormatCell;
        }


        public static void DrawDarkHeader(this DrawListViewColumnHeaderEventArgs arg)
        {
            using (Brush brush = new SolidBrush(DarkUI.Config.Colors.DarkBackground))
                arg.Graphics.FillRectangle(brush, arg.Bounds);
            Rectangle bounds = arg.Bounds;
            bounds.Width--;
            bounds.Height--;
            using (Pen pen = new Pen(DarkUI.Config.Colors.DarkBackground))
                arg.Graphics.DrawRectangle(pen, bounds);
            bounds.Width--;
            bounds.Height--;
            using (Pen lightpen = new Pen(DarkUI.Config.Colors.LighterBackground))
            {
                arg.Graphics.DrawLine(lightpen, bounds.X, bounds.Y, bounds.Right, bounds.Y);
                arg.Graphics.DrawLine(lightpen, bounds.X, bounds.Y, bounds.X, bounds.Bottom);
            }
            using (Pen darkpen = new Pen(DarkUI.Config.Colors.DarkBackground))
            {
                arg.Graphics.DrawLine(darkpen, bounds.X + 1, bounds.Bottom, bounds.Right, bounds.Bottom);
                arg.Graphics.DrawLine(darkpen, bounds.Right, bounds.Y + 1, bounds.Right, bounds.Bottom);
            }

        }

        private static void List_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
                e.SubItem.ForeColor = primaryCellColor;
            else
                e.SubItem.ForeColor = otherCellColor;
        }

        public static void BeginUpdate(this DarkUI.Controls.DarkListView control)
        {
        }
        public static void EndUpdate(this DarkUI.Controls.DarkListView control)
        {
        }

        public static void Add(this System.Collections.ObjectModel.ObservableCollection<DarkUI.Controls.DarkListItem> list, object item)
        {
            list.Add(new DarkUI.Controls.DarkListItem(item));
        }
        public static T GetFirstSelection<T>(this DarkUI.Controls.DarkListView control) where T : class
        {
            var indices = control.SelectedIndices;
            if (indices == null || indices.Count == 0 || control.Items.Count == 0)
                return default(T);
            return control.Items[indices[0]].Tag as T;
        }
        public static int GetFirstSelectedIndex(this DarkUI.Controls.DarkListView control)
        {
            var indices = control.SelectedIndices;
            if (indices == null || indices.Count == 0 || control.Items.Count == 0)
                return -1;
            return indices[0];
        }

        //static Dictionary<Type, Hyper.ComponentModel.HyperTypeDescriptionProvider> providers = new Dictionary<Type, Hyper.ComponentModel.HyperTypeDescriptionProvider>();
        //public static System.ComponentModel.ICustomTypeDescriptor AddDescriptor(this Type type, object instance)
        //{
        //    if (instance == null) return null;

        //    if (!providers.TryGetValue(type, out var provider)) {
        //        provider = new Hyper.ComponentModel.HyperTypeDescriptionProvider(type);
        //        providers[type] = provider;
        //    }
        //    //System.ComponentModel.TypeDescriptor.AddProvider(provider, instance);
        //    return provider.GetTypeDescriptor(instance);
        //}

        //public static void RemoveDescriptor(this Type type, object instance)
        //{
        //    if (providers.TryGetValue(type, out var provider))
        //        System.ComponentModel.TypeDescriptor.RemoveProvider(provider, instance);
        //}
    }
}
