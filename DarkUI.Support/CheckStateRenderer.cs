using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DarkUI;
using DarkUI.Config;
using DarkUI.Controls;
using BrightIdeasSoftware;
using System.Windows.Forms.VisualStyles;

namespace DarkUI.Support
{
    // Copied from ObjectListView Renderers

    /// <summary>
    /// This renderer draws just a checkbox to match the check state of our model object.
    /// </summary>
    public class CheckStateRenderer : BaseRenderer
    {
        /// <summary>
        /// Draw our cell
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        public override void Render(Graphics g, Rectangle r)
        {
            this.DrawBackground(g, r);
            if (this.Column == null)
                return;
            r = this.ApplyCellPadding(r);
            bool check = Convert.ToBoolean(this.Column.GetValue(this.RowObject));

            //CheckState state = this.Column.GetCheckState(this.RowObject);
            if (this.IsPrinting)
            {
                //// Renderers don't work onto printer DCs, so we have to draw the image ourselves
                //string key = ObjectListView.CHECKED_KEY;
                //if (state == CheckState.Unchecked)
                //    key = ObjectListView.UNCHECKED_KEY;
                //if (state == CheckState.Indeterminate)
                //    key = ObjectListView.INDETERMINATE_KEY;
                //this.DrawAlignedImage(g, r, this.ListView.SmallImageList.Images[key]);
            }
            else
            {
                r = this.CalculateCheckBoxBounds(g, r);
                //CheckBoxRenderer.DrawCheckBox(g, r.Location, this.GetCheckBoxState(state));
                DrawCheckBox(g, r, check ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal );
            }
        }


        /// <summary>
        /// Handle the GetEditRectangle request
        /// </summary>
        /// <param name="g"></param>
        /// <param name="cellBounds"></param>
        /// <param name="item"></param>
        /// <param name="subItemIndex"></param>
        /// <param name="preferredSize"> </param>
        /// <returns></returns>
        protected override Rectangle HandleGetEditRectangle(Graphics g, Rectangle cellBounds, OLVListItem item, int subItemIndex, Size preferredSize)
        {
            return this.CalculatePaddedAlignedBounds(g, cellBounds, preferredSize);
        }

        /// <summary>
        /// Handle the HitTest request
        /// </summary>
        /// <param name="g"></param>
        /// <param name="hti"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected override void HandleHitTest(Graphics g, OlvListViewHitTestInfo hti, int x, int y)
        {
            Rectangle r = this.CalculateCheckBoxBounds(g, this.Bounds);
            if (r.Contains(x, y))
                hti.HitTestLocation = HitTestLocation.CheckBox;
        }


        private void DrawCheckBox(Graphics g, Rectangle location, CheckBoxState checkBoxState)
        {
            var size = Consts.CheckBoxSize;

            var rect = location;

            var textColor = Colors.LightText;
            var borderColor = Colors.LightText;
            var fillColor = Colors.LightestBackground;

            var Checked = false;
            var Enabled = true;
            var Hover = false;
            var Pressed = false;
            var Focused = true;

            switch (checkBoxState)
            {
                case CheckBoxState.CheckedNormal:
                case CheckBoxState.MixedNormal:
                case CheckBoxState.CheckedDisabled:
                case CheckBoxState.CheckedHot:
                case CheckBoxState.MixedHot:
                case CheckBoxState.CheckedPressed:
                case CheckBoxState.MixedPressed:
                    Checked = true;
                    break;
            }
            switch (checkBoxState)
            {
                case CheckBoxState.CheckedDisabled:
                case CheckBoxState.MixedDisabled:
                case CheckBoxState.UncheckedDisabled:
                    Enabled = false;
                    break;
            }
            switch (checkBoxState)
            {
                case CheckBoxState.CheckedHot:
                case CheckBoxState.MixedHot:
                case CheckBoxState.UncheckedHot:
                    Hover = true;
                    break;
            }
            switch (checkBoxState)
            {
                case CheckBoxState.CheckedPressed:
                case CheckBoxState.MixedPressed:
                case CheckBoxState.UncheckedPressed:
                    Pressed = true;
                    break;
            }
            if (Enabled)
            {
                if (Focused)
                {
                    borderColor = Colors.BlueHighlight;
                    fillColor = Colors.BlueSelection;
                }
                if (Hover)
                {
                    borderColor = Colors.BlueHighlight;
                    fillColor = Colors.BlueSelection;
                }
                else if (Pressed)
                {
                    borderColor = Colors.GreyHighlight;
                    fillColor = Colors.GreySelection;
                }
            }
            else
            {
                borderColor = Colors.GreyHighlight;
                fillColor = Colors.GreySelection;
            }

            using (var b = new SolidBrush(Colors.GreyBackground))
            {
                g.FillRectangle(b, rect);
            }

            using (var p = new Pen(borderColor))
            {
                var boxRect = new Rectangle(rect.Left, rect.Top /*+ (rect.Height / 2) - (size / 2)*/, size, size);
                g.DrawRectangle(p, boxRect);
            }

            if (Checked)
            {
                using (var b = new SolidBrush(fillColor))
                {
                    var boxRect = new Rectangle(rect.Left + 2, rect.Top + (rect.Height / 2) - ((size - 4) / 2), size - 4, size - 4);
                    g.FillRectangle(b, boxRect);
                }
            }
        }
    }
}
