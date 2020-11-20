using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MBEditor
{
    using TaleWorlds.Library;
#if MBVER_010201
    using TaleWorlds.Core;
#else
    using TaleWorlds.ObjectSystem;
#endif

    internal static class ObjectCache
    {
        private static Dictionary<Type, ICollection> _sealedCache = new Dictionary<Type, ICollection>();
        private static Dictionary<Type, ICollection> _instanceCache = new Dictionary<Type, ICollection>();
        private static readonly ICollection _emptyCollection = new object[0];
        private static readonly MethodInfo _getObjectTypeList;

        static ObjectCache()
        {
            _getObjectTypeList = typeof(MBObjectManager).GetMembers(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x=>x.Name.StartsWith("GetObjectTypeList")) as MethodInfo;
        }

        public static IEnumerable<T> GetObjectTypeList<T>() where T:MBObjectBase
        {
            var result = GetObjectTypeList(typeof(T)) as IEnumerable<T>;
            return result ?? new T[0];
        }

        public static ICollection GetObjectTypeList(Type t)
        {
            if (typeof(MBObjectBase).IsAssignableFrom(t)) {
                var result = _getObjectTypeList.MakeGenericMethod(t).Invoke(MBObjectManager.Instance, new object[0]) as ICollection;
                return result ?? _emptyCollection;
            }
            return _emptyCollection;
        }


    }
}
