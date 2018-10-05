using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Common
{
    public static class ObjectUtility
    {

        public static TDistinct CastTo<TDistinct>(this object obj) where TDistinct : class , new()
        {
            if (obj == null) throw new NullReferenceException("轉型物件不可為空");

            TDistinct distinct = obj as TDistinct;

            if(obj == null) throw new InvalidCastException("轉型物件失敗");

            return distinct;

        }

        public static PropertyInfo GetNestedType(Type value, string path)
        {

            Type type = value;
            PropertyInfo property = null;
            foreach (string propertyName in path.Split('.'))
            {
                property = type.GetProperty(propertyName);
                type = property.PropertyType;

            }

            return property;
        }

        public static IEnumerable<PropertyInfo> GetProperties(this object obj)
        {
            try
            {
                return obj.GetType()
                          .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                          .AsEnumerable();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static Object GetValueFromProp(this object obj,  string prop)
        {

            return obj.GetType()
                      .GetProperty(prop)
                      .GetValue(obj, null);
        }

    }

}
