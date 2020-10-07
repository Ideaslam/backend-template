using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Utils.Helpers
{
    public static class GraphQLHelper
    {
        //context.SubFields["Cities"].Children.ToList()[0].Children.ToList()[0].Children.ToList()[0].Children.ToList()
        private static string GetChildren(Field field)
        {
            string res = "";
            var children = field.Children.ToList()[0].Children.ToList();
            if (children.Count > 0)
            {
                res += field.Name + "(";
                children.ForEach(child => res += GetChildren((Field)child));
                res = (res[res.Length-1]==','? res.Substring(0,res.Length-1): res) + ")";
            }
            else
            {
                res += field.Name + ",";
            }
            return res;
        }
        public static string GetRequestedFields(IResolveFieldContext<object> context)
        {
            var res = "";
            foreach (var key in context.SubFields.Keys)
            {
                var field = context.SubFields[key];
                res += GetChildren(field);
            }
            return res;


        }
    }
}
