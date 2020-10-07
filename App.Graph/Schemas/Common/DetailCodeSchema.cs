using Edura.Graph.Queries.Common;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Edura.Graph.Schemas.Common
{
    public class DetailCodeSchema:Schema
    {
        public DetailCodeSchema(IServiceProvider provider) :base(provider)
        {
            Query = provider.GetRequiredService<DetailCodeQuery>();
            Query.Name = "Lookups";

            


        }

    }
}
