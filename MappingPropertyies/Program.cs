using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MappingPropertyies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();

            PrintPropertiesOfA();

            a.prop_a_1 = "Propa_1";
            a.prop_a_2 = "Propa_2";

            b.prop_b_1 = "Propb_1";
            b.prop_b_2 = "Propb_2";
            b.prop_b_3 = "Propb_3";

            b = a.MapTo<B>();

            ValidateMapping<B>();

            Console.WriteLine("Mapped values in object B:");
            Console.WriteLine($"prop_b_1: {b.prop_b_1}");
            Console.WriteLine($"prop_b_2: {b.prop_b_2}");
            Console.WriteLine($"prop_b_3: {b.prop_b_3}");

            Console.ReadKey();
        }

        public static void PrintPropertiesOfA()
        {
            Console.WriteLine("Properties of class A:");
            PropertyInfo[] properties = typeof(A).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }
        }

        public static void ValidateMapping<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MapToAttribute mapToAttribute = (MapToAttribute)Attribute.GetCustomAttribute(property, typeof(MapToAttribute));
                if (mapToAttribute != null)
                {
                    string targetPropertyName = mapToAttribute.TargetPropertyName;
                    PropertyInfo targetProperty = typeof(A).GetProperty(targetPropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance); // Sử dụng BindingFlags.IgnoreCase để bỏ qua sự phân biệt chữ hoa chữ thường
                    if (targetProperty == null)
                    {
                        Console.WriteLine($"Error: Property '{property.Name}' in class '{typeof(T).Name}' is mapped to non-existent property '{targetPropertyName}'");
                    }
                }
            }
        }


    }

    public class A
    {
        public string prop_a_1 { get; set; }
        public string prop_a_2 { get; set; }
    }

    public class B
    {
        public string prop_b_1 { get; set; }
        [MapTo("prop_a_1")]
        public string prop_b_2 { get; set; }
        [MapTo("prop_a_2")]
        public string prop_b_3 { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MapToAttribute : Attribute
    {
        public string TargetPropertyName { get; }

        public MapToAttribute(string targetPropertyName)
        {
            TargetPropertyName = targetPropertyName;
        }
    }

    public static class MappingExtensions
    {
        public static T MapTo2<T>(this object source) where T : new()
        {
            T target = new T();
            PropertyInfo[] sourceProperties = source.GetType().GetProperties();
            PropertyInfo[] targetProperties = typeof(T).GetProperties();

            foreach (PropertyInfo targetProperty in targetProperties)
            {
                MapToAttribute mapToAttribute = (MapToAttribute)Attribute.GetCustomAttribute(targetProperty, typeof(MapToAttribute));
                if (mapToAttribute != null)
                {
                    string sourcePropertyName = mapToAttribute.TargetPropertyName;
                    PropertyInfo sourceProperty = source.GetType().GetProperty(sourcePropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (sourceProperty != null)
                    {
                        object value = sourceProperty.GetValue(source);
                        targetProperty.SetValue(target, value);
                    }
                }
            }

            return target;
        }


        public static T MapTo<T>(this object source) where T : new()
        {
            return (T)MapTo(source, typeof(T));
        }

        private static object MapTo(object source, Type targetType)
        {
            object target = Activator.CreateInstance(targetType);
            PropertyInfo[] sourceProperties = source.GetType().GetProperties();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            foreach (PropertyInfo targetProperty in targetProperties)
            {
                MapToAttribute mapToAttribute = (MapToAttribute)Attribute.GetCustomAttribute(targetProperty, typeof(MapToAttribute));
                if (mapToAttribute != null)
                {
                    string sourcePropertyName = mapToAttribute.TargetPropertyName;
                    PropertyInfo sourceProperty = source.GetType().GetProperty(sourcePropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (sourceProperty != null)
                    {
                        object sourceValue = sourceProperty.GetValue(source);
                        if (sourceValue != null && sourceProperty.PropertyType.IsClass && sourceProperty.PropertyType != typeof(string))
                        {
                            object nestedTarget = MapTo(sourceValue, sourceProperty.PropertyType);
                            targetProperty.SetValue(target, nestedTarget);
                        }
                        else
                        {
                            targetProperty.SetValue(target, sourceValue);
                        }
                    }
                }
            }

            return target;
        }


    }

}
