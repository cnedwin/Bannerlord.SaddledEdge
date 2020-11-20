using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DarkUI.Config;

namespace DarkUI.Controls
{
    public partial class DarkTabControl : System.Windows.Forms.TabControl
    {
        public DarkTabControl()
        {
            InitializeComponent();
            InitializeDarkUI();
        }

        public DarkTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeDarkUI();
        }

        void InitializeDarkUI()
        {
            base.HotTrack = true;
            base.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            base.SetStyle(ControlStyles.UserPaint, true);          
        }

        public override Color BackColor { get => DarkUI.Config.Colors.DarkBackground; set { } }
        public override Color ForeColor { get => DarkUI.Config.Colors.LightText; set { } }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var b = new SolidBrush(Colors.GreyBackground))
                g.FillRectangle(b, ClientRectangle);
            if (TabPages.Count == 0)
                return;

            var firstTabRect = GetTabRect(0);
            var tabArea = new Rectangle(firstTabRect.Left, firstTabRect.Top, this.Width, firstTabRect.Height);
            using (var b = new SolidBrush(Colors.MediumBackground))
                g.FillRectangle(b, tabArea);

            int i = 0;
            foreach (TabPage tab in TabPages)
                PaintToolWindowTab(g, tab, GetTabRect(i++));
        }

        private void PaintToolWindowTab(Graphics g, TabPage tab, Rectangle tabRect)
        {
            var isVisibleTab = true;
            var isHot = false; // tabRect.Contains(this.PointToClient(System.Windows.Forms.Cursor.Position));
            var isActive = this.SelectedTab == tab;
            //var bgColor = isVisibleTab ? Colors.GreyBackground : Colors.DarkBackground;

            var bgColor = isVisibleTab ? Colors.GreySelection : Colors.DarkBackground;
            if (isActive)
                bgColor = isVisibleTab ? Colors.BlueSelection : Colors.DarkBackground;


            if (isHot && !isVisibleTab)
                bgColor = Colors.MediumBackground;

            using (var b = new SolidBrush(bgColor))
            {
                g.FillRectangle(b, tabRect);
            }

            // Draw separators
            if (true)
            {
                using (var p = new Pen(Colors.DarkBorder))
                {
                    g.DrawLine(p, tabRect.Right - 1, tabRect.Top, tabRect.Right - 1, tabRect.Bottom);
                }
            }

            var tabTextFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap,
                Trimming = StringTrimming.EllipsisCharacter
            };

            var textColor = isHot ? Color.FromKnownColor(KnownColor.White) : isActive ? Colors.LightText : Colors.DisabledText;
            using (var b = new SolidBrush(textColor))
            {
                var textRect = new Rectangle(tabRect.Left + 5, tabRect.Top, tabRect.Width - 5, tabRect.Height);
                g.DrawString(tab.Text + (isHot?"*":""), Font, b, textRect, tabTextFormat);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //using (var b = new SolidBrush(BackColor))
            //    e.Graphics.FillRectangle(b, e.ClipRectangle);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
        }


    }
}
