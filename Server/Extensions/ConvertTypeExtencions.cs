using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Server.Extensions
{
    public static class ConvertTypeExtencions
    {
        public static To ToType<To>(this object self) where To : class, new()
        {
            var result = new To();
            result = self.ToType(result);
            return result;
        }

        public static To ToType<To, From>(this From self, To obj) where To : class, new()
        {
            var prop = typeof(To).GetProperties().Where(w => !w.PropertyType.FullName.Contains("Models") && !w.PropertyType.FullName.Contains("Collection"));

            if (obj == null)
                obj = new To();

            foreach (var item in prop)
            {
                var fromProperty = self.GetType().GetProperty(item.Name);
                if (fromProperty != null)
                {
                    var value = fromProperty.GetValue(self);
                    typeof(To).GetProperty(item.Name).SetValue(obj, value);
                }
            }

            return obj;
        }

        public static ICollection<To> ToListType<To>(this IEnumerable self) where To : class, new()
        {
            ICollection<To> list = new HashSet<To>();
            foreach (var item in self)
            {
                list.Add(item.ToType<To>());
            }
            return list;
        }
    }
}