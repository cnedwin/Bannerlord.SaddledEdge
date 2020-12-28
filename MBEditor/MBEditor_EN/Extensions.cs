using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using BrightIdeasSoftware;
using DarkUI.Controls;
using JetBrains.Annotations;
using Newtonsoft.Json;
#if MBVER_010201
using TaleWorlds.Core;
#else
using TaleWorlds.ObjectSystem;
#endif

namespace MBEditor
{
    internal static class Extensions
    {
        public static string SavePath = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Mount and Blade II Bannerlord\SaddledEdgeEditor");

        internal static void InitializeAutoSize(this UserControl ctrl)
        {
            //ctrl.AutoSize = GlobalState.Instance.AutoSize;
            //ctrl.AutoSizeMode = GlobalState.Instance.AutoSizeMode;
            //ctrl.AutoScaleMode = GlobalState.Instance.AutoScaleMode;
            //ctrl.AutoScaleDimensions = GlobalState.Instance.AutoScaleDimensions;
            //ctrl.PerformAutoScale();
        }
        internal static void InitializeAutoSize(this Form ctrl)
        {
            //ctrl.AutoSize = GlobalState.Instance.AutoSize;
            //ctrl.AutoSizeMode = GlobalState.Instance.AutoSizeMode;
            //ctrl.AutoScaleMode = GlobalState.Instance.AutoScaleMode;
            //ctrl.AutoScaleDimensions = GlobalState.Instance.AutoScaleDimensions;
            //ctrl.PerformAutoScale();
        }



