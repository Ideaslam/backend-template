using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Arguments.Common
{
    public class CountryArguments: BaseArguments
    {
        public CountryArguments()
        {
            Add(new QueryArgument<StringGraphType> { Name = "Code" });
            Add(new QueryArgument<StringGraphType> { Name = "CountryCode" });
        }
    }
}
