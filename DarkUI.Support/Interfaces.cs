using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DarkUI.Support
{


    public interface ICellEditor
    {
        bool SupportEditValue(object value);
        Control BeginEdit();
        void EndEdit();
    }

    public interface IPropertyValue
    {
        string Name { get; }
        object Value { get; set; }
        Type Type { get ; }
        bool IsReadOnly { get; }
        Func<object,object> Converter { get; }
        BrightIdeasSoftware.IRenderer Renderer { get; }
        ICellEditor Editor { get; }
        bool CanHaveChildren { get; }
        IEnumerable<IPropertyValue> Children { get; }
    }
}
