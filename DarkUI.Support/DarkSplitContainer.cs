using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkUI.Support
{
    public partial class DarkSplitContainer : SplitContainer
    {
        public DarkSplitContainer()
        {
            this.Margin = Padding.Empty;
            this.Padding = Padding.Empty;
            this.AutoScaleMode = AutoScaleMode.Inherit; 
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            this.SplitterWidth = 8;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.SplitterWidth = 8;
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            var pct = (float)this.SplitterDistance / (float)((this.Orientation == Orientation.Horizontal) ? this.Height : this.Width);
            base.SetClientSizeCore(x, y);
            this.SplitterDistance = (int)(pct * (float)((this.Orientation == Orientation.Horizontal) ? y : x));
        }
    }
}
