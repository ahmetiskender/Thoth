using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Thoth.Framework.Core.Utilities.Helpers
{
    public static class LinqExtensions
    {

        /// <summary>
        /// Executes a method if the object is not it's default value (null for reference types).
        /// It's the same as doing: o == null ? null : o.SomeProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static TResult IfNotNull<T, TResult>(this T o, Func<T, TResult> method)
        {
            if (o == null || o.Equals(default(T)))
                return default(TResult);
            else
                return method(o);
        }

        /// <summary>
        /// Enumerates through a list and executes some code, similar to a foreach statement
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
            return source;
        }

        /// <summary>
        /// Used to modify properties of an object returned from a LINQ query
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="input"></param>
        /// <param name="updater"></param>
        /// <returns></returns>
        public static TSource Set<TSource>(this TSource input, Action<TSource> updater)
        {
            updater(input);
            return input;
        }

        /// <summary>
        /// Determines whether an item exists in an enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Exists<T>(this IEnumerable<T> list, T element)
        {
            return list.Count(e => e.Equals(element)) > 0;
        }

        /// <summary>
        /// Determines whether an item exists in an enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Exists<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list.Count(predicate) > 0;
        }

        public static TSource PrepareForUpdate<TSource>(this TSource input)
        {
            input = ModelOperation<TSource>.Modify(input, Op.Update);
            return input;
        }


        /// <summary>
        /// Prepares entity for insert. Dev : Berkay.Aydin
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TSource PrepareForInsert<TSource>(this TSource input)
        {
            input = ModelOperation<TSource>.Modify(input, Op.Insert);
            return input;
        }
        /// <summary>
        /// Prepares entity for delete . @Author : Berkay
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TSource PrepareForDelete<TSource>(this TSource input)
        {
            input = ModelOperation<TSource>.Modify(input, Op.Delete);
            return input;
        }

        public static TSource ConvertFrom<TSource>(this TSource emptyObject, dynamic value)
        {
            System.Reflection.MemberInfo[] pis = value.GetType().GetMembers();
            foreach (System.Reflection.MemberInfo pi in pis)
            {
                if (pi.Name == "Id" || pi.Name == "CreatedAt" || pi.Name == "UserIdCreated" || pi.Name == "IsModified" || pi.Name == "ModifiedAt" || pi.Name == "UserIdModified" || pi.Name == "UserIdDeleted" || pi.Name == "IsVersioned" || pi.Name == "Version" || pi.Name == "ParentId")
                    continue;

                if (pi.MemberType == MemberTypes.Property)
                {
                    PropertyInfo propertyInfo = emptyObject.GetType().GetProperty(pi.Name);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(emptyObject, value.GetType().GetProperty(pi.Name).GetValue(value, null), null);
                    }
                }
            }
            return emptyObject;

        }
    }
}