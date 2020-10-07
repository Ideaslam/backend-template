using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Arguments.Common
{
    public class CityArguments:BaseArguments
    {
        public CityArguments()
        {
            Add(new QueryArgument<StringGraphType> { Name = "Code" });
        }
    }
}
