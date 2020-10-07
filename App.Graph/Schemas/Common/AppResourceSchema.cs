using Edura.Graph.Queries.Common;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Edura.Graph.Schemas.Common
{
    public class AppResourceSchema : Schema
    {
        public AppResourceSchema(IServiceProvider provider) :base(provider)
        {
            Query = provider.GetRequiredService<AppResourceQuery>();
            Query.Name = "AppResources";

            


        }

    }
}
