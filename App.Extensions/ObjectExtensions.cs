﻿using Edura.Domain.Entity.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Edura.Extentsons
{
    public static class ObjectExtensions
    {
        public static object ToType<T>(this object obj, T type) where T :Type
        {

            //create instance of T type object:
            var tmp = Activator.CreateInstance(Type.GetType(type.AssemblyQualifiedName.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {
                    if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType) && pi.PropertyType.Name != "String")
                    {
                        var property = tmp.GetType().GetProperty(pi.Name);
                        Type reflectedType = property.PropertyType.GetGenericArguments()[0];
                        var child = ((IEnumerable<object>)pi.GetValue(obj, null)).ToNonAnonymousList(reflectedType);

                        property.SetValue(tmp, child, null);
                    }
                    
                    else
                    {
                        //get the value of property and try 
                        //to assign it to the property of T type object:
                        tmp.GetType().GetProperty(pi.Name).SetValue(tmp,
                                                  pi.GetValue(obj, null), null);
                    }

                }
                catch(Exception ex) {
                    var x = ex;
                }
            }

            //return the T type object:         
            return tmp;
        }

        public static object ToNonAnonymousList<T>(this IEnumerable<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }
    }
}
