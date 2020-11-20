using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DarkUI;
using DarkUI.Config;
using DarkUI.Controls;

namespace DarkUI.Support
{
    public class ColumnButtonRenderer : BrightIdeasSoftware.ColumnButtonRenderer
    {
        public ColumnButtonRenderer() : base()
        {
            this.ButtonPadding = new Size(1, 1);
        }

        public int Padding { get; set; } = 1;

        /// <summary>
        /// Draw the button
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        protected override void DrawImageAndText(Graphics g, Rectangle r)
        {
            // if text is null then disable rendering
            string buttonText = GetText();
            if (buttonText == null)
                return;

            var textColor = Colors.LightText;
            var borderColor = Colors.GreySelection;
            var fillColor = Colors.LightBackground;

            var buttonState = CalculatePushButtonState();

            var Enabled = (buttonState != System.Windows.Forms.VisualStyles.PushButtonState.Disabled);
            var Focused = IsCellHot;
            var Hover = IsButtonHot || (buttonState == System.Windows.Forms.VisualStyles.PushButtonState.Hot);
            var Pressed = (buttonState == System.Windows.Forms.VisualStyles.PushButtonState.Pressed);
            var Padding = new Padding(this.Padding);

            if (Enabled)
            {
                if (Focused)
                    borderColor = Colors.BlueHighlight;

                if (Hover)
                    fillColor = Colors.LighterBackground;
                else if (Pressed)
                    fillColor = Colors.DarkBackground;
            }
            else
            {
                textColor = Colors.DisabledText;
                fillColor = Colors.DarkGreySelection;
            }

            using (var b = new SolidBrush(fillColor))
            {
                g.FillRectangle(b, r);
            }

            using (var p = new Pen(borderColor, 1))
            {
                var modRect = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);

                g.DrawRectangle(p, modRect);
            }

            var textOffsetX = 0;
            var textOffsetY = 0;

            //if (Image != null)
            //{
            //    var stringSize = g.MeasureString(Text, Font, rect.Size);
            //    var x = (ClientSize.Width / 2) - (Image.Size.Width / 2);
            //    var y = (ClientSize.Height / 2) - (Image.Size.Height / 2);
            //    switch (TextImageRelation)
            //    {
            //        case TextImageRelation.ImageAboveText:
            //            textOffsetY = (Image.Size.Height / 2) + (ImagePadding / 2);
            //            y = y - ((int)(stringSize.Height / 2) + (ImagePadding / 2));
            //            break;
            //        case TextImageRelation.TextAboveImage:
            //            textOffsetY = ((Image.Size.Height / 2) + (ImagePadding / 2)) * -1;
            //            y = y + ((int)(stringSize.Height / 2) + (ImagePadding / 2));
            //            break;
            //        case TextImageRelation.ImageBeforeText:
            //            textOffsetX = Image.Size.Width + (ImagePadding * 2);
            //            x = ImagePadding;
            //            break;
            //        case TextImageRelation.TextBeforeImage:
            //            x = x + (int)stringSize.Width;
            //            break;
            //    }
            //    g.DrawImageUnscaled(Image, x, y);
            //}

            using (var b = new SolidBrush(textColor))
            {
                var modRect = new Rectangle(r.Left + textOffsetX + Padding.Left,
                                            r.Top + textOffsetY + Padding.Top, r.Width - Padding.Horizontal,
                                            r.Height - Padding.Vertical);

                var stringFormat = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };

                g.DrawString(buttonText, Font, b, modRect, stringFormat);
            }
        }
    }
}
