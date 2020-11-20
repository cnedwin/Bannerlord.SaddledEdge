using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace DarkUI.Support
{

    public partial class DarkPropertyGrid : BrightIdeasSoftware.TreeListView
    {
        [DefaultValue(null)]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete]
        public new System.Drawing.Font HeaderFont
        {
            get => base.HeaderFont;
            set => base.HeaderFont = value;
        }

        public DarkPropertyGrid() :base()
        {
            InitializeComponent();
            InitializePropGrid();
        }

        public DarkPropertyGrid(IContainer container) : base()
        {
            container.Add(this);

            InitializeComponent();
            InitializePropGrid();
        }

        void InitializePropGrid()
        {
            this.DefaultList();
            this.MultiSelect = false;
            //this.GridLines = true;

            this.AllColumns.Clear();
            this.AllColumns.Add(new OLVColumn
            {
                Text = "Name",
                IsVisible = true,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = false,
                Width = 150,
                MinimumWidth = 140,
                AspectGetter = row => ((IPropertyValue)row).Name,
            });
            this.AllColumns.Add(new OLVColumn
            {
                Text = "Value",
                IsVisible = true,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = true,
                Width = 150,
                MinimumWidth = 140,
                AspectGetter = row => ((IPropertyValue)row).Value,
            });
            this.Columns.Clear();
            this.Columns.AddRange(this.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
            this.AutoSizeColumns();
            this.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.CellRendererGetter = (row, col) => (col.Text == "Value") ? ((IPropertyValue)row).Renderer ?? col.Renderer : col.Renderer;

            this.CanExpandGetter = row => ((IPropertyValue)row).CanHaveChildren;
            this.ChildrenGetter = row => ((IPropertyValue)row).Children;

        }


        protected override void OnFormatRow(FormatRowEventArgs args)
        {
            base.OnFormatRow(args);
            var prop = args.Model as IPropertyValue;
            if (prop != null)
                args.Item.ForeColor = prop.IsReadOnly ? DarkUI.Config.Colors.DisabledText : DarkUI.Config.Colors.LightText;
        }

        protected override void OnCellEditStarting(CellEditEventArgs e)
        {
            base.OnCellEditStarting(e);
            if (e.Cancel) return;

            var prop = e.RowObject as IPropertyValue;
            if (prop == null || prop.IsReadOnly)
            {
                e.Cancel = true;
                return;
            }

            var type = prop.Value.GetType();
            var typeCode = Convert.GetTypeCode(prop.Value);
            if (typeCode == TypeCode.Boolean)
            {
                e.AutoDispose = true;
                var cb = new DarkUI.Controls.DarkComboBox
                {
                    Bounds = e.CellBounds,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Sorted = false,
                };
                cb.Items.Add(Boolean.FalseString);
                cb.Items.Add(Boolean.TrueString);
                cb.SelectedIndex = Convert.ToInt32(e.Value);
                e.Control = cb;
            }
            else if (type.IsEnum)
            {
                e.AutoDispose = true;
                var cb = new DarkUI.Controls.DarkComboBox
                {
                    Bounds = e.CellBounds,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Sorted = false,
                };
                cb.Items.AddRange(Enum.GetNames(type));
                cb.SelectedIndex = cb.FindStringExact(e.Value.ToString());
                e.Control = cb;
            }
            else if (typeCode == TypeCode.String)
            {
                e.AutoDispose = true;
                e.Control = new DarkUI.Controls.DarkTextBox
                {
                    Bounds = e.CellBounds,
                    Text = e.Value.ToString(),
                };
            }
            else if (typeCode == TypeCode.Object || typeCode == TypeCode.DBNull || typeCode == TypeCode.Empty)
            {
                e.Cancel = true;
            }
            else // numeric types
            {
                var value = prop.Value;
                var minValue = (decimal)int.MinValue;
                var maxValue = (decimal)int.MaxValue;
                var incr = Convert.ToDecimal(Math.Pow(10, Math.Min(3, Math.Max(0, Convert.ToInt32(Math.Log10(Convert.ToDouble(value))) - 2))));

                switch (typeCode)
                {
                    case TypeCode.Byte:
                        minValue = (decimal)byte.MinValue;
                        maxValue = (decimal)byte.MaxValue;
                        break;
                    case TypeCode.SByte:
                        minValue = (decimal)sbyte.MinValue;
                        maxValue = (decimal)sbyte.MaxValue;
                        break;
                    case TypeCode.Char:
                        minValue = (decimal)char.MinValue;
                        maxValue = (decimal)char.MaxValue;
                        break;
                    case TypeCode.Int16:
                        minValue = (decimal)Int16.MinValue;
                        maxValue = (decimal)Int16.MaxValue;
                        break;
                    case TypeCode.Int32:
                        minValue = (decimal)Int32.MinValue;
                        maxValue = (decimal)Int32.MaxValue;
                        break;
                    case TypeCode.Int64:
                        minValue = (decimal)Int64.MinValue;
                        maxValue = (decimal)Int64.MaxValue;
                        break;
                    case TypeCode.UInt16:
                        minValue = (decimal)UInt16.MinValue;
                        maxValue = (decimal)UInt16.MaxValue;
                        break;
                    case TypeCode.UInt32:
                        minValue = (decimal)UInt32.MinValue;
                        maxValue = (decimal)UInt32.MaxValue;
                        break;
                    case TypeCode.UInt64:
                        minValue = (decimal)UInt64.MinValue;
                        maxValue = (decimal)UInt64.MaxValue;
                        break;
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        minValue = decimal.MinValue;
                        maxValue = decimal.MaxValue;
                        break;
                }
                e.AutoDispose = true;
                e.Control = new DarkUI.Controls.DarkNumericUpDown
                {
                    Bounds = e.CellBounds,
                    Minimum = minValue,
                    Maximum = maxValue,
                    Increment = incr,
                    MouseWheelIncrement = incr,
                    Value = Convert.ToDecimal(e.Value),
                };
            }
        }

        protected override void OnCellEditFinishing(CellEditEventArgs e)
        {
            base.OnCellEditFinishing(e);

            var prop = e.RowObject as IPropertyValue;
            if (prop == null)
            {
                e.Cancel = true;
                return;
            }
            var type = prop.Value.GetType();
            var typeCode = Convert.GetTypeCode(prop.Value);
            var newValue = e.NewValue;

            if (typeCode == TypeCode.Boolean)
            {
                if (e.Control is DarkUI.Controls.DarkComboBox)
                {
                    var cb = (DarkUI.Controls.DarkComboBox)e.Control;
                    newValue = bool.Parse(cb.SelectedItem.ToString());
                }
            }
            else if (type.IsEnum)
            {
                if (e.Control is DarkUI.Controls.DarkComboBox)
                {
                    var cb = (DarkUI.Controls.DarkComboBox)e.Control;
                    newValue = Enum.Parse(type, cb.SelectedItem.ToString(), true);
                }
            }
            try
            {
                if (newValue == null)
                {
                    prop.Value = null;
                }
                else if (prop.Value != newValue)
                {
                    prop.Value = prop.Converter(newValue);
                }
            }
            catch (Exception)
            {
            }
        }

        public override void SetObjects(IEnumerable collection, bool preserveState)
        {
            //base.SetObjects(collection, preserveState);
            this.SetObjects(collection);
        }

        public override void SetObjects(IEnumerable collection)
        {
            if (collection != null)
            {
                foreach (var first in collection)
                {
                    SetObject(first);
                    return;
                }
            }
            this.SetObject(null);
        }

        public override object SelectedObject { get => base.SelectedObject; set => this.SetObject(value); }


        internal abstract class MemberPropertyWrapper : IPropertyValue
        {
            readonly static IPropertyValue[] EmptyChildren = new IPropertyValue[0];
            protected Object owner;
            protected System.Reflection.MemberInfo member;
            private bool? _haschildren;
            protected MemberPropertyWrapper(object value, System.Reflection.MemberInfo info) { 
                owner = value; 
                member = info;
            }
            public string Name => member.Name;
            public virtual Type Type { get => Value?.GetType() ?? typeof(object); }
            public virtual object Value { get; set; }
            public virtual bool IsReadOnly { get; }
            public virtual Func<object,object> Converter => (x) => Convert.ChangeType(x, Type);
            public virtual IRenderer Renderer { get => null; }
            public virtual ICellEditor Editor { get => null; }
            public virtual bool CanHaveChildren 
            { 
                get 
                {
                    if (_haschildren.HasValue) return _haschildren.Value;
                    _haschildren = (Value == null) ? false : !this.Type.IsPrimitive && !this.Type.IsEnum && this.Type != typeof(string) && !typeof(Delegate).IsAssignableFrom(this.Type);
                    return _haschildren.Value;
                }
            }
            public virtual IEnumerable<IPropertyValue> Children
            {
                get
                {
                    if (Value is IList)
                    {
                        var list = (IList)Value;
                        for (int i =0; i<list.Count; ++i)
                            yield return new ListItemPropertyWrapper(list, i);
                        yield break;
                    }
                    else if (Value is IEnumerable)
                    {
                        //foreach (var item in (IEnumerable)Value)
                        //    yield return x;

                        yield break ;
                    }
                    foreach (var member in GetMemberProperties(Value))
                        yield return member;
                }
            }

            const System.Reflection.BindingFlags defaultFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.FlattenHierarchy;

            internal static IEnumerable<System.Reflection.MemberInfo> GetMembers(Type type, System.Reflection.BindingFlags flags = defaultFlags)
            {
                foreach (var member in type.GetProperties(flags).Where(x => !x.IsSpecialName))
                    yield return member;
                foreach (var member in type.GetFields(flags).Where(x => !x.IsSpecialName))
                    yield return member;
            }

            internal static IEnumerable<IPropertyValue> GetMemberProperties(object value)
            {
                return (value == null) ? EmptyChildren : GetMembers(value.GetType())
                    .Select(x => (x is System.Reflection.PropertyInfo
                        ? (IPropertyValue)new PropertyPropertyWrapper(value, (System.Reflection.PropertyInfo)x)
                        : x is System.Reflection.FieldInfo
                        ? (IPropertyValue)new FieldPropertyWrapper(value, (System.Reflection.FieldInfo)x)
                        : null));
            }
        }

        internal class ListItemPropertyWrapper : IPropertyValue
        {
            protected int index;
            protected IList owner;

            public ListItemPropertyWrapper(IList item, int index)
            {
                this.index = index;
                this.owner = item;
            }
            
            public string Name => $"[{this.index}]";

            public object Value { get => owner[index]; set => owner[index] = value; }
            public virtual Type Type { get => Value?.GetType() ?? typeof(object); }

            public bool IsReadOnly => owner.IsReadOnly;

            public Func<object,object> Converter => (x) => Convert.ChangeType(x, Type);

            public IRenderer Renderer => null;

            public ICellEditor Editor => null;

            public bool CanHaveChildren
            {
                get
                {
                    return (Value == null) ? false : !this.Type.IsPrimitive && !this.Type.IsEnum && this.Type != typeof(string) && !typeof(Delegate).IsAssignableFrom(this.Type);
                }
            }

            public IEnumerable<IPropertyValue> Children => MemberPropertyWrapper.GetMemberProperties(Value);           
        }

        internal class FieldPropertyWrapper : MemberPropertyWrapper
        {
            public FieldPropertyWrapper(object value, System.Reflection.FieldInfo info) : base(value, info) { }
            System.Reflection.FieldInfo Field => (System.Reflection.FieldInfo)base.member;
            public override object Value { get => Field.GetValue(owner); set => Field.SetValue(owner, value); }
            public override bool IsReadOnly { get => Field.IsInitOnly || Value == null; }
        }

        internal class PropertyPropertyWrapper : MemberPropertyWrapper
        {
            public PropertyPropertyWrapper(object value, System.Reflection.PropertyInfo info) : base(value, info) { }

            System.Reflection.PropertyInfo Property => (System.Reflection.PropertyInfo)base.member;
            public override object Value { get => Property.CanRead ? Property.GetValue(owner, new object[0]) : null; set { if (Property.CanWrite) Property.SetValue(owner, value, new object[0]); } }
            public override bool IsReadOnly { get => (Property.CanRead && !Property.CanWrite) || Value == null; }
        }


        public void SetObject(object value)
        {
            if (value == null)
            {
                base.SetObjects(null, false);
            }
            else
            {
                base.SetObjects(MemberPropertyWrapper.GetMemberProperties(value), false);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int ScrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            int width = this.Columns[0].Width + this.Columns[1].Width;
            var pct = (float)this.Columns[0].Width / (float)width;
            var total = this.Width - ScrollBarWidth;
            var minwidth = new int[] { ((OLVColumn)this.Columns[0]).MinimumWidth, ((OLVColumn)this.Columns[1]).MinimumWidth };
            this.Columns[0].Width = Math.Min(total - minwidth[0], Math.Max(minwidth[1], (int)((float)total * pct)));
            this.Columns[1].Width = Math.Max(minwidth[1], total - this.Columns[0].Width);
        }

    }
}
