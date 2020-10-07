using Edura.Model.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Edura.Extentsons
{
    public static class Extentions
    {
        private static string IncludedProps;
        //public static IQueryable<T> SelectFields<T>(this IQueryable<T> query, string fields = "")
        //{
        //    string[] EntityFields;
        //    if (fields == "")
        //        // get Properties of the T
        //        EntityFields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
        //    else
        //        EntityFields = fields.Split(',');

        //    // input parameter "o"
        //    var xParameter = Expression.Parameter(typeof(T), "o");

        //    // new statement "new Data()"
        //    var xNew = Expression.New(typeof(T));

        //    // create initializers
        //    var bindings = EntityFields.Select(o => o.Trim())
        //        .Select(o =>
        //        {

        //            // property "Field1"
        //            var mi = typeof(T).GetProperty(o);

        //            // original value "o.Field1"
        //            var xOriginal = Expression.Property(xParameter, mi);

        //            // set value "Field1 = o.Field1"
        //            return Expression.Bind(mi, xOriginal);
        //        }
        //    );

        //    // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        //    var xInit = Expression.MemberInit(xNew, bindings);

        //    // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        //    var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

        //    // compile to Func<Data, Data>
        //    return query.Select(lambda.Compile()).AsQueryable();
        //}
        //"Id,Name,CountryCode,Cities(Id,Name,Areas(Id,Name))"

      

        private static string GetMapToName(string propName, Type parentType)
        {
            string mapToName = string.Empty;

            var property = parentType.GetProperty(propName);
            var attrs = property.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                MapToAttribute mapToAttr = attr as MapToAttribute;
                if (mapToAttr != null)
                {
                    mapToName = mapToAttr.Name;
                }
            }
            return mapToName;
        }

        private static string HandlePureProp(string propName, Type resultType)
        {
            string result = "";
            propName = propName.Trim();
            string mapToName = GetMapToName(propName, resultType);
                        
            result += (string.IsNullOrEmpty(mapToName) ? propName : $"{mapToName} as {propName}" );
            return result;
        }

        private static string HandleNestedProp(string propName, List<string> childrenProps, Type parentType)
        {
            string result = "";
            string mapToName = GetMapToName(propName, parentType);
            Type propType = parentType.GetProperty(propName).PropertyType;
            mapToName = string.IsNullOrEmpty(mapToName) ? propName : mapToName;
            IncludedProps = string.IsNullOrEmpty(IncludedProps)? mapToName: $"{mapToName},{mapToName}.{IncludedProps}";
            if (typeof(IEnumerable).IsAssignableFrom(propType) && propType.Name != "String")
            {
                var referalType = propType.GetGenericArguments()[0];
                result += $"{mapToName}.Select( new {referalType.FullName}({string.Join(',',childrenProps)})).ToList() as {propName}";
            }
            else if (propType.GetTypeInfo().IsClass)
            {
                result += $"new {propType.FullName}({string.Join(',', childrenProps.Select(prop=>$"{mapToName}.{prop}"))}) as {propName}";
            }
            return result;
        }

        private static string HandleProps(string props, Type resultType)
        {
            string result = "";

            Stack<string> stack = new Stack<string>();
            StringBuilder stringBuilder = new StringBuilder();
            Type parentType = resultType;
            string nestedProps = string.Empty;
            foreach (char c in props)
            {
                if (c == '(')
                {
                    var nestedPropName = stringBuilder.ToString().Trim();
                    stack.Push(nestedPropName);
                    nestedProps = string.IsNullOrEmpty(nestedProps) ? nestedPropName : $"{nestedProps}.{nestedPropName}";
                    stack.Push(c.ToString());
                    stringBuilder.Clear();
                }
                else if (c == ',')
                {
                    var propName = stringBuilder.ToString().Trim();
                    stack.Push(HandlePureProp(propName, parentType));
                    stringBuilder.Clear();
                }
                else if (c == ')')
                {
                    if (stringBuilder.Length > 0)
                    {
                        var propName = stringBuilder.ToString().Trim();
                        stack.Push(HandlePureProp(propName, parentType));
                        stringBuilder.Clear();
                    }

                    List<string> nestedChildrenProps = new List<string>();
                    string element = stack.Pop();
                    while (element != "(")
                    {
                        nestedChildrenProps.Add(element);
                        element = stack.Pop();
                    }
                    string nestedPropName = stack.Pop();
                    Type nestedParentType = parentType;
                    nestedProps = nestedProps.Replace($".{nestedPropName}", "").Replace(nestedPropName, "");

                    if (!string.IsNullOrEmpty(nestedProps))
                    {
                        nestedProps.Split('.').ToList().ForEach(prop =>
                        {
                            nestedParentType = nestedParentType.GetProperty(prop).PropertyType;
                            if (nestedParentType.GetGenericArguments().Length > 0) nestedParentType = nestedParentType.GetGenericArguments()[0];

                        });
                    }

                    stack.Push(HandleNestedProp(nestedPropName, nestedChildrenProps, nestedParentType));
                }
                else stringBuilder.Append(c);

            }
            while (stack.Count > 0)
            {
                result = $"{stack.Pop()},{result}";
            }
            return result;

        }

        private static string CreateSelector(string props, Type resultType)
        {
            var result = HandleProps(props, resultType);
            return  $"new ({result.Substring(0, result.Length - 1)})";
        }

        public static IQueryable<T> SelectProps<T>(this IQueryable<T> query, string props) where T : class
        {

            return query.SelectProps<T, T>(props);
        }

        public static IQueryable<TResult> SelectProps<TSource,TResult>(this IQueryable<TSource> query, string props) where TSource:class
        {
            var config = new ParsingConfig { AllowNewToEvaluateAnyType = true };
            var selector = CreateSelector(props, typeof(TResult));
            if (!string.IsNullOrEmpty(IncludedProps))
            {
                IncludedProps.Split(',').ToList().ForEach(navigationProp => query = query.Include(navigationProp));
                IncludedProps = string.Empty;

            }
            return query.Select<TResult>(config, selector);
        }
    }
}
