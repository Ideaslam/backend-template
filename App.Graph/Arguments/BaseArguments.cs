using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Arguments
{
    public class BaseArguments: QueryArguments
    {
        public BaseArguments()
        {
            Add(new QueryArgument<IntGraphType> { Name = "Id" });
            Add(new QueryArgument<IntGraphType> { Name = "SearchText" });
            Add(new QueryArgument<BooleanGraphType> { Name = "PagingEnabled" });
            Add(new QueryArgument<IntGraphType> { Name = "PageSize" });
            Add(new QueryArgument<IntGraphType> { Name = "PageNumber" });
        }
    }
}