        internal static bool TryGetJsonSettings(this ObjectListView tree, out JObject result)
        {
            try
            {
                var obj = new JObject();
                {
                    var columns = new JObject();
                    foreach (var column in tree.AllColumns) {
                        var col = new JObject();
                        col.Add("Width", JToken.FromObject(column.Width) );
                        col.Add("Visible", JToken.FromObject(column.IsVisible));
                        columns.Add(column.Text, col);
                    }
                    obj.Add("Columns", columns);
                    if (tree.PrimarySortColumn != null) {
                        obj.Add("PrimarySort", value: new JObject { { tree.PrimarySortColumn.Text, JToken.FromObject(tree.PrimarySortOrder) } });
                    }
                }
                result = obj;
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
            result = null;
            return false;
        }

        internal static void ApplyJsonSettings(this ObjectListView tree, [CanBeNull] JToken values)
        {
            if (values == null) return;
            try {
                var sort = values["PrimarySort"];
                if (sort != null) {
                    var prop = sort.First as JProperty;
                    if (prop != null) {
                        var sortcol = tree.AllColumns.FirstOrDefault(x => x.Text == prop.Name);
                        if (sortcol != null)
                            tree.Sort(sortcol, prop.Value.ToObject<SortOrder>());

                    }
                }
                var columns = values["Columns"];
                foreach (var col in columns.Values<JProperty>()) {
                    var column = tree.AllColumns.FirstOrDefault(x => x.Text == col.Name);
                    if (column != null) {
                        if (Int32.TryParse(col.Value["Width"]?.ToString(), out var width))
                            column.Width = width;
                        if (Boolean.TryParse(col.Value["Visible"]?.ToString(), out var visible))
                            column.IsVisible = visible;
                    }
                }
                tree.Columns.Clear();
                tree.Columns.AddRange(tree.AllColumns.Where(x => x.IsVisible).ToArray<ColumnHeader>());
                tree.UpdateColumnFiltering();
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }


        internal static bool TryGetJsonSettings(this SplitContainer ctrl, out JToken result)
        {
            try
            {
                result = JToken.FromObject( (double)ctrl.SplitterDistance / (double)(ctrl.Orientation == Orientation.Vertical ? ctrl.Width : ctrl.Height) );
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
            result = null;
            return false;
        }

        internal static void ApplyJsonSettings(this SplitContainer ctrl, [CanBeNull] JToken values)
        {
            if (values == null) return;
            try
            {
                // ignore for now as it this is not restore cleanly

                //var pctWidth = values.ToObject<double>();
                //ctrl.SplitterDistance = ctrl.Orientation == Orientation.Vertical
                //    ? Math.Max(50, Math.Min(ctrl.Width-50, (int)((double)ctrl.Width * pctWidth)))
                //    : Math.Max(50, Math.Min(ctrl.Height - 50, (int)((double)ctrl.Height * pctWidth))) ;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }


        internal static bool TryReadConfigSave(out JObject result, string filename = "Config.json")
        {
            try
            {
                var filepath = Path.Combine(SavePath, filename);
                if (!File.Exists(filepath))
                {
                    result = null;
                    return false;
                }
                using (var reader = File.OpenRead(filepath))
                using (var text = new StreamReader(reader))
                using (var json = new JsonTextReader(text))
                {
                    result = JObject.Load(json);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
            result = null;
            return false;
        }

        internal static void WriteConfigSave(JObject values, string filename = "Config.json")
        {
            try
            {
                Directory.CreateDirectory(SavePath);
                using (var writer = File.Open(Path.Combine(SavePath, filename), FileMode.Create))
                using (var text = new StreamWriter(writer))
                {
                    text.Write(values.ToString(Formatting.Indented));
                    text.Flush();
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }

        internal static DarkNumericUpDown DefaultEditor( this DarkNumericUpDown ctrl, object value )
        {
            if (value == null) return ctrl;

            var type = value.GetType();
            var typeCode = Convert.GetTypeCode(value);

            var minValue = (decimal)Int32.MinValue;
            var maxValue = (decimal)Int32.MaxValue;
            var absval = Math.Abs(Convert.ToDouble(value));
            if (absval < 0.001) absval = 1.0;
            var scale = (absval < 0.001) ? 0 : Convert.ToInt32(Math.Log10(absval));
            var incr = (absval < 0.001) ? 1M : Convert.ToDecimal(Math.Pow(10, Math.Min(3, Math.Max(0, scale - 2))));

            switch (typeCode)
            {
                case TypeCode.Byte:
                    minValue = (decimal)Byte.MinValue;
                    maxValue = (decimal)Byte.MaxValue;
                    break;
                case TypeCode.SByte:
                    minValue = (decimal)SByte.MinValue;
                    maxValue = (decimal)SByte.MaxValue;
                    break;
                case TypeCode.Char:
                    minValue = (decimal)Char.MinValue;
                    maxValue = (decimal)Char.MaxValue;
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
                    minValue = Decimal.MinValue;
                    maxValue = Decimal.MaxValue;
                    ctrl.DecimalPlaces = (scale < 2) ? 2+Math.Abs(scale) : 0;
                    break;
            }
            ctrl.Minimum = minValue;
            ctrl.Maximum = maxValue;
            ctrl.Increment = incr;
            ctrl.MouseWheelIncrement = incr;
            ctrl.Value = Convert.ToDecimal(value);
            return ctrl;
        }



        internal static void DarkUI_ObjectList_CellEditStarting(object sender, CellEditEventArgs e)
        {
            
            var type = e.Value.GetType();
            var typeCode = Convert.GetTypeCode(e.Value);
            if (typeCode == TypeCode.Boolean)
            {
                e.AutoDispose = true;
                var cb = new DarkComboBox
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
                var cb = new DarkComboBox
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
                e.Control = new DarkTextBox
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
                var value = e.Value;
                var minValue = (decimal)Int32.MinValue;
                var maxValue = (decimal)Int32.MaxValue;
                var absval = Math.Abs(Convert.ToDouble(value));
                var scale = (absval < 0.001) ? 0 : Convert.ToInt32(Math.Log10(absval));
                var incr = (absval < 0.001) ? 1M : Convert.ToDecimal(Math.Pow(10, Math.Min(3, Math.Max(0, scale - 2))));

                switch (typeCode)
                {
                    case TypeCode.Byte:
                        minValue = (decimal)Byte.MinValue;
                        maxValue = (decimal)Byte.MaxValue;
                        break;
                    case TypeCode.SByte:
                        minValue = (decimal)SByte.MinValue;
                        maxValue = (decimal)SByte.MaxValue;
                        break;
                    case TypeCode.Char:
                        minValue = (decimal)Char.MinValue;
                        maxValue = (decimal)Char.MaxValue;
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
                        minValue = Decimal.MinValue;
                        maxValue = Decimal.MaxValue;
                        break;
                }
                e.AutoDispose = true;
                e.Control = new DarkNumericUpDown
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

        internal static void DarkUI_ObjectList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            var type = e.Value.GetType();
            var typeCode = Convert.GetTypeCode(e.Value);
            var newValue = e.NewValue;

            if (typeCode == TypeCode.Boolean)
            {
                if (e.Control is DarkComboBox)
                {
                    var cb = (DarkComboBox)e.Control;
                    newValue = Boolean.Parse(cb.SelectedItem.ToString());
                }
            }
            else if (type.IsEnum)
            {
                if (e.Control is DarkComboBox)
                {
                    var cb = (DarkComboBox)e.Control;
                    newValue = Enum.Parse(type, cb.SelectedItem.ToString(), true);
                }
            }
            try
            {
                if (newValue == null)
                {
                    e.NewValue = null;
                }
                else if (e.NewValue != newValue)
                {
                    e.NewValue = Convert.ChangeType(newValue, type);
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }

        public static void InitializeComboBox(this DarkComboBox cb, Type type, object value, bool addNull = false)
        {
            cb.BeginUpdate();
            cb.Items.Clear();
            var items = ObjectCache.GetObjectTypeList(type);
            if (addNull) cb.Items.Add(new DarkUI.Controls.DarkListItem(null, o => "<None>"));

            cb.Items.AddRange(items.OfType<MBObjectBase>()
                .Select(x => new DarkUI.Controls.DarkListItem(x, o => ((MBObjectBase) o).GetName()?.ToString()))
                .OrderBy(x => x.Text, StringComparer.InvariantCultureIgnoreCase)
                .OfType<object>()
                .ToArray());
            cb.EndUpdate();
            cb.SelectedItem = cb.Items.OfType<DarkUI.Controls.DarkListItem>().FirstOrDefault(x => x.Tag == value);
        }
    }
}
