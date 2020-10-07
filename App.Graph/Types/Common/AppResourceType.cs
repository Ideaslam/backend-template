using Edura.Domain.Entity.Common;
using Edura.Model.DTO.Common;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Graph.Types.Common
{
    class AppResourceType : ObjectGraphType<AppResourceDTO>
    {
        public AppResourceType()
        {
            Name = "AppResource";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Value, type: typeof(StringGraphType));
            Field(x => x.ValueAr, type: typeof(StringGraphType));



        }
    }
}
