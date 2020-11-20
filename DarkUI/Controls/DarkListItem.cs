using DarkUI.Config;
using System;
using System.Drawing;

namespace DarkUI.Controls
{
    public class DarkListItem
    {
        #region Event Region

        public event EventHandler TextChanged;

        #endregion

        #region Field Region

        private Func<object, string> _aspect;

        #endregion

        #region Property Region

        public string Text
        {
            get { return (_aspect == null ? Tag?.ToString() : _aspect(Tag)) ?? ""; }
            set
            {
                if (_aspect == null)
                {
                    Tag = value;
                    if (TextChanged != null)
                        TextChanged(this, new EventArgs());
                }
            }
        }

        public Rectangle Area { get; set; }

        public Color TextColor { get; set; }

        public FontStyle FontStyle { get; set; }

        public Bitmap Icon { get; set; }

        public object Tag { get; set; }

        #endregion

        #region Method Region

        public override string ToString()
        {
            return Text;
        }

        #endregion

        #region Constructor Region

        public DarkListItem()
        {
            TextColor = Colors.LightText;
            FontStyle = FontStyle.Regular;
        }

        public DarkListItem(string text)
            : this()
        {
            Text = text;
        }

        public DarkListItem(object tag, Func<object,string> aspect = null)
            : this()
        {
            Tag = tag;
            _aspect = aspect;
        }

        #endregion
    }
}
