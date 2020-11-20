using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public partial class DarkTabPage : System.Windows.Forms.TabPage
    {
        public DarkTabPage()
        {
            InitializeComponent();
            InitializeDark();
        }
        public DarkTabPage(string value) : base(value)
        {
            InitializeComponent();
            InitializeDark();
        }

        public DarkTabPage(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeDark();
        }

        public void InitializeDark()
        {
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            TabControl parentInternal = this.Parent as TabControl;
            if ((Application.RenderWithVisualStyles && this.UseVisualStyleBackColor) && ((parentInternal != null) && (parentInternal.Appearance == TabAppearance.Normal)))
            {
                var backColor = this.UseVisualStyleBackColor ? System.Drawing.Color.Transparent : this.BackColor;
                var bounds = this.DisplayRectangle;
                var rectangle2 = new Rectangle(bounds.X - 4, bounds.Y - 2, bounds.Width + 8, bounds.Height + 6);
                TabRenderer.DrawTabPage(e.Graphics, rectangle2);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }
    }
}
